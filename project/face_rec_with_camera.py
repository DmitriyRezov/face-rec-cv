import face_recognition
import pickle
import cv2

# каскад хаара
# https://ru.wikipedia.org/wiki/%D0%9F%D1%80%D0%B8%D0%B7%D0%BD%D0%B0%D0%BA%D0%B8_%D0%A5%D0%B0%D0%B0%D1%80%D0%B0
# загружаем каскад хаара в каскадный классификатор
faceCascade = cv2.CascadeClassifier("haarcascade_frontalface_default.xml")
# загружаем известные лица из face_enc
data = pickle.loads(open('face_enc', "rb").read())

print("Streaming started")
# включаем вебку
video_capture = cv2.VideoCapture(0)
# перебираем видео по кадрам
while True:
    # захватываем камеру из видео
    ret, frame = video_capture.read()
    # переводим кадр в серый цвет и ищем на кадре лица
    gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
    faces = faceCascade.detectMultiScale(gray,
                                         scaleFactor=1.1,
                                         minNeighbors=5,
                                         minSize=(60, 60),
                                         flags=cv2.CASCADE_SCALE_IMAGE)

    # переводим изображения из BGD в RGB
    rgb = cv2.cvtColor(frame, cv2.COLOR_BGR2RGB)
    # берем черты лица из кадра
    encodings = face_recognition.face_encodings(rgb)
    names = []

    for encoding in encodings:
        # сравниваем черты лица из кадра с известными нам
        matches = face_recognition.compare_faces(data["encodings"],
                                                 encoding)
        name = "Unknown"

        if True in matches:
            matchedIdxs = [i for (i, b) in enumerate(matches) if b]
            counts = {}

            # ищем имя из face_enc
            for i in matchedIdxs:
                name = data["names"][i]
                counts[name] = counts.get(name, 0) + 1
            name = max(counts, key=counts.get)

        names.append(name)

        # рисуем квадрат вокруг лица и подписываем имя
        for ((x, y, w, h), name) in zip(faces, names):
            cv2.rectangle(frame, (x, y), (x + w, y + h), (0, 255, 0), 2)
            cv2.putText(frame, name, (x, y - 10), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 255, 0), 2)
    # выводим видео
    cv2.imshow("Frame", frame)

    # ДЛЯ ЗАКРЫТИЯ ВИДЕО НАЖМИТЕ < Q > !!!!!!!!!!!!!!!!!!
    if cv2.waitKey(1) & 0xFF == ord('q'):
        break
video_capture.release()
cv2.destroyAllWindows()

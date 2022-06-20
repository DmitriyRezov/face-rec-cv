using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.CvEnum;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace Simple_Face_Recognition_App
{
    public class Scanning
    {
        #region Variables
        int testid = 0;
        public Capture videoCapture = null;
        private Image<Bgr, Byte> currentFrame = null;
        Mat frame = new Mat();
        private bool facesDetectionEnabled = false;
        CascadeClassifier faceCasacdeClassifier = new CascadeClassifier("haarcascade_frontalface_alt.xml");
        Image<Bgr, Byte> faceResult = null;
        List<Image<Gray, Byte>> TrainedFaces = new List<Image<Gray, byte>>();
        List<int> PersonsLabes = new List<int>();

        bool EnableSaveImage = false;
        private bool isTrained = false;
        EigenFaceRecognizer recognizer;
        List<string> PersonsNames = new List<string>();
        #endregion

        public TableLayoutPanel Window;
        public TableLayoutPanel CameraWindow;
        public PictureBox picCapture;
        public Button btnCapture;
        public Button btnDetectFaces;
        public TextBox txtPersonName;
        public Button btnTrain;
        public Button btnRecognize;
        public PictureBox picDetected;
        public Button btnAddPerson;
        public Button goBack;

        public Scanning()
        {
            Window = new TableLayoutPanel()
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(240, 29, 29, 29),
            };

            CameraWindow = new TableLayoutPanel()
            {
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
            };

            picCapture = new PictureBox()
            {
                Size = new Size(Form1.WidthScreen / 2, Form1.HeightScreen / 2),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Margin = new Padding(CameraWindow.Size.Width / 2, CameraWindow.Size.Height / 2 + 120, CameraWindow.Size.Width / 2 - 100, 0),
            };

            btnCapture = new Button()
            {
                Text = "Включить камеру",
                Dock = DockStyle.Fill,
            };

            btnDetectFaces = new Button()
            {
                Text = "Включить распознавание лиц",
                Dock = DockStyle.Fill,
            };

            txtPersonName = new TextBox()
            {
                TextAlign = HorizontalAlignment.Center,
                Font = new Font(FontFamily.GenericSansSerif, 14),
                Text = "Your Name",
                Dock = DockStyle.Fill,
                ForeColor = Color.FromArgb(169, 169, 169),
            };
            txtPersonName.Margin = new Padding(0, 50 - txtPersonName.Height, 0, 0);

            txtPersonName.GotFocus += (sender, args) => txtPersonName.Text = "";
            txtPersonName.LostFocus += (sender, args) =>
            {
                if (txtPersonName.Text == "")
                    txtPersonName.Text = "Your Name";
            };

            btnTrain = new Button()
            {
                Text = "Показать сохраненные лица",
                Dock = DockStyle.Fill,
            };

            btnRecognize = new Button()
            {
                Text = "Распознать лицо",
                Dock = DockStyle.Fill,
            };

            picDetected = new PictureBox()
            {
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(100, 100),
            };

            btnAddPerson = new Button()
            {
                Text = "Сохранить лицо",
                Dock = DockStyle.Fill,
            };

            goBack = new Button()
            {
                Text = "Вернуться назад",
                Dock = DockStyle.Fill,
            };

            CameraWindow.RowStyles.Add(new RowStyle(SizeType.Absolute, 150));
            CameraWindow.RowStyles.Add(new RowStyle(SizeType.Absolute, 75));
            CameraWindow.RowStyles.Add(new RowStyle(SizeType.Absolute, 75));
            CameraWindow.RowStyles.Add(new RowStyle(SizeType.Absolute, 75));
            CameraWindow.RowStyles.Add(new RowStyle(SizeType.Absolute, 75));
            CameraWindow.RowStyles.Add(new RowStyle(SizeType.Absolute, 75));
            CameraWindow.RowStyles.Add(new RowStyle(SizeType.Absolute, 75));
            CameraWindow.RowStyles.Add(new RowStyle(SizeType.Absolute, 100));
            CameraWindow.RowStyles.Add(new RowStyle(SizeType.Absolute, 75));
            CameraWindow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
            CameraWindow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 350));
            CameraWindow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
            CameraWindow.Controls.Add(new Panel(), 1, 0);
            CameraWindow.Controls.Add(btnCapture, 1, 1);
            CameraWindow.Controls.Add(btnDetectFaces, 1, 2);
            CameraWindow.Controls.Add(btnAddPerson, 1, 3);
            CameraWindow.Controls.Add(txtPersonName, 1, 4);
            CameraWindow.Controls.Add(btnTrain, 1, 5);
            CameraWindow.Controls.Add(goBack, 1, 6);
            CameraWindow.Controls.Add(picDetected, 1, 7);
            CameraWindow.Controls.Add(new Panel(), 2, 8);

            Window.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            Window.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            Window.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            Window.Controls.Add(picCapture, 0, 0);
            Window.Controls.Add(CameraWindow, 1, 0);
        }

        public void btnCapture_Click(object sender, EventArgs e)
        {
            //Dispose of Capture if it was created before
            if (videoCapture != null) videoCapture.Dispose();
            videoCapture = new Capture();
            //videoCapture.ImageGrabbed += ProcessFrame;
            Application.Idle += ProcessFrame;
            //videoCapture.Start();
        }

        public void ProcessFrame(object sender, EventArgs e)
        {
            //Step 1: Video Capture
            if (videoCapture != null && videoCapture.Ptr != IntPtr.Zero)
            {
                videoCapture.Retrieve(frame, 0);
                currentFrame = frame.ToImage<Bgr, Byte>().Resize(picCapture.Width, picCapture.Height, Inter.Cubic);

                //Step 2: Face Detection
                if (facesDetectionEnabled)
                {

                    //Convert from Bgr to Gray Image
                    Mat grayImage = new Mat();
                    CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);
                    //Enhance the image to get better result
                    CvInvoke.EqualizeHist(grayImage, grayImage);

                    Rectangle[] faces = faceCasacdeClassifier.DetectMultiScale(grayImage, 1.1, 3, Size.Empty, Size.Empty);
                    //If faces detected
                    if (faces.Length > 0)
                    {

                        foreach (var face in faces)
                        {
                            //Draw square around each face 
                            // CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);

                            //Step 3: Add Person 
                            //Assign the face to the picture Box face picDetected
                            Image<Bgr, Byte> resultImage = currentFrame.Convert<Bgr, Byte>();
                            resultImage.ROI = face;
                            picDetected.SizeMode = PictureBoxSizeMode.StretchImage;
                            picDetected.Image = resultImage.Bitmap;

                            if (EnableSaveImage)
                            {
                                //We will create a directory if does not exists!
                                string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
                                if (!Directory.Exists(path))
                                    Directory.CreateDirectory(path);
                                //we will save 10 images with delay a second for each image 
                                //to avoid hang GUI we will create a new task
                                Task.Factory.StartNew(() => {
                                    for (int i = 0; i < 10; i++)
                                    {
                                        //resize the image then saving it
                                        resultImage.Resize(200, 200, Inter.Cubic).Save(path + @"\" + txtPersonName.Text + "_" + DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".jpg");
                                        Thread.Sleep(1000);
                                    }
                                });

                            }
                            EnableSaveImage = false;

                            if (btnAddPerson.InvokeRequired)
                            {
                                btnAddPerson.Invoke(new ThreadStart(delegate {
                                    btnAddPerson.Enabled = true;
                                }));
                            }

                            // Step 5: Recognize the face 
                            if (isTrained)
                            {
                                Image<Gray, Byte> grayFaceResult = resultImage.Convert<Gray, Byte>().Resize(200, 200, Inter.Cubic);
                                CvInvoke.EqualizeHist(grayFaceResult, grayFaceResult);
                                var result = recognizer.Predict(grayFaceResult);
                                Debug.WriteLine(result.Label + ". " + result.Distance);
                                //Here results found known faces
                                if (result.Label != -1 && result.Distance < 2000)
                                {
                                    CvInvoke.PutText(currentFrame, PersonsNames[result.Label], new Point(face.X - 2, face.Y - 2),
                                        FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                                    CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Green).MCvScalar, 2);
                                }
                                //here results did not found any know faces
                                else
                                {
                                    CvInvoke.PutText(currentFrame, "Unknown", new Point(face.X - 2, face.Y - 2),
                                        FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                                    CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);

                                }
                            }
                        }
                    }
                }

                //Render the video capture into the Picture Box picCapture
                picCapture.Image = currentFrame.Bitmap;
            }

            //Dispose the Current Frame after processing it to reduce the memory consumption.
            if (currentFrame != null)
                currentFrame.Dispose();
        }

        public void btnDetectFaces_Click(object sender, EventArgs e)
        {
            facesDetectionEnabled = true;
        }

        public void btnAddPerson_Click(object sender, EventArgs e)
        {
            btnAddPerson.Enabled = false;
            EnableSaveImage = true;
        }

        public void btnTrain_Click(object sender, EventArgs e)
        {
            TrainImagesFromDir();
        }

        //Step 4: train Images .. we will use the saved images from the previous example 
        private bool TrainImagesFromDir()
        {
            int ImagesCount = 0;
            double Threshold = 2000;
            //TrainedFaces.Clear();
            //PersonsLabes.Clear();
            //PersonsNames.Clear();
            try
            {
                string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
                string[] files = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);

                foreach (var file in files)
                {
                    Image<Gray, byte> trainedImage = new Image<Gray, byte>(file).Resize(200, 200, Inter.Cubic);
                    CvInvoke.EqualizeHist(trainedImage, trainedImage);
                    TrainedFaces.Add(trainedImage);
                    PersonsLabes.Add(ImagesCount);
                    string name = file.Split('\\').Last().Split('_')[0];
                    PersonsNames.Add(name);
                    ImagesCount++;
                    Debug.WriteLine(ImagesCount + ". " + name);

                }

                if (TrainedFaces.Count() > 0)
                {
                    // recognizer = new EigenFaceRecognizer(ImagesCount,Threshold);
                    recognizer = new EigenFaceRecognizer(ImagesCount, Threshold);
                    recognizer.Train(TrainedFaces.ToArray(), PersonsLabes.ToArray());

                    isTrained = true;
                    //Debug.WriteLine(ImagesCount);
                    //Debug.WriteLine(isTrained);
                    return true;
                }
                else
                {
                    isTrained = false;
                    return false;
                }
            }
            catch (Exception ex)
            {
                isTrained = false;
                MessageBox.Show("Error in Train Images: " + ex.Message);
                return false;
            }

        }
    }
}

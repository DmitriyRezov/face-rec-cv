using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Xamarin.Essentials;
using Xamarin.Forms;
using Path = Xamarin.Forms.Shapes.Path;
using Google.Apis.FirebaseML.v1;

namespace ProjectPracticalWorkApp
{
    public class Question : ContentPage
    {
        //Страница, на которой должен быть вопрос, насчёт того
        //хочет ли человек, чтобы его внесли в базу
        //Но пока здесь находится тестовая часть с получением изображения пользователя

        private Label QuestionText;
        private Image QuestionImage;
        public ImageButton GoBackButton;
        public ImageButton QuestionButton;

        Image img;
        Button takePhotoBtn;
        Button getPhotoBtn;

        public Question()
        {

            takePhotoBtn = new Button { Text = "Сделать фото" };
            getPhotoBtn = new Button { Text = "Выбрать фото" };
            img = new Image();
            getPhotoBtn.Clicked += GetPhotoAsync;
            //takePhotoBtn.Clicked += TakePhotoAsync;

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                Children = {
                    new StackLayout
                    {
                        Children = {takePhotoBtn, getPhotoBtn},
                        Orientation =StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.CenterAndExpand
                    },
                    img
                }
            };

            //Код с вопросом
            /*
            QuestionText = new Label()
            {
                Text = "Желаете ли вы \n добавить своё фото \n в базу данных?",
                TextColor = Color.FromRgb(169, 169, 169),
                FontSize = 22,
                FontFamily = "Noto Sans Gujarati",
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                Margin = new Thickness(0, -10, 0, 0),
            };

            QuestionImage = new Image()
            {
                Source = "QuestionImage.png",
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 10, 0, 0),
            };

            QuestionButton = new ImageButton()
            {
                Source = "Registration.png",
                Margin = new Thickness(0, 20, 0, 0),
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.Center,
            };

            GoBackButton = new ImageButton()
            {
                Source = "GoBack.png",
                Margin = new Thickness(0, 15, 0, 0),
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.Center,
            };

            Content = new StackLayout()
            {
                Children =
                {
                    new Image()
                    {
                        Source = "QuestionTop.png",
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        Margin = new Thickness(-60, -250, -60, 0),
                        BackgroundColor = Color.Transparent,
                    },
                    QuestionText,
                    QuestionImage,
                    QuestionButton,
                    GoBackButton,
                },

                BackgroundColor = Color.FromRgb(29, 29, 29),
            };*/
        }

        async void GetPhotoAsync(object sender, EventArgs e)
        {
            try
            {
                // выбираем фото
                var photo = await MediaPicker.PickPhotoAsync();
                // загружаем в ImageView
                img.Source = ImageSource.FromFile(photo.FullPath);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }

        /*
        async void TakePhotoAsync(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = $"xamarin.{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.png"
                });

                // для примера сохраняем файл в локальном хранилище
                //var newFile = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);
                //using (var stream = await photo.OpenReadAsync())
                //using (var newStream = File.OpenWrite(newFile))
                    //await stream.CopyToAsync(newStream);

                // загружаем в ImageView
                img.Source = ImageSource.FromFile(photo.FullPath);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }
        */
    }
}
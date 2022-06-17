using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace ProjectPracticalWorkApp
{
    public class StartPage : ContentPage
    {
        //Начальная страница

        public ImageButton AuthoriseButton;
        public ImageButton RegistrationButton;

        public StartPage()
        {
            //Кнопка авторизации
            AuthoriseButton = new ImageButton()
            {
                Source = "Authorise.png",
                Margin = new Thickness(0, 100, 0, 10),
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.Center,
            };

            //Кнопка регистрации
            RegistrationButton = new ImageButton()
            {
                Source = "Registration.png",
                Margin = new Thickness(0, 15, 0, 10),
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.Center,
            };

            //Основной текстовый контент на странице 
            Content = new StackLayout()
            {
                Children =
                {
                    new Label()
                    {
                        Text = "Pelemewki Team Project",
                        TextColor = Color.White,
                        FontSize = 28,
                        FontFamily = "Noto Sans Gujarati",
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalTextAlignment = TextAlignment.Start,
                        Margin = new Thickness(0,15, 0, 0),
                    },

                    new Label()
                    {
                        Text = "Здравствуйте,\n зарегистрируйтесь или \n войдите в аккаунт, тогда мы \n сможем поговорить с вами",
                        TextColor = Color.White,
                        FontSize = 28,
                        FontFamily = "Noto Sans Gujarati",
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalTextAlignment = TextAlignment.End,
                        Margin = new Thickness(0,100, 0, 0),
                    },

                    AuthoriseButton,
                    RegistrationButton,
                },
                BackgroundColor = Color.FromRgb(29, 29, 29),
            };
        }
    }
}
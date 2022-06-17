using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;

namespace ProjectPracticalWorkApp
{
    public class Authorise : ContentPage
    {
        //Страница авторизации

        public Entry Login;
        public Entry Password;
        public ImageButton AuthoriseButton;
        public ImageButton GoBackButton;

        public Authorise()
        {
            //Поле ввести эмейл
            Login = new Entry()
            {
                Placeholder = "Введите email",
                PlaceholderColor = Color.FromRgb(169, 169, 169),
                TextColor = Color.FromRgb(169, 169, 169),
                FontSize = 22,
                FontFamily = "Noto Sans Gujarati",
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Start,
                Margin = new Thickness(20, -30, 0, 0),
            };

            //Поле ввести пароль
            Password = new Entry()
            {
                Placeholder = "Введите пароль",
                PlaceholderColor = Color.FromRgb(169, 169, 169),
                TextColor = Color.FromRgb(169, 169, 169),
                FontSize = 22,
                FontFamily = "Noto Sans Gujarati",
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Start,
                Margin = new Thickness(20, 10, 0, 0),
            };

            //Кнопка авторизоваться
            AuthoriseButton = new ImageButton()
            {
                Source = "Authorise.png",
                Margin = new Thickness(0, 30, 0, 0),
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.Center,
            };

            //Кнопка назад
            GoBackButton = new ImageButton()
            {
                Source = "GoBack.png",
                Margin = new Thickness(0, 15, 0, 0),
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.Center,
            };

            //Основной контент на странице 
            Content = new StackLayout()
            {
                Children =
                {
                    new Image()
                    {
                        Source = "AuthoriseTop.png",
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        Margin = new Thickness(-60, -250, -60, 0),
                        BackgroundColor = Color.Transparent,
                    },

                    Login,
                    Password,
                    AuthoriseButton,
                    GoBackButton,
                },

                BackgroundColor = Color.FromRgb(29,29,29),
            };
        }
    }
}
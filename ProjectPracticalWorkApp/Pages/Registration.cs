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
    public class Registration : ContentPage
    {
        //Страница регистрации
        public Entry Login;
        public Entry NickName;
        public Entry Password;
        public ImageButton GoBackButton;
        public ImageButton RegistrationButton;

        public Registration()
        {
            //Поле ввести логин
            Login = new Entry()
            {
                Placeholder = "Введите email",
                PlaceholderColor = Color.FromRgb(169, 169, 169),
                TextColor = Color.FromRgb(169, 169, 169),
                FontSize = 22,
                FontFamily = "Noto Sans Gujarati",
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Start,
                Margin = new Thickness(20, 10, 0, 0),
            };

            //Поле ввести ник
            NickName = new Entry()
            {
                Placeholder = "Введите никнэйм",
                PlaceholderColor = Color.FromRgb(169, 169, 169),
                TextColor = Color.FromRgb(169, 169, 169),
                FontSize = 22,
                FontFamily = "Noto Sans Gujarati",
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Start,
                Margin = new Thickness(20, 10, 0, 0),
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

            //Кнопка зарегистрироваться
            RegistrationButton = new ImageButton()
            {
                Source = "Registration.png",
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

            //Основной контент
            Content = new StackLayout()
            {
                Children =
                {
                    new Image()
                    {
                        Source = "RegistrationTop.png",
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        Margin = new Thickness(-60, -250, -60, 0),
                        BackgroundColor = Color.Transparent,
                    },

                    Login,
                    NickName,
                    Password,
                    RegistrationButton,
                    GoBackButton,
                },

                BackgroundColor = Color.FromRgb(29, 29, 29),
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ProjectPracticalWorkApp
{
    public class Navigation : ContentPage
    {
        //Страница навигации
        //На этой странице находится переход к странице с вопросом
        //Это просто промежуточная страничка

        public Label NickName;
        public Label TextInfo;
        public ImageButton QuestionButton;

        public Navigation()
        {
            NickName = new Label()
            {
                Text = "Вы не ввели никнэйм",
                TextColor = Color.FromRgb(169, 169, 169),
                HorizontalTextAlignment = TextAlignment.End,
                Margin = new Thickness(0, 10, 20, 0),
                FontSize = 18,
            };

            TextInfo = new Label()
            {
                Text = "Выберете действие:",
                TextColor = Color.FromRgb(169,169,169),
                Margin = new Thickness(0, 30, 0, 0),
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 28,
            };

            QuestionButton = new ImageButton()
            {
                Source = "Registration.png",
                Margin = new Thickness(0, 100, 0, 0),
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.Center,
            };

            Content = new StackLayout
            {
                Children =
                {
                    NickName,
                    TextInfo,
                    QuestionButton,
                },

                BackgroundColor = Color.FromRgb(29,29,29),
            };
        }
    }
}
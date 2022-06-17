using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Xamarin.Essentials;
using Firebase.Auth;
using Xamarin.Forms;

namespace ProjectPracticalWorkApp
{
    public class App : Application
    {
        private StartPage startPage;
        private Authorise authorise;
        private Registration registration;
        private Question question;
        private Navigation navigation;

        public string WebApiKey = "AIzaSyCq_o0pkRt5dTlpqUgJBr5f2sC0we3ByCQ";

        //инициализируем переменные, здесь каждая переменная - страница приложения
        public App()
        {
            startPage = new StartPage();
            authorise = new Authorise();
            registration = new Registration();
            question = new Question();
            navigation = new Navigation();
            MainPage = startPage;
            InitialiseClicks();
        }

        //инициализируем кнопки
        private void InitialiseClicks()
        {
            startPage.AuthoriseButton.Clicked += (sender, args) => MainPage = authorise;
            startPage.RegistrationButton.Clicked += (sender, args) => MainPage = registration;

            authorise.GoBackButton.Clicked += (sender, args) => MainPage = startPage;
            registration.GoBackButton.Clicked += (sender, args) => MainPage = startPage;
            //question.GoBackButton.Clicked += (sender, args) => MainPage = navigation;

            authorise.AuthoriseButton.Clicked += (AuthoriseButtonClicked);
            registration.RegistrationButton.Clicked += (RegistrationButtonClicked);
            navigation.QuestionButton.Clicked += (sender, args) => MainPage = question; 
            //question.QuestionButton.Clicked += (TurnOnCamera);

        }

        //Кнопка для регистрации пользователя
        private async void RegistrationButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebApiKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(registration.Login.Text, registration.Password.Text, registration.NickName.Text);
                await this.MainPage.DisplayAlert("Alert", "Новый пользователь зарегистрирован", "Ok");
                MainPage = authorise;
            }
            catch (Exception ex)
            {
                await this.MainPage.DisplayAlert("Alert", ex.Message, "Ok");
            }
        }

        //Кнопка для авторизации пользователя
        private async void AuthoriseButtonClicked(object sender, EventArgs e)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebApiKey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(authorise.Login.Text, authorise.Password.Text);
                await this.MainPage.DisplayAlert("Alert", "Вы успешно вошли", "Ok");
                navigation.NickName.Text = auth.User.DisplayName;
                MainPage = navigation;
            }
            catch
            {
                await this.MainPage.DisplayAlert("Alert", "Неверный логин или пароль", "Ok");
            }
        }
    }
}
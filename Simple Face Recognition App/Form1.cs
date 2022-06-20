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
using Firebase.Auth;

namespace Simple_Face_Recognition_App
{
    public partial class Form1 : Form
    {
        public static readonly int WidthScreen = Screen.PrimaryScreen.WorkingArea.Width;
        public static readonly int HeightScreen = Screen.PrimaryScreen.WorkingArea.Height;
        private string WebApiKey = "AIzaSyCq_o0pkRt5dTlpqUgJBr5f2sC0we3ByCQ";
        private Scanning scanning;
        private StartPage startPage;
        private Navigation navigation;
        private Authorise authorise;
        private Registration registration;
        private Drawer drawer;
        private bool UserGoBack;

        public Form1()
        {
            InitializeComponent();
            InitialiseForm();
            InitialiseObjects();
            InitialiseClicks();
            Controls.Add(startPage.Window);
        }

        public void InitialiseForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
            ControlBox = false;
            KeyPreview = true;
            this.KeyDown += (sender, args) => DownKey(sender, args);
            this.Paint += new PaintEventHandler(OnPaint);
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        private void InitialiseObjects()
        {
            scanning = new Scanning();
            startPage = new StartPage();
            authorise = new Authorise();
            registration = new Registration();
            navigation = new Navigation();
            drawer = new Drawer();
        }

        private void InitialiseClicks()
        {
            startPage.Authorise.MouseClick += (sender, args) =>
            {
                Controls.Remove(startPage.Window);
                Controls.Add(authorise.Window);
            };
            startPage.Exit.MouseClick += (sender, args) => this.Close();

            startPage.Registration.MouseClick += (sender, args) =>
            {
                Controls.Remove(startPage.Window);
                Controls.Add(registration.Window);
            };

            authorise.AuthoriseButton.MouseClick += (sender, args) => AuthoriseButtonClicked(sender, args);
            authorise.Login.GotFocus += (sender, args) => authorise.Login.Text = "";
            authorise.Login.LostFocus += (sender, args) =>
            {
                if (authorise.Login.Text == "")
                    authorise.Login.Text = "Введите email";
            };
            authorise.Password.GotFocus += (sender, args) => authorise.Password.Text = "";
            authorise.Password.LostFocus += (sender, args) =>
            {
                if (authorise.Password.Text == "")
                    authorise.Password.Text = "Введите пароль";
            };
            authorise.GoBackButton.MouseClick += (sender, args) =>
            {
                Controls.Remove(authorise.Window);
                Controls.Add(startPage.Window);
            };

            registration.RegistrationButton.MouseClick += (sender, args) => RegistrationButtonClicked(sender, args);
            registration.Login.GotFocus += (sender, args) => registration.Login.Text = "";
            registration.Login.LostFocus += (sender, args) =>
            {
                if (registration.Login.Text == "")
                    registration.Login.Text = "Введите email";
            };
            registration.Password.GotFocus += (sender, args) => registration.Password.Text = "";
            registration.Password.LostFocus += (sender, args) =>
            {
                if (registration.Password.Text == "")
                    registration.Password.Text = "Введите пароль";
            };
            registration.GoBackButton.MouseClick += (sender, args) =>
            {
                Controls.Remove(registration.Window);
                Controls.Add(startPage.Window);
            };

            navigation.Exit.MouseClick += (sender, args) => this.Close();
            navigation.Scanning.MouseClick += (sender, args) =>
            {
                Controls.Remove(navigation.Window);
                Controls.Add(scanning.Window);
            };

            scanning.btnCapture.MouseClick += (sender, args) => scanning.btnCapture_Click(sender, args);
            scanning.btnAddPerson.MouseClick += (sender, args) => scanning.btnAddPerson_Click(sender, args);
            scanning.btnDetectFaces.MouseClick += (sender, args) => scanning.btnDetectFaces_Click(sender, args);
            scanning.btnTrain.MouseClick += (sender, args) => scanning.btnTrain_Click(sender, args);
            scanning.goBack.MouseClick += (sender, args) =>
            {
                Controls.Remove(scanning.Window);
                Controls.Add(navigation.Window);
                if (scanning.videoCapture != null)
                {
                    scanning.videoCapture.Stop();
                    scanning.videoCapture.Dispose();
                }
            };
        }

        public async void RegistrationButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebApiKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(registration.Login.Text, registration.Password.Text);
                MessageBox.Show("Новый пользователь зарегистрирован", "Внимание!");
                Controls.Remove(registration.Window);
                Controls.Add(authorise.Window);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Внимание!");
            }
        }

        public async void AuthoriseButtonClicked(object sender, EventArgs e)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebApiKey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(authorise.Login.Text, authorise.Password.Text);
                MessageBox.Show("Вы успешно вошли", "Внимание!");
                Controls.Remove(authorise.Window);
                Controls.Add(navigation.Window);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Неверный логин или пароль", "Внимание!");
            }
        }

        public void DownKey(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            if (Controls.Contains(scanning.Window) || Controls.Contains(authorise.Window))
                drawer.DrawMapScanning(g);
            if (Controls.Contains(navigation.Window) || Controls.Contains(registration.Window) || Controls.Contains(startPage.Window))
                drawer.DrawMapNavigation(g);
        }
    }
}

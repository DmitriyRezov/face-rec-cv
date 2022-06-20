using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Face_Recognition_App
{
    public class Authorise
    {
        public TextBox Login;
        public TextBox Password;
        public PictureBox AuthoriseButton;
        public PictureBox GoBackButton;
        private PictureBox Hello;
        private TableLayoutPanel WindowForButtons;
        private TableLayoutPanel WindowForText;
        private TableLayoutPanel WindowForElement;
        private Image RegIm = global::Simple_Face_Recognition_App.Resource1.Authorise__2_;
        private Image GoBackIm = global::Simple_Face_Recognition_App.Resource1.Back;
        private Image HelloImage = global::Simple_Face_Recognition_App.Resource1.Hello;
        public TableLayoutPanel Window;

        public Authorise()
        {
            Window = new TableLayoutPanel()
            {
                BackColor = Color.FromArgb(240, 29, 29, 29),
                Dock = DockStyle.Fill,
            };

            WindowForButtons = new TableLayoutPanel()
            {
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
            };

            WindowForText = new TableLayoutPanel()
            {
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
            };

            WindowForElement = new TableLayoutPanel()
            {
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
            };

            //Поле ввести эмейл
            Login = new TextBox()
            {
                Text = "Введите email",
                ForeColor = Color.FromArgb(169, 169, 169),
                Font = new Font(FontFamily.GenericSansSerif, 20),
                TextAlign = HorizontalAlignment.Center,
                Margin = new Padding(WindowForText.Size.Width / 2, 0, WindowForText.Size.Width / 2, 0),
                Dock = DockStyle.Fill,
            };

            //Поле ввести пароль
            Password = new TextBox()
            {
                Text = "Введите пароль",
                ForeColor = Color.FromArgb(169, 169, 169),
                Font = new Font(FontFamily.GenericSansSerif, 20),
                TextAlign = HorizontalAlignment.Center,
                Margin = new Padding(WindowForText.Size.Width / 2, 20, WindowForText.Size.Width / 2, 0),
                Dock = DockStyle.Fill,
            };

            //Кнопка авторизоваться
            AuthoriseButton = new PictureBox()
            {
                Image = RegIm,
                Size = Size.Subtract(GoBackIm.Size, new Size(60, 15)),
                Margin = new Padding(120, 20, 0, 0),
                SizeMode = PictureBoxSizeMode.StretchImage,
            };

            //Кнопка назад
            GoBackButton = new PictureBox()
            {
                Image = GoBackIm,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = Size.Subtract(GoBackIm.Size, new Size(60, 15)),
                Margin = new Padding(20, 20, 0, 0),
            };

            Hello = new PictureBox()
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = HelloImage,
            };

            WindowForText.RowStyles.Add(new RowStyle(SizeType.Absolute, 300));
            WindowForText.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            WindowForText.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            WindowForText.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            WindowForText.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80));
            WindowForText.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));

            WindowForText.Controls.Add(new Panel(), 0, 0);
            WindowForText.Controls.Add(new Panel(), 2, 0);
            WindowForText.Controls.Add(new Panel(), 2, 1);
            WindowForText.Controls.Add(new Panel(), 0, 1);
            WindowForText.Controls.Add(Login, 1, 1);
            WindowForText.Controls.Add(Password, 1, 2);

            WindowForButtons.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
            WindowForButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 60));
            WindowForButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 30));
            WindowForButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            WindowForButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            WindowForButtons.Controls.Add(new Panel(), 0, 0);
            WindowForButtons.Controls.Add(new Panel(), 1, 0);
            WindowForButtons.Controls.Add(AuthoriseButton, 0, 1);
            WindowForButtons.Controls.Add(GoBackButton, 1, 1);

            WindowForElement.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            WindowForElement.RowStyles.Add(new RowStyle(SizeType.Percent, 50));

            WindowForElement.Controls.Add(WindowForText, 0, 0);
            WindowForElement.Controls.Add(WindowForButtons, 0, 1);

            Window.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            Window.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            Window.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));

            Window.Controls.Add(Hello, 0, 0);
            Window.Controls.Add(WindowForElement, 1, 0);
        }
    }
}

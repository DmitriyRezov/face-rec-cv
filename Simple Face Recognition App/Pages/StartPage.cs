using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Emgu.CV.Structure;
using Firebase.Auth;
using ContentAlignment = System.Drawing.ContentAlignment;

namespace Simple_Face_Recognition_App
{
    public class StartPage
    {
        public TableLayoutPanel Window;
        private Label FirstLabel;
        private Label SecondLabel;
        public Label Authorise;
        public Label Registration;
        public Label Exit;
        private TableLayoutPanel WindowForButtons;
        private TableLayoutPanel WindowForExit;
        private Image AuthIm = global::Simple_Face_Recognition_App.Resource1.Authorise__2_;
        private Image RegIm = global::Simple_Face_Recognition_App.Resource1.Registration__2_;
        public Image ExitImage = global::Simple_Face_Recognition_App.Resource1.BlackExit;

        public StartPage()
        {
            Window = new TableLayoutPanel()
            {
                BackColor = Color.FromArgb(240, 29,29,29),
                Dock = DockStyle.Fill,
            };

            FirstLabel = new Label()
            {
                Text = "Pelemewki Team Project",
                TextAlign = ContentAlignment.TopCenter,
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Font = new Font(FontFamily.GenericSansSerif, 20),
                Dock = DockStyle.Fill,
                Padding = new Padding(0, 30, 0, 0)
            };

            SecondLabel = new Label()
            {
                Text = "Здравствуйте, зарегистрируйтесь или войдите в \n аккаунт, тогда мы сможем поговорить с вами",
                TextAlign = ContentAlignment.TopCenter,
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Font = new Font(FontFamily.GenericSansSerif, 30),
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 150, 0, 0)
            };

            Authorise = new Label()
            {
                Image = AuthIm,
                Size = AuthIm.Size,
                ImageAlign = ContentAlignment.TopRight,
                Margin = new Padding(100, 20, 0, 0),
            };

            Registration = new Label()
            {
                Image = RegIm,
                Size = RegIm.Size,
                ImageAlign = ContentAlignment.TopLeft,
                Margin = new Padding(0, 20, 20, 0)
            };

            WindowForButtons = new TableLayoutPanel()
            {
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
            };

            WindowForExit = new TableLayoutPanel()
            {
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
            };

            Exit = new Label()
            {
                Image = ExitImage,
                Size = ExitImage.Size,
                ImageAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(WindowForExit.Size.Width / 2, 0, WindowForExit.Size.Width / 2, 0),
            };

            Window.RowStyles.Add(new RowStyle(SizeType.Absolute, 100));
            Window.RowStyles.Add(new RowStyle(SizeType.Percent, 40));
            Window.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
            Window.RowStyles.Add(new RowStyle(SizeType.Percent, 40));

            Window.Controls.Add(FirstLabel, 0, 0);
            Window.Controls.Add(SecondLabel, 0, 1);
            Window.Controls.Add(WindowForButtons, 0, 2);
            Window.Controls.Add(WindowForExit, 0, 3);

            WindowForButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            WindowForButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            WindowForButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            WindowForButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            WindowForButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));

            WindowForButtons.Controls.Add(new Panel(), 0, 0);
            WindowForButtons.Controls.Add(Authorise, 1, 0);
            WindowForButtons.Controls.Add(Registration, 2, 0);
            WindowForButtons.Controls.Add(new Panel(), 3, 0);

            WindowForExit.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            WindowForExit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            WindowForExit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            WindowForExit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));

            WindowForExit.Controls.Add(Exit, 1, 0);
            WindowForExit.Controls.Add(new Panel(), 0, 0);
            WindowForExit.Controls.Add(new Panel(), 2, 0);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Face_Recognition_App
{ 
    public class Navigation
    {
        public TableLayoutPanel Window;
        public LinkLabel Scanning;
        public Label Exit;
        public Image ExitImage = global::Simple_Face_Recognition_App.Resource1.Exit__2_;
        private int RectWidth = 700;
        private int RectHeight = 700;

        public Navigation()
        {
            Window = new TableLayoutPanel()
            {
                Location = new Point(Form1.WidthScreen / 2 - RectWidth / 2, Form1.HeightScreen / 2 - RectHeight / 2),
                Size = new Size(RectWidth, RectHeight),
                BackColor = Color.FromArgb(240, 29, 29, 29),
            };

            Scanning = new LinkLabel()
            {
                Dock = DockStyle.Fill,
                Text = "Перейти к сканированию",
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(FontFamily.GenericSansSerif, 26),
                LinkColor = Color.White,
                ActiveLinkColor = Color.FromArgb(169, 169, 169),
            };

            Exit = new Label()
            {
                Dock = DockStyle.Fill,
                Image = ExitImage,
                Size = ExitImage.Size,
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(FontFamily.GenericSansSerif, 26),
            };

            Window.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
            Window.RowStyles.Add(new RowStyle(SizeType.Absolute, 150));
            Window.RowStyles.Add(new RowStyle(SizeType.Absolute, 150));
            Window.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
            Window.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5));
            Window.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 350));
            Window.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5));

            Window.Controls.Add(new Panel() {BackColor = Color.Transparent}, 2, 3);
            Window.Controls.Add(Scanning, 1, 1);
            Window.Controls.Add(Exit, 1, 2);
            Window.Controls.Add(new Panel() { BackColor = Color.Transparent }, 2, 0);
        }
    }
}

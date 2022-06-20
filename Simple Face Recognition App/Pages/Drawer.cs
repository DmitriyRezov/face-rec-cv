using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Face_Recognition_App
{
    public class Drawer
    {
        private Image navigationBackImage;
        private Image scanningBackImage;

        public Drawer()
        {
            navigationBackImage = global::Simple_Face_Recognition_App.Resource1.eschyo_shtuka2;
            scanningBackImage = global::Simple_Face_Recognition_App.Resource1.eschyo_shtuka;
        }
        public void DrawMapNavigation(Graphics g)
        {
            g.DrawImage(navigationBackImage, 0, 0, Form1.WidthScreen, Form1.HeightScreen + 100);
        }

        public void DrawMapScanning(Graphics g)
        {
            g.DrawImage(scanningBackImage, 0, 0, Form1.WidthScreen, Form1.HeightScreen + 100);
        }
    }
}

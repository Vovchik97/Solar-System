using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SolarSystem
{
    internal class Cosmic_Bodies
    {
        public Point center;
        public Point movingCenter;
        public int radius;
        public Graphics graphics;
        public Color bgcolor;

        public Cosmic_Bodies(Point center, Point movingCenter, int radius, Graphics graphics, Color bgcolor)
        {
            this.center = center;
            this.movingCenter = movingCenter;
            this.radius = radius;
            this.graphics = graphics;
            this.bgcolor = bgcolor;
        }

        public void draw()
        {
            graphics.FillPie(new SolidBrush(bgcolor), center.X - radius, center.Y - radius, 2 * radius, 2 * radius, 0, 360);
        }
    }
}

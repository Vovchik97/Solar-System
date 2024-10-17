using System;
using System.Drawing;
using System.Threading;

namespace SolarSystem
{

    class Space
    {
        public Graphics graphics;
        public Cosmic_Bodies sun, merkury, venera, earth, moon, mars, fobos, deimos;
        public int sun_radius, merkury_radius, venera_radius, earth_radius, moon_radius, mars_radius, fobos_radius, deimos_radius;
        public Point screenCenter;
        public bool isMoving = false;
        public double degrees_angle = 3.14 / 180; 
        public double radians_angle;
        public double radians_angle_original;

        public int orbit_merkury = 58;
        public int orbit_venera = 108;
        public int orbit_earth = 150;
        public int orbit_moon = 15;
        public int orbit_mars = 228;
        public int orbit_fobos = 7;
        public int orbit_deimos = 12;

        public int orbit_merkury_original = 58;
        public int orbit_venera_original = 108;
        public int orbit_earth_original = 150;
        public int orbit_moon_original = 15;
        public int orbit_mars_original = 228;
        public int orbit_fobos_original = 7;
        public int orbit_deimos_original = 12;

        public Space(Graphics graphics, Point screenCenter)
        {
            this.graphics = graphics;
            this.screenCenter = screenCenter;
            sun = new Cosmic_Bodies(screenCenter, screenCenter, 20, graphics, Color.Yellow);
            merkury = new Cosmic_Bodies(new Point(screenCenter.X, screenCenter.Y), screenCenter, 3, graphics, Color.Gray);
            venera = new Cosmic_Bodies(new Point(screenCenter.X, screenCenter.Y), screenCenter, 5, graphics, Color.White);
            earth = new Cosmic_Bodies(new Point(screenCenter.X, screenCenter.Y), screenCenter, 6, graphics, Color.Blue);
            moon = new Cosmic_Bodies(new Point(earth.center.X, earth.center.Y), earth.center, 2, graphics, Color.DarkGray);
            mars = new Cosmic_Bodies(new Point(screenCenter.X, screenCenter.Y), screenCenter, 4, graphics, Color.Red);
            fobos = new Cosmic_Bodies(new Point(mars.center.X, mars.center.Y), mars.center, 1, graphics, Color.Gray);
            deimos = new Cosmic_Bodies(new Point(mars.center.X, mars.center.Y), mars.center, 1, graphics, Color.White);
            radians_angle = degrees_angle;

            sun_radius = sun.radius;
            merkury_radius = merkury.radius;
            venera_radius = venera.radius;
            earth_radius = earth.radius;
            moon_radius = moon.radius;
            mars_radius = mars.radius;
            fobos_radius = fobos.radius;
            deimos_radius = deimos.radius;

            radians_angle_original = radians_angle;

        }
        public void draw(bool isMoving)
        {
            this.IsMoving = isMoving;
            ThreadStart threadStart = new ThreadStart(threadDraw);
            Thread thread = new Thread(threadStart);
            thread.Start();
        }
        public void drawBg()
        {
            graphics.Clear(Color.Black); 
        } 
        public void threadDraw()
        {
            while (true)
            {
                drawBg();
                sun.draw();
                merkury.center.X = screenCenter.X + (int)(orbit_merkury * Math.Cos(radians_angle * 0.416));
                merkury.center.Y = screenCenter.Y + (int)(orbit_merkury * Math.Sin(radians_angle * 0.416));
                merkury.draw();
                venera.center.X = screenCenter.X + (int)(orbit_venera * Math.Cos(radians_angle * 0.250));
                venera.center.Y = screenCenter.Y + (int)(orbit_venera * Math.Sin(radians_angle * 0.250));
                venera.draw();
                earth.center.X = screenCenter.X + (int)(orbit_earth * Math.Cos(radians_angle * 0.1));
                earth.center.Y = screenCenter.Y + (int)(orbit_earth * Math.Sin(radians_angle * 0.1));
                earth.draw();
                moon.movingCenter = earth.center;
                moon.center.X = earth.center.X + (int)(orbit_moon * Math.Cos(-radians_angle * 1.3));
                moon.center.Y = earth.center.Y + (int)(orbit_moon * Math.Sin(-radians_angle * 1.3));
                moon.draw();
                mars.center.X = screenCenter.X + (int)(orbit_mars * Math.Cos(radians_angle * 0.053));
                mars.center.Y = screenCenter.Y + (int)(orbit_mars * Math.Sin(radians_angle * 0.053));
                mars.draw();
                fobos.movingCenter = mars.center;
                deimos.movingCenter = mars.center;
                fobos.center.X = mars.center.X + (int)(orbit_fobos * Math.Cos(-radians_angle * 114.4));
                fobos.center.Y = mars.center.Y + (int)(orbit_fobos * Math.Sin(-radians_angle * 114.4));
                fobos.draw();
                deimos.center.X = mars.center.X + (int)(orbit_deimos * Math.Cos(-radians_angle * 30.4));
                deimos.center.Y = mars.center.Y + (int)(orbit_deimos * Math.Sin(-radians_angle * 30.4));
                deimos.draw();
                radians_angle -= degrees_angle;
                Thread.Sleep(25);
                if (!IsMoving)
                    break;
            }
        }

        public void reset_draw()
        {
            drawBg();
            sun.draw();
            merkury.center.X = screenCenter.X + (int)(orbit_merkury * Math.Cos(radians_angle_original * 0.416));
            merkury.center.Y = screenCenter.Y + (int)(orbit_merkury * Math.Sin(radians_angle_original * 0.416));
            merkury.draw();
            venera.center.X = screenCenter.X + (int)(orbit_venera * Math.Cos(radians_angle_original * 0.250));
            venera.center.Y = screenCenter.Y + (int)(orbit_venera * Math.Sin(radians_angle_original * 0.250));
            venera.draw();
            earth.center.X = screenCenter.X + (int)(orbit_earth * Math.Cos(radians_angle_original * 0.1));
            earth.center.Y = screenCenter.Y + (int)(orbit_earth * Math.Sin(radians_angle_original * 0.1));
            earth.draw();
            moon.movingCenter = earth.center;
            moon.center.X = earth.center.X + (int)(orbit_moon * Math.Cos(-radians_angle_original * 1.3));
            moon.center.Y = earth.center.Y + (int)(orbit_moon * Math.Sin(-radians_angle_original * 1.3));
            moon.draw();
            mars.center.X = screenCenter.X + (int)(orbit_mars * Math.Cos(radians_angle_original * 0.053));
            mars.center.Y = screenCenter.Y + (int)(orbit_mars * Math.Sin(radians_angle_original * 0.053));
            mars.draw();
            fobos.movingCenter = mars.center;
            deimos.movingCenter = mars.center;
            fobos.center.X = mars.center.X + (int)(orbit_fobos * Math.Cos(-radians_angle_original * 114.4));
            fobos.center.Y = mars.center.Y + (int)(orbit_fobos * Math.Sin(-radians_angle_original * 114.4));
            fobos.draw();
            deimos.center.X = mars.center.X + (int)(orbit_deimos * Math.Cos(-radians_angle_original * 30.4));
            deimos.center.Y = mars.center.Y + (int)(orbit_deimos * Math.Sin(-radians_angle_original * 30.4));
            deimos.draw();
            radians_angle = radians_angle_original;
        }


        public bool IsMoving
        {

            get { return isMoving; }
            set { isMoving = value; }
        }

        public double D_angle
        {
            get { return degrees_angle; }
            set { degrees_angle = value; }
        }
    }
}


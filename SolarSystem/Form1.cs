using System;
using System.Drawing;
using System.Windows.Forms;

namespace SolarSystem
{

    public partial class Form1 : Form
    {
        private Space space;
        private bool isMoving = false;
        private double i = 1;


        public Form1()
        {
            InitializeComponent();
            space = new Space(this.pictureBox1.CreateGraphics(), new Point(this.pictureBox1.Width / 2, this.pictureBox1.Height / 2));
            space.drawBg();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Старт")
            {
                if (!isMoving)
                    isMoving = true;
                space.draw(isMoving);
                button1.Text = "Стоп";
                button4.Enabled = false;


                label1.Text = "Скорость: " + i + "x";
            }
            else 
            {
                space.IsMoving = false;
                isMoving = false;
                label1.Text = "";
                button1.Text = "Старт";
                button4.Enabled = true;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isMoving)
            {
                i = i * 2;
                space.D_angle = 2.0 * space.D_angle;
                label1.Text = "Скорость: " + i + "x";
            }
            else
            {
                label1.Text = "";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (isMoving)
            {
                i = i / 2.0;
                space.D_angle = space.D_angle / 2.0;
                label1.Text = "Скорость: " + i + "x";
            }
            else
            {
                label1.Text = "";
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            space.sun.radius = space.sun_radius * trackBar1.Value;
            space.merkury.radius = space.merkury_radius * trackBar1.Value;
            space.venera.radius = space.venera_radius * trackBar1.Value;
            space.earth.radius = space.earth_radius * trackBar1.Value;
            space.moon.radius = space.moon_radius * trackBar1.Value;
            space.mars.radius = space.mars_radius * trackBar1.Value;
            space.fobos.radius = space.fobos_radius * trackBar1.Value;
            space.deimos.radius = space.deimos_radius * trackBar1.Value;

            space.orbit_merkury = space.orbit_merkury_original * trackBar1.Value;
            space.orbit_venera = space.orbit_venera_original * trackBar1.Value;
            space.orbit_earth = space.orbit_earth_original * trackBar1.Value;
            space.orbit_moon = space.orbit_moon_original * trackBar1.Value;
            space.orbit_mars = space.orbit_mars_original * trackBar1.Value;
            space.orbit_fobos = space.orbit_fobos_original * trackBar1.Value;
            space.orbit_deimos = space.orbit_deimos_original * trackBar1.Value;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            i = 1;
            space.degrees_angle = 3.14 / 180;
            trackBar1.Value = 1;
            space.sun.radius = space.sun_radius;
            space.merkury.radius = space.merkury_radius;
            space.venera.radius = space.venera_radius;
            space.earth.radius = space.earth_radius;
            space.moon.radius = space.moon_radius;
            space.mars.radius = space.mars_radius;
            space.fobos.radius = space.fobos_radius;
            space.deimos.radius = space.deimos_radius;

            space.orbit_merkury = space.orbit_merkury_original;
            space.orbit_venera = space.orbit_venera_original;
            space.orbit_earth = space.orbit_earth_original;
            space.orbit_moon = space.orbit_moon_original;
            space.orbit_mars = space.orbit_mars_original;
            space.orbit_fobos = space.orbit_fobos_original;
            space.orbit_deimos = space.orbit_deimos_original;

            space.reset_draw();
        }

    }
}

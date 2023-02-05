using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics g;
        int xpos, ypos;
        bool goright, goleft, goup, godown;
        bool firstTime;

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(250, 250);
            PCT_CANVAS.Image = bmp;
            firstTime = true;
            DrawMap(0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (goleft == true)
            {
                Move(xpos, ypos, xpos - 1, ypos);
            }
            if (goright == true )
            {
                Move(xpos, ypos, xpos + 1, ypos);
            }
            if (goup == true)
            {
                Move(xpos, ypos, xpos, ypos - 1);
            }
            if (godown == true )
            {
                Move(xpos, ypos, xpos, ypos + 1);
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    goleft = true;
                    goright = false;
                    godown = false;
                    goup = false;
                    break;
                case Keys.Right:
                    goright = true;
                    goleft = false;
                    godown = false;
                    goup = false;

                    break;
                case Keys.Up:
                    goup = true;
                    goleft = false;
                    godown = false;
                    goright = false;
                    break;
                case Keys.Down:
                    godown = true;
                    goleft = false;
                    goright = false;
                    goup = false;
                    break;
                case Keys.Space:
                    break;
            }
        }

        private void DrawMap(int mov)
        {
            
             g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);
            for (int x = 0; x < Class1.map0.GetLength(0); x++)
            {
                for (int y = 0; y < Class1.map0.GetLength(1); y++)
                {
                    if (Class1.map0[y, x] != 0)
                    {
                        g.FillRectangle(new SolidBrush(Color.FromArgb(35, 35, 35)), x * 10, y * 10, 10, 10);
                    }
                    if (Class1.map0[y,x]==3)
                    {
                        g.DrawImage(Resource1.PG, x * 10, y * 10, 10, 10);
                    }
                    if (Class1.map0[y, x] == 4)
                    {
                        g.DrawImage(Resource1.RG, x * 10, y * 10, 10, 10);
                    }
                    if (Class1.map0[y, x] == 5)
                    {
                        g.DrawImage(Resource1.YG, x * 10, y * 10, 10, 10);
                    }
                    if (Class1.map0[y, x] == 6)
                    {
                        g.DrawImage(Resource1.BG, x * 10, y * 10, 10, 10);
                    }
                    if (Class1.map0[y, x] == 0)
                    {
                        g.FillRectangle(new SolidBrush(Color.FromArgb(128, 0, 128)), x * 10, y * 10, 10, 10);
                    }
                    if (Class1.map0[y, x] == 8)
                    {
                        g.DrawImage(Resource1.YDOT, x * 10, y * 10, 10, 10);
                    }
                    if (Class1.map0[y, x] == 2)
                    {
                        if (firstTime == true) {
                            g.DrawImage(Resource2.pacmanright, x * 10, y * 10, 10, 10);
                            firstTime = false;
                        }
                            

                        if (goright == true)
                        g.DrawImage(Resource2.pacmanright, x * 10, y * 10, 10, 10);

                        if (goleft == true)
                            g.DrawImage(Resource2.pacmanleft, x * 10, y * 10, 10, 10);

                        if (godown == true)
                            g.DrawImage(Resource2.pacmandown, x * 10, y * 10, 10, 10);

                        if (goup == true)
                            g.DrawImage(Resource2.pacmanup, x * 10, y * 10, 10, 10);

                        xpos = x;
                        ypos= y;
                    }
                    else
                        g.DrawRectangle(Pens.Gray, x * 10, y * 10, 10, 10);
                }
            }
            PCT_CANVAS.Invalidate();

        }

        public void Move(int oldx,int oldy,int newx, int newy)
        {
            int limy, limx;
            limy = Class1.map0.GetLength(1)-1;
            limx=Class1.map0.GetLength(0)-1;
            if (newy > limy)
            {
                Class1.map0[0, newx] = 2;
                Class1.map0[oldy, oldx] = 0;
            }
            else
            {
                if (newy < 0)
                {
                    Class1.map0[limy, newx] = 2;
                    Class1.map0[oldy, oldx] = 0;
                }
                else
                {
                    if (newx > limx)
                    {
                        Class1.map0[newy, 0] = 2;
                        Class1.map0[oldy, oldx] = 0;
                    }
                    else
                    {
                        if (newx < 0)
                        {
                            Class1.map0[newy, limx] = 2;
                            Class1.map0[oldy, oldx] = 0;
                        }
                        else
                        {
                            if (Class1.map0[newy, newx] != 1)
                            {
                                Class1.map0[oldy, oldx] = 0;
                                Class1.map0[newy, newx] = 2;
                            }
                        }

                    }
                }
            }
            

            DrawMap(1);
        }

        public void UpdateMap()
        {
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);
            for (int x = 0; x < Class1.map0.GetLength(0); x++)
            {
                for (int y = 0; y < Class1.map0.GetLength(1); y++)
                {
                    if (Class1.map0[y, x] == 2)
                    {
                        g.DrawImage(Resource1.pacman, x * 10, y * 10, 10, 10);
                       
                    }
                }
            }
        }
    }
}

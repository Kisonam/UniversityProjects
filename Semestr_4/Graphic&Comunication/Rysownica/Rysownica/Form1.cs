using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Rysownica
{
    public partial class Form1 : Form
    {
        Bitmap Bitmap;
        Graphics g;
        Point pX, pY;
        Pen pen = new Pen(Color.Black, 1);
        Pen eraser = new Pen(Color.White, 10);
        
        
        int index;
        int x, y, sX, sY,cX,cY;
        bool paint = false;


        private void pbRysownica_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            if (paint)
            {
                if (index == 3)
                {
                    graphics.DrawEllipse(pen, cX, cY, sX, sY);
                }

                if (index == 4)
                {
                    graphics.DrawRectangle(pen, cX, cY, sX, sY);
                }

                if (index == 5)
                {
                    graphics.DrawLine(pen, cX, cY, x, y);
                }
            }
            
        }
        private void pbRysownica_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            pY = e.Location;

            cX = e.X;
            cY = e.Y;
        }
        private void pbRysownica_MouseMove(object sender, MouseEventArgs e)
        {
            if (paint)
            {
                if (index == 1)
                {
                    pX = e.Location;
                    g.DrawLine(pen, pX, pY);
                    pY = pX;
                }
                if (index == 2)
                {
                    pX = e.Location;
                    g.DrawLine(eraser, pX, pY);
                    pY = pX;
                }
            }
            pbRysownica.Refresh();

            x = e.X;
            y = e.Y;

            sX = e.X - cX;
            sY = e.Y - cY;
        }
        private void pbRysownica_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;

            sX = x - cX;
            sY = y - cY;

            if (index == 3)
            {
                g.DrawEllipse(pen,cX, cY,sX,sY);
            }

            if (index == 4)
            {
                g.DrawRectangle(pen, cX, cY, sX, sY);
            }

            if (index == 5)
            {
                g.DrawLine(pen, cX, cY, x, y);
            }
        }
        private void btnPencil_Click(object sender, System.EventArgs e)
        {
            index = 1;
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            index = 2;
        }
        private void saveToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var save = new SaveFileDialog();

            save.Filter = "Image(*.jpg)|*.jpg|(*.*|*.*";

            if(save.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = Bitmap.Clone(new Rectangle(0,0, pbRysownica.Width, pbRysownica.Height), Bitmap.PixelFormat);
                bmp.Save(save.FileName, ImageFormat.Jpeg);
            }
        }
        private void clearToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            g.Clear(pbRysownica.BackColor);
            index = 0;
            pbRysownica.Refresh();
        }
        private void btnChangeColor_Click(object sender, System.EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();

            pen.Color = colorDialog.Color;
            colorDetect.BackColor = colorDialog.Color;

        }
        private void tbPenSolid_Scroll(object sender, System.EventArgs e)
        {
            pen.Width = tbPenSolid.Value;
            eraser.Width = tbPenSolid.Value;
        }

        private void pbRysownica_MouseClick(object sender, MouseEventArgs e)
        {
            if (index == 6)
            {
                Point point = set_point(pbRysownica, e.Location);
                Fill(Bitmap, point.X, point.Y, pen.Color);
            }
        }

        static Point set_point(PictureBox pictureBox, Point pt)
        {
            float pX = 1f * pictureBox.Image.Width / pictureBox.Image.Width;
            float pY = 1f * pictureBox.Image.Height / pictureBox.Image.Height;
            return new Point((int)(pt.X * pX), (int)(pt.Y * pY));
        }

        private void btnFill_Click(object sender, System.EventArgs e)
        {
            index = 6;
        }

        private void btnElipse_Click(object sender, System.EventArgs e)
        {
            index = 3;
        }
        private void btnRect_Click(object sender, System.EventArgs e)
        {
            index = 4;
        }
        private void btnLine_Click(object sender, System.EventArgs e)
        {
            index = 5;
        }

        private void validate(Bitmap bitmap,Stack<Point>sp,int x, int y, Color old_color, Color new_color)
        {
            Color cx = bitmap.GetPixel(x, y);
            if (cx == old_color)
            {
                sp.Push(new Point(x, y));
                bitmap.SetPixel(x, y, new_color);
            }
        }

        public void Fill(Bitmap bitmap, int x, int y, Color color)
        {
            Color old_color = bitmap.GetPixel(x,y);
            Stack<Point> pixels = new Stack<Point>();
            pixels.Push(new Point(x,y));
            bitmap.SetPixel(x, y, color);

            if (old_color == color) return;

            while(pixels.Count > 0)
            {
                Point pt = pixels.Pop();

                if (pt.X > 0 && pt.Y > 0 && pt.X <bitmap.Width -1 && pt.Y < bitmap.Height- 1)
                {
                    validate(bitmap,pixels, pt.X - 1,pt.Y, old_color, color);
                    validate(bitmap,pixels, pt.X,pt.Y - 1, old_color, color);
                    validate(bitmap,pixels, pt.X + 1,pt.Y, old_color, color);
                    validate(bitmap,pixels, pt.X,pt.Y + 1, old_color, color);
                }
            }
        }

        public Form1()
        {
            InitializeComponent();

            this.Width = 1000;
            this.Height = 800;

            colorDetect.BackColor = pen.Color;

            Bitmap = new Bitmap(pbRysownica.Width, pbRysownica.Height);
            g = Graphics.FromImage(Bitmap);
            g.Clear(Color.White);
            pbRysownica.Image = Bitmap;

        }
    }
}

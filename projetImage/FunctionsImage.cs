using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace projetImage
{
    class FunctionsImage
    {
        private Form1 form1;
        //private Bitmap map;
        //private System.Drawing.Image origin;
        int SecondPicLineWidth;
        private Point p1, p2;
        List<Point> p1List = new List<Point>();
        List<Point> p2List = new List<Point>();


        public FunctionsImage(Form1 form1)
        {
            this.form1 = form1;
        }

        public void SaveSketch()
        {

        }

        public void DrawLine()
        {
        }

        public void OpenFormLineSize()
        {
            try
            {
                FormSize fs = new FormSize();
                fs.Size = 1;
                fs.StartPosition = FormStartPosition.CenterScreen;
                fs.ShowDialog();
                SecondPicLineWidth = fs.Size;
            }
            catch (Exception e)
            {
                MessageBox.Show("error : "+ e.ToString());
            }
        }

        public void OpenFormLineColor()
        {
            ColorDialog CD = new ColorDialog();
            CD.ShowDialog();
            Color newC = CD.Color;
            SecondPicBrush = newC;
        }

        
        public void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (p1.X == 0)
            {
                p1.X = e.X;
                p1.Y = e.Y;
            }
            else
            {
                p2.X = e.X;
                p2.Y = e.Y;

                p1List.Add(p1);
                p2List.Add(p2);

          
                p1.X = 0;
            }
        }

        public void Panel1_Paint(object sender, PaintEventArgs e)
        {
            using (var p = new Pen(Color.Blue, 4))
            {
                for (int x = 0; x < p1List.Count; x++)
                {
                    e.Graphics.DrawLine(p, p1List[x], p2List[x]);
                }
            }
        }
    }
}

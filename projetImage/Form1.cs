using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace projetImage
{
    //
    // In this class : each button call a function. Functions are implemented in function class as filesFunctions
    // Created and updated by LUSO & LEST 
    //
    public partial class Form1 : Form
    {
        //******************************************************
        // vars
        //*****************************************************
        // stephane part
        private FunctionsFile fFile ;       // save / load in files
        private FunctionsDb fDb;            // save / load in Db
        private FunctionsImage fImage;      // draw / save sketchs
        private int widthPBox1;             // fix picture box size
        private int heightPBox1;
        private int currentIdPicture;       // used for db access and check
        private int currentIdSketch;        // used for db access and check
        private int dBMode;               // used to select query in db fonction

        // Soraia part
        private Color color = Color.Black;  //Default color black
        Image Second = null;                //
        Image Original = null;              //
        private bool draw = false;          // boolean to know if we are drawing something
        private int s = 3;
        int SecondPicLineWidth;

        // constructor
        public Form1()
        {
            InitializeComponent();
            currentIdPicture = -1;  // -1 --> not selected
            currentIdSketch = -1;   // -1 --> not selected
            dBMode = 1;             // by default 1 --> insert image in db , my  choice
            fFile = new FunctionsFile(this);
            fDb = new FunctionsDb(this);
            widthPBox1 = pictureBox1.Width;
            heightPBox1 = pictureBox1.Height;
        }
        //****************************************************************
        // Getters and setters
        //****************************************************************
        public int DBMode
        {
            get { return dBMode; }
            set { dBMode = value; }
        }
        public int CurrentIdSketch
        {
            get { return currentIdSketch; }
            set { currentIdSketch = value; }
        }
        public int CurrentIdPicture
        {
            get { return currentIdPicture; }
            set { currentIdPicture = value; }
        }
        public int HeightPBox1
        {
            get { return heightPBox1; }
            set { heightPBox1 = value; }
        }
        public int WidthPBox1
        {
            get { return widthPBox1; }
            set { widthPBox1 = value; }
        }
        public PictureBox getPictureBox()
        {
            return pictureBox1;
        }
        public TextBox getTextBox()
        {
            return textBox1;
        }
        public TextBox getTextBox_db()
        {
            return textBox_db;
        }
        //***********************************************************
        // functions
        //***********************************************************

        //
        // Check if picture or sketch present
        //
        public Boolean checkPicture(Image img)
        {
            // if no image selected, nothing saved and exit
            if (img == null)
            {
                MessageBox.Show("No image loaded !!!");
                return false;
            }
            return true;
        }
        //
        //  Check name , a name must be present (used for save folder and DB)
        //
        public Boolean checkName(String name)
        {
            if (name.Length == 0)
            {
                MessageBox.Show("No name, write one !");
                return false;
            }
            return true;
        }
        //
        // dims can change after a picture. This method reload default values. LEST 20/5/13
        //
        public void reloadOriginalDimPictureBox1()
        {
            pictureBox1.Height = heightPBox1;
            pictureBox1.Width = widthPBox1;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;    // set a border
        }
        //
        // if picture bigger than pictureBox --> zoom mode else autosizeMode. LEST 20/5/13
        //
        public void checkImageDim()
        {
            if (pictureBox1.Image == null)       // when app start no picture and bug. This test resolve bub
                return;
            if (pictureBox1.Image.Height > heightPBox1 || pictureBox1.Image.Width > widthPBox1)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            }
        }
        //*******************************************************
        // buttons
        //***********************************************************
        private void button_loadPicture_Click(object sender, EventArgs e)
        {
            fFile.LoadImageFromFile();
            this.checkImageDim();
        }
        private void button_save_Click(object sender, EventArgs e)
        {
            // no name --> end
            if ( ! checkName(textBox1.Text) )
            {
                return;
            }
            // no picture --> end
            if ( !checkPicture(pictureBox1.Image))
            {
                return;
            }
            fFile.SaveImage();
            textBox1.Text = "";

        }
        private void button_saveInDb_Click(object sender, EventArgs e)
        {
            dBMode = 1;  //  mode save image in Db
            // no name --> end
            if (!checkName(textBox_db.Text))
            {
                return;
            }
            // no picture --> end
            if (!checkPicture(pictureBox1.Image))
            {
                return;
            }
            currentIdPicture = fDb.SaveImageInDb();
            textBox_db.Text = "";
        }

        private void button_loadFromDB_Click(object sender, EventArgs e)
        {
            dBMode = 3;     // mode load image from db
            fDb.prepareLoadImageFromDb(fFile);
            checkImageDim();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

      /*  private void pictureBox1_Click(object sender, EventArgs e)
        {

        }*/

        private void button_createSketch_Click(object sender, EventArgs e)
        {
            // first image must be saved in Db ( your choice )
            if (currentIdPicture == -1)
            {
                MessageBox.Show("Save picture in data base !");
                return;
            }
            MessageBox.Show("This part is for you Soraia :)) "+currentIdPicture);

        }

        //draw when mouse moves down
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Original = pictureBox1.Image;
            Second = pictureBox1.Image;
            draw = true;
            Graphics g = Graphics.FromImage(Second);
            Pen pen1 = new Pen(color, 4);
            g.DrawRectangle(pen1, e.X, e.Y, 2, 2);
            g.Save();
            pictureBox1.Image = Second;

        }

        //draw when mouse moves up
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            draw = false;

        }

        //Look if we are drawing something
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (draw)
            {
                Graphics g = Graphics.FromImage(Second);
                SolidBrush brush = new SolidBrush(color);
                g.FillRectangle(brush, e.X, e.Y, s, s);
                g.Save();
                pictureBox1.Image = Second;
            }

        }

        private void buttonSizeLine_Click(object sender, EventArgs e)
        {
            fImage.OpenFormLineSize();
           // OpenFormLineSize();
        }

        private void buttonDrawLine_Click(object sender, EventArgs e)
        {
           // fImage.
        }

        private void buttonDrawLine_Click()
        {

        }

        private void buttonSizeLine_Click()
        {

        }

        private void button_loadSketch_Click(object sender, EventArgs e)
        {
            dBMode = 4;     // mode load sketch from db
            fDb.prepareLoadImageFromDb(fFile);
        }

        private void button_saveSketch_Click(object sender, EventArgs e)
        {
            dBMode = 2;  //  mode save image in Db
            /*
            // no name --> end
            if (!checkName(textBox_db.Text))
            {
                return;
            }
            // no picture --> end
            if (!checkPicture(pictureBox1.Image))
            {
                return;
            }
            currentIdPicture = fDb.SaveImageInDb();
            textBox_db.Text = "";
             * */
        }

        

        /*public void OpenFormLineSize()
        {
            FormSize fs = new FormSize();
            fs.Size = 1;
            fs.StartPosition = FormStartPosition.CenterScreen;
            fs.ShowDialog();
            SecondPicLineWidth = fs.Size;
        }*/
        
    }
}

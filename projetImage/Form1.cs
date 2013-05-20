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
        private FunctionsFile fFile ;        // save / load in files
        private FunctionsDb fDb;             // save / load in Db
        private int widthPBox1;             // fix picture box size
        private int heightPBox1;
        // constructor
        public Form1()
        {
            InitializeComponent();
            fFile = new FunctionsFile(this);
            fDb = new FunctionsDb(this);
            widthPBox1 = pictureBox1.Width;
            heightPBox1 = pictureBox1.Height;
        }
        //
        // Getters and setters
        //
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
        //***********************************************************
        // functions
        //***********************************************************
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
            fFile.SaveImage();

        }
        private void button_saveInDb_Click(object sender, EventArgs e)
        {
            fDb.SaveImageInDb();
        }

        private void button_loadFromDB_Click(object sender, EventArgs e)
        {
            fDb.prepareLoadImageFromDb(fFile);
            checkImageDim();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

     
       
        
    }
}

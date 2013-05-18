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
    public partial class Form1 : Form
    {
        //******************************************************
        // vars
        //*****************************************************
        FilesFunctions fileF = new FilesFunctions();        // save / load files

        public Form1()
        {
            InitializeComponent();
            
        }
        //*******************************************************
        // buttons
        //***********************************************************
        private void button_loadPicture_Click(object sender, EventArgs e)
        {
            fileF.LoadImage(pictureBox1);
            
        }
        private void button_save_Click(object sender, EventArgs e)
        {
            SaveImage();
        }
        //**********************************************************
        //  functions
        //**********************************************************
        //
        // load image from file
        //
        /*
        public void LoadImage()
        {
            OpenFileDialog op = new OpenFileDialog();
            DialogResult dr = op.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string path = op.FileName;
                pictureBox1.Load(path);
                Bitmap temp = new Bitmap(pictureBox1.Image,
                   new Size(pictureBox1.Width, pictureBox1.Height));
                pictureBox1.Image = temp;
                map = new Bitmap(pictureBox1.Image);
                Origin = pictureBox1.Image;
            }
        }
         */

        //
        // save image in local folder. Save in png format, our choice ( png is loseless and free ! )
        //
        public void SaveImage()
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            FolderBrowserDialog fl = new FolderBrowserDialog();
            // I force a name if nothing writed in name's field
            if (textBox1.Text.Length == 0)
            {
                textBox1.Text = "John Doe";
            }
            if (fl.ShowDialog() != DialogResult.Cancel)
            {
                pictureBox1.Image.Save(fl.SelectedPath + @"\" + textBox1.Text + @".png", System.Drawing.Imaging.ImageFormat.Png);
            };
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button_saveInDb_Click(object sender, EventArgs e)
        {

        }

        
    }
}

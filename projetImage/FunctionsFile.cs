﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace projetImage
{
    //
    // In this class : functions to store and get pictures in folders. 
    // Created and updated by LEST 5/13
    //
    public class FunctionsFile : I_FunctionsFile
    {
         //
        // vars
        //
        private Form1 form1;
        private Bitmap map;
        private System.Drawing.Image origin;
        //
        //  Constructor. I use form1 to get/set textbox, pictureBox, .....
        //
        public FunctionsFile(Form1 form1)
        {
            this.form1 = form1;
        }
        //public FunctionsFile() { }
        //
        // load image from file
        //
        public void LoadImageFromFile()
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                DialogResult dr = op.ShowDialog();
                form1.reloadOriginalDimPictureBox1();   // resize picture box
                if (dr == DialogResult.OK)
                {
                    string path = op.FileName;
                    form1.getPictureBox().Load(path);                           // img loaded in pictureBox in format .XXX
                    // change img in .bmp and store original image 
                    Bitmap temp = new Bitmap(form1.getPictureBox().Image);      // temp = img.bmp
                    form1.getPictureBox().Image = temp;                         // pictureBox image in format.bmp
                    map = new Bitmap(form1.getPictureBox().Image);              // map = img.bmp
                    origin = form1.getPictureBox().Image;                       // origne = img.bmp
                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Sorry, error in load image " + e.ToString());
            }
            
        }
        
        //
        // load image from db export
        //
        public void LoadImageFromDb(Image img)
        {
            try
            {
                form1.reloadOriginalDimPictureBox1();   // resize picture box
                form1.getPictureBox().Image = img;                          // img loaded in pictureBox in format .XXX
                // change img in .bmp and store original image 
                Bitmap temp = new Bitmap(form1.getPictureBox().Image);      // temp = img.bmp
                form1.getPictureBox().Image = temp;                         // pictureBox image in format.bmp
                map = new Bitmap(form1.getPictureBox().Image);              // map = img.bmp
                origin = form1.getPictureBox().Image;                       // origne = img.bmp
                form1.checkImageDim();                                      // resize pictureBox
            }
            catch (Exception e)
            {
                MessageBox.Show("Sorry, error in load image " + e.ToString());
            }

        }
        
        //
        // save image in local folder. Save in png format, our choice ( png is losseless and free ! )
        //
        public void SaveImage()
        {
            
            try
            {
                FolderBrowserDialog fl = new FolderBrowserDialog();
               
                if (fl.ShowDialog() != DialogResult.Cancel)
                {
                    MessageBox.Show("Saved in : "+fl.SelectedPath.ToString());
                    form1.getPictureBox().Image.Save(fl.SelectedPath + @"\" + form1.getTextBox().Text + @".png", System.Drawing.Imaging.ImageFormat.Png);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Sorry, error in save image " + e.ToString());
            }
            
        }
    }
}

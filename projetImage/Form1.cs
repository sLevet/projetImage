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
    // Created by LUSO & LEST 
    //
    public partial class Form1 : Form
    {
        //******************************************************
        // vars
        //*****************************************************
        FunctionsFile fFile ;        // save / load in files
        FunctionsDb fDb;             // save / load in Db

        public Form1()
        {
            InitializeComponent();
            fFile = new FunctionsFile(this);
            fDb = new FunctionsDb(this);
            
        }
        //
        // Getter and setter
        //
        public PictureBox getPictureBox()
        {
            return pictureBox1;
        }
        public TextBox getTextBox()
        {
            return textBox1;
        }
        //*******************************************************
        // buttons
        //***********************************************************
        private void button_loadPicture_Click(object sender, EventArgs e)
        {
            fFile.LoadImageFromFile();
            
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
            fDb.prepareLoadImageFromDb();
        }

        
    }
}

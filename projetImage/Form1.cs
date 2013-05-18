﻿using System;
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
            fileF.SaveImage(pictureBox1, textBox1);

        }
        private void button_saveInDb_Click(object sender, EventArgs e)
        {
            fileF.SaveImageInDb(pictureBox1, textBox1);
        }

        
    }
}

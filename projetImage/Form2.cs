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
    public partial class Form2 : Form
    {
        FilesFunctions fileF ;        // save / load files
        PictureBox pictureBox1;

        public Form2(FilesFunctions fileF, PictureBox pictureBox1)
        {
            InitializeComponent();
            this.fileF = fileF;
            this.pictureBox1 = pictureBox1;
        }
        //
        // Return combox box. Used in files fonctions to set name and see selection
        //
        public ComboBox getComboBox()
        {
            return this.comboBox_name;
        }
        private void comboBox_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_loadImage_Click(object sender, EventArgs e)
        {
            string msg = comboBox_name.Text;
            fileF.loadImageFromDb(msg,pictureBox1);
            this.Close();
        }
    }
}
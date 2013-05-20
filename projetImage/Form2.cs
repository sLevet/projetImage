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
    // This form to load img name and img from DB in pictureBox. Allow exportation to a folder.
    // Created and updated by LEST 5/13
    //
    public partial class Form2 : Form
    {
        FunctionsDb fDb ;        // save / load to db
       
        public Form2(FunctionsDb fDb)
        {
            InitializeComponent();
            this.fDb = fDb;
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
            fDb.loadImageFromDb(msg);
            this.Close();
        }
    }
}

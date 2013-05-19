using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace projetImage
{
    public class FunctionsFile
    {
         //
        // vars
        //
        private Form1 form1;
        private Bitmap map;
        private System.Drawing.Image Origin;
        //
        //  Constructor. I use form1 to get/set textbox, pictureBox, .....
        //
        public FunctionsFile(Form1 form1)
        {
            this.form1 = form1;
        }
        //
        // load image from file
        //
        public void LoadImageFromFile()
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                DialogResult dr = op.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    string path = op.FileName;
                    form1.getPictureBox().Load(path);
                    Bitmap temp = new Bitmap(form1.getPictureBox().Image,
                                        new Size(form1.getPictureBox().Width, form1.getPictureBox().Height));
                    form1.getPictureBox().Image = temp;
                    map = new Bitmap(form1.getPictureBox().Image);
                    Origin = form1.getPictureBox().Image;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Sorry, error in load image " + e.ToString());
            }
            
        }
        //
        //  Force a name if nothing writed in name's field (used for save folder and DB)
        //
        public String CheckName(String name)
        {
            if (name.Length == 0)
            {
                return "no_name";
            }
            return name;
        }
        //
        // save image in local folder. Save in png format, our choice ( png is losseless and free ! )
        //
        public void SaveImage()
        {
            // if no image selected, nothing saved and exit
            if(form1.getPictureBox().Image == null)
            {
                MessageBox.Show("No image loaded !!!");
                return;
            }
            try
            {
               
                form1.getPictureBox().SizeMode = PictureBoxSizeMode.AutoSize;
                FolderBrowserDialog fl = new FolderBrowserDialog();
                // I force a name if nothing writed in name's field
                form1.getTextBox().Text = CheckName(form1.getTextBox().Text);

                if (fl.ShowDialog() != DialogResult.Cancel)
                {
                    form1.getPictureBox().Image.Save(fl.SelectedPath + @"\" + form1.getTextBox().Text + @".png", System.Drawing.Imaging.ImageFormat.Png);
                }
                form1.getPictureBox().SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception e)
            {
                MessageBox.Show("Sorry, error in save image " + e.ToString());
            }
            
        }
    }
}

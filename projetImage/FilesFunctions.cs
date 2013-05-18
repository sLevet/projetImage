using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Data.SqlServerCe;
using System.Configuration;

namespace projetImage
{
    public class FilesFunctions 
    {
        //
        // vars
        //
        private Bitmap map;
        private System.Drawing.Image Origin;
        private string connectString = "Data Source=WIN-GS9GMUJITS8;Initial Catalog=BDPicture;Integrated Security=True";    // path
        private string query;           // query for sql request
        //
        // load image from file
        //
        public void LoadImageFromFile(PictureBox pictureBox1)
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
        public void SaveImage(PictureBox pictureBox1, TextBox textBox1)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            FolderBrowserDialog fl = new FolderBrowserDialog();
            // I force a name if nothing writed in name's field
            textBox1.Text = CheckName(textBox1.Text);
           
            if (fl.ShowDialog() != DialogResult.Cancel)
            {
                pictureBox1.Image.Save(fl.SelectedPath + @"\" + textBox1.Text + @".png", System.Drawing.Imaging.ImageFormat.Png);
            }
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        //
        // This method convert a picture --> byte[] , I use it to store a picture in my DB
        // thanxs to Rajan Tawate (http://www.codeproject.com/Articles/15460/C-Image-to-Byte-Array-and-Byte-Array-to-Image-Conv) for this method !
        //
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }
        //
        // This method convert a byte[] -->picture.png, I use it to extract picture from my DB
        // thanxs to Rajan Tawate (http://www.codeproject.com/Articles/15460/C-Image-to-Byte-Array-and-Byte-Array-to-Image-Conv) for this method !
        //
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        //
        // Save image in DB
        //
        public void SaveImageInDb(PictureBox pictureBox1, TextBox textBox1)
        {
            // I force a name if nothing writed in name's field
            textBox1.Text = CheckName(textBox1.Text);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            //Image im = pictureBox1.Image;
            byte[] tab = imageToByteArray(pictureBox1.Image);
            SqlConnection cn = new SqlConnection();             // connection for sql
            try
            {
                // open connection
                cn.ConnectionString = connectString;
                cn.Open();
                // query and parameters
                query = "INSERT INTO T_pictures (name, pict_field) VALUES  (@name, @picture) ";
                SqlCommand cmd = new SqlCommand(query, cn);

                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@picture", tab);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                MessageBox.Show("nice !");
                cn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Sorry, not stored !!! " + e.ToString());
                cn.Close();
            }
            
        }
        //
        // Prepare to load a picture from DB. Used to export file
        //
        public void prepareLoadImageFromDb(PictureBox pictureBox1)
        {
            List<String> listPicturesName = new List<string>();         // store pictures' names and ids
            // first I load and check if pictures are present in DB
            SqlConnection cn = new SqlConnection();             // connection for sql
            try
            {
                string name = "", temp = "";
                int id;
                // open connection
                cn.ConnectionString = connectString;
                cn.Open();
                // query and parameters
                query = "SELECT name, id FROM T_pictures";
                SqlCommand stmt = new SqlCommand(query, cn);
                SqlDataReader RS = stmt.ExecuteReader();
                while (RS.Read())
                {
                    name =((string)RS["name"]);
                    id = ((int)RS["id"]);
                    temp = id + "_" + name;
                    listPicturesName.Add(temp);
                   
                }
                cn.Close();
                //MessageBox.Show("nice !"+temp);
            }
            catch (Exception e)
            {
                MessageBox.Show("Sorry,not ok !!! " + e.ToString());
                cn.Close();
            }
            // if list.count = 0 --> no picture ---> display a warning and stop
            if (listPicturesName.Count() == 0)
            {
                MessageBox.Show("No picture in data base !");
                return;
            }
            // create a new form with picture's names. This allow to use same vars in form2
            Form2 form2 = new Form2(this, pictureBox1);
            form2.Show();
            // fill combo list and select a default value
            string[] tabName = new string[listPicturesName.Count()];
            int pos = -1;
            foreach (String name in listPicturesName)
            {
                pos++;
                tabName[pos] = name;
            }
            form2.getComboBox().Items.AddRange(tabName);
            form2.getComboBox().SelectedIndex = 0;
        }
        //
        // Load a picture from DB. Used to export file
        //
        public void loadImageFromDb(string msg,PictureBox pictureBox1)
        {
            byte[] byteArray = null;
            // extract substring with picture id and cast in int
            string stringIdImage = "";
            int stopPos =msg.IndexOf('_');
            stringIdImage = msg.Substring(0, stopPos);
            int idImage = int.Parse(stringIdImage);

            // connect in DB and load picture in pictureBox
            SqlConnection cn = new SqlConnection();             // connection for sql
            try
            {
                // open connection
                cn.ConnectionString = connectString;
                cn.Open();
                // query and parameters
                query = "SELECT pict_field FROM T_pictures WHERE id = @id";
                SqlCommand stmt = new SqlCommand(query, cn);
                stmt.Parameters.AddWithValue("id", idImage);
                SqlDataReader RS = stmt.ExecuteReader();
                while (RS.Read())
                {
                    byteArray = ((byte[])RS["pict_field"]);
                }
                cn.Close();
                Image img = byteArrayToImage(byteArray);
                pictureBox1.Image = img;
                //MessageBox.Show("message : " + stringIdImage + "****");
            }
            catch (Exception e)
            {
                MessageBox.Show("Sorry,not ok !!! " + e.ToString());
                cn.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace projetImage
{
    //
    // In this class : functions to store and get pictures in dataBase. 
    // Based on sql server (not sql express !!). Adapte var "connectString" for your DB. 
    // Created and updated by  LEST 
    //
    public class FunctionsDb : I_FunctionsDb
    {
        //
        // vars
        //
        private Form1 form1;
        private FunctionsFile fFile;
        private string connectString = "Data Source=WIN-GS9GMUJITS8;Initial Catalog=BDPicture;Integrated Security=True";    // path for DB
        private string query;           // query for sql request
        //
        //  Constructor. I use form1 to get/set textbox, pictureBox, .....
        //
        public FunctionsDb(Form1 form1)
        {
            this.form1 = form1;
        }
        //
        //  Force a name if nothing writed in name's field (used for save folder and DB)
        //
        public String checkName(String name)
        {
            if (name.Length == 0)
            {
                return "no_name";
            }
            return name;
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
        public void SaveImageInDb()
        {
            // I force a name if nothing writed in name's field
            form1.getTextBox().Text = checkName(form1.getTextBox().Text);
            byte[] tab = imageToByteArray(form1.getPictureBox().Image);
            SqlConnection cn = new SqlConnection();             // connection for sql
            try
            {
                // open connection
                cn.ConnectionString = connectString;
                cn.Open();
                // query and parameters
                query = "INSERT INTO T_pictures (name, pict_field) VALUES  (@name, @picture) ";
                SqlCommand cmd = new SqlCommand(query, cn);

                cmd.Parameters.AddWithValue("@name", form1.getTextBox().Text);
                cmd.Parameters.AddWithValue("@picture", tab);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
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
        public void prepareLoadImageFromDb(FunctionsFile fFile)
        {
            this.fFile = fFile;
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
                    name = ((string)RS["name"]);
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
            Form2 form2 = new Form2(this);
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
        public void loadImageFromDb(string msg)
        {
            byte[] byteArray = null;
            // extract substring with picture id and cast in int
            string stringIdImage = "";
            int stopPos = msg.IndexOf('_');
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
                fFile.LoadImageFromDb(img);         // class fFile adjust picture and fill pictureBox.
            }
            catch (Exception e)
            {
                MessageBox.Show("Sorry,not ok !!! " + e.ToString());
                cn.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Gorsel_Butunleme.Userler
{
    public partial class YenıUser : Form
    {

        public YenıUser()
        {
            InitializeComponent();
          

        }
        MySqlConnection conn = new MySqlConnection("server=localhost;database=diliveri;port=3306;username=root;Password= ");
        string imagePat = "";
        MySql.Data.MySqlClient.MySqlDataAdapter ekle;
        private object file;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Class1 masd = new Class1();
            masd.Name = textName.Text;
            masd.Email = textEmail.Text;
            masd.Sefre = textpaswword.Text;
            masd.Foto = TXTIMG.ImageLocation;



            try
            {



               
                if (textName.Text == "" || textName.Text == "" || textpaswword.Text == "" || imagePat == "" )
                {
                    MessageBox.Show("name or email or şefre eksik or ımeg gir");
                }
                else
                {
                  
                    string sqlq = "INSERT INTO users values(@id,@Name,@password,@email,@img)";
                    MySqlCommand cmd = new MySqlCommand(sqlq, conn);
                    cmd.Parameters.AddWithValue("@Name", textName.Text);
                    cmd.Parameters.AddWithValue("@password", textpaswword.Text);
                    cmd.Parameters.AddWithValue("@email", textEmail.Text);
                    cmd.Parameters.AddWithValue("@id", textıd.Text);
                   
                // cmd.Parameters.AddWithValue("@img",File.ReadAllBytes(" Eklae-removebg-preview.png"));
               
                    if (imagePat != "")
                    {
                       string YenıPath = Environment.CurrentDirectory + "\\fotograflar\\user\\" +textName.Text+ ".jpg";
                        File.Copy(imagePat, YenıPath);
                        cmd.Parameters.AddWithValue("@img",YenıPath );
                        

                    }
                    conn.Open();
                    cmd.ExecuteNonQuery();
                   
                   
                    conn.Close();

                     MessageBox.Show("ekledi");
                    this.Close();





                }

           }catch(Exception ex)
            {
               MessageBox.Show(ex.Message, "meseg");
            }


        }

        private void textName_TextChanged(object sender, EventArgs e)
        {

        }

        private void YenıUser_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(255,255,255,255);
        }

        private void btnAdd_MouseHover(object sender, EventArgs e)
        {
            btnAdd.ForeColor = Color.LemonChiffon;
        }

        private void TXTIMG_Click(object sender, EventArgs e)
        {
            /*   OpenFileDialog foto = new OpenFileDialog();
               foto.Title = "INSERT File";
               foto.Filter = "ImageFile(*.jpg;*.png)|*.ipg;*.png";
               if (foto.ShowDialog() == DialogResult.OK)
               {
                   TXTIMG.Image = Image.FromFile(foto.FileName);
               }*/
            OpenFileDialog foto = new OpenFileDialog();
            foto.ShowDialog();
            if (foto.ShowDialog() == DialogResult.OK)
            {
                imagePat = foto.FileName;
                TXTIMG.ImageLocation = foto.FileName;

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

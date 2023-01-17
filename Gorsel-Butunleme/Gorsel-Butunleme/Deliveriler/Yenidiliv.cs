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

namespace Gorsel_Butunleme.Deliveriler
{
    public partial class Yenidiliv : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;database=diliveri;port=3306;username=root;Password= ");
        string imagePat = "";
        MySql.Data.MySqlClient.MySqlDataAdapter ekle;
        private object file;
        public Yenidiliv()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
             {




            if (TXTMUŞAD.Text == "" || TXTTLF.Text == "" || imagePat == "")
            {
                MessageBox.Show("Qr or AD or FIyat eksik");
            }
            else
            {
                
                string sqlq = "INSERT INTO dilivge values(@id,@dilivname,@addres,@pone,@email,@isActiv,@imege,@Nods)";
                MySqlCommand cmd = new MySqlCommand(sqlq, conn);
                cmd.Parameters.AddWithValue("@dilivname", TXTMUŞAD.Text);
                cmd.Parameters.AddWithValue("@addres", TXTADRS.Text);
                cmd.Parameters.AddWithValue("@pone", TXTTLF.Text);
                cmd.Parameters.AddWithValue("@email", TXTEMAL.Text);
                cmd.Parameters.AddWithValue("@isActiv", checkBox1.Checked);
                cmd.Parameters.AddWithValue("@Nods", TXTNOT.Text);
                cmd.Parameters.AddWithValue("@id", textBox1.Text);


                // cmd.Parameters.AddWithValue("@img",File.ReadAllBytes(" Eklae-removebg-preview.png"));

                if (imagePat != "")
                {

               

                    string YenıPath = Environment.CurrentDirectory + "\\fotograflar\\Dileviri\\" + TXTMUŞAD.Text + ".jpg";
                    File.Copy(imagePat, YenıPath);
                    cmd.Parameters.AddWithValue("@imege", YenıPath);

                   
                }
                conn.Open();
                cmd.ExecuteNonQuery();


                conn.Close();

                MessageBox.Show("ekledi");
                this.Close();




            }

             }
             catch (Exception ex)
             {
                MessageBox.Show(ex.Message, "meseg");
             }
        }

        private void TXTMUSIMG_Click(object sender, EventArgs e)
        {
            OpenFileDialog foto = new OpenFileDialog();
            foto.ShowDialog();
            if (foto.ShowDialog() == DialogResult.OK)
            {
                imagePat = foto.FileName;
                TXTMUSIMG.ImageLocation = foto.FileName;

            }
        }

        private void TXTMUŞAD_KeyPress(object sender, KeyPressEventArgs e)
        {
            TXTMUŞAD.MaxLength = 15;
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TXTTLF_KeyPress(object sender, KeyPressEventArgs e)
        {
            TXTTLF.MaxLength = 15;
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

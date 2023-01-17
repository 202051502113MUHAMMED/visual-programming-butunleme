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

namespace Gorsel_Butunleme.muşterler
{
    public partial class YeniManav : Form
    {

        MySqlConnection conn = new MySqlConnection("server=localhost;database=diliveri;port=3306;username=root;Password= ");
        string imagePat = "";
        MySql.Data.MySqlClient.MySqlDataAdapter ekle;
        private object file;
        public YeniManav()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            try
             {




                if (TXTQR.Text == "" || TXTMAD.Text == "" || TXTFYT.Text == "" || imagePat == "")
                {
                    MessageBox.Show("Qr or AD or FIyat eksik img gir");
                }
                else
                {


                    //  string sqlq = "INSERT INTO manavlar values(@id,@MaName,@Code,@Fiyat,@Not,@imege,@adet)";
                    string sqlq = "INSERT INTO `manavlar`( `MaName`, `Code`, `Fiyat`, `not`, `imege`, `adet`) VALUES (@MaName,@Code,@Fiyat,@Not,@imege,@adet)";

                    MySqlCommand cmd = new MySqlCommand(sqlq, conn);
                    cmd.Parameters.AddWithValue("@MaName", TXTMAD.Text);
                    cmd.Parameters.AddWithValue("@Code", TXTQR.Text);
                    cmd.Parameters.AddWithValue("@Fiyat", TXTFYT.Text);
                    cmd.Parameters.AddWithValue("@Not", TXTNOT.Text);
                   cmd.Parameters.AddWithValue("@adet", TXTADT.Text);
               

                    // cmd.Parameters.AddWithValue("@img",File.ReadAllBytes(" Eklae-removebg-preview.png"));

                    if (imagePat != "")
                    {

                       


                        string YenıPath = Environment.CurrentDirectory + "\\fotograflar\\manav\\" + TXTMAD.Text + ".jpg";
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

        private void TXTIMG_Click(object sender, EventArgs e)
        {
            OpenFileDialog foto = new OpenFileDialog();
            foto.ShowDialog();
            if (foto.ShowDialog() == DialogResult.OK)
            {
                imagePat = foto.FileName;
                TXTIMG.ImageLocation = foto.FileName;

            }
        }

        private void TXTQR_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXTQR_KeyPress(object sender, KeyPressEventArgs e)
        {
            TXTQR.MaxLength = 15;
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TXTMAD_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXTMAD_KeyPress(object sender, KeyPressEventArgs e)
        {
            TXTMAD.MaxLength = 15;
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TXTADT_KeyPress(object sender, KeyPressEventArgs e)
        {
            TXTADT.MaxLength = 2;
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TXTFYT_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXTFYT_KeyPress(object sender, KeyPressEventArgs e)
        {
            TXTFYT.MaxLength = 5;
            if (!char.IsNumber(e.KeyChar)&& !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void YeniManav_Load(object sender, EventArgs e)
        {

        }
    }
}

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
namespace Gorsel_Butunleme.muşteriler22
{
    public partial class MşteriEkle : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;database=diliveri;port=3306;username=root;Password= ");
        string imagePat = "";
        MySql.Data.MySqlClient.MySqlDataAdapter ekle;
        private object file;
      
        public MşteriEkle()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // try
            // {




            if (TXTMUŞAD.Text == "" || TXTTLF.Text == "" || TXTADRS.Text == "" || imagePat == "" )
            {
                MessageBox.Show("Qr or AD or FIyat eksik fotograf gir");
            }
            else
            {

                conn.Open();
                string sqlq = "INSERT INTO musterıler values(@id,@musname,@addres,@pone,@email,@isActiv,@imege,@Nods)";
                MySqlCommand cmd = new MySqlCommand(sqlq, conn);

                if (imagePat != "")
                {
                    string YenıPath = Environment.CurrentDirectory + "\\fotograflar\\Muşteriler\\" + TXTMUŞAD.Text+ ".jpg";
                    File.Copy(imagePat, YenıPath);
                    cmd.Parameters.AddWithValue("@imege", YenıPath);
                    

                }
             
                cmd.Parameters.AddWithValue("@musname", TXTMUŞAD.Text);
                cmd.Parameters.AddWithValue("@addres", TXTADRS.Text);
                cmd.Parameters.AddWithValue("@pone", TXTTLF.Text);
                cmd.Parameters.AddWithValue("@email", TXTEMAL.Text);
                cmd.Parameters.AddWithValue("@isActiv", checkBox1.Checked);
               // cmd.Parameters.AddWithValue("@imege", textBox2.Text);
                cmd.Parameters.AddWithValue("@Nods", TXTNOT.Text);
                cmd.Parameters.AddWithValue("@id", textBox1.Text);


               

             
                cmd.ExecuteNonQuery();


                conn.Close();

                MessageBox.Show("ekledi");
                this.Close();




            }

            // }
            // catch (Exception ex)
            // {
            //    MessageBox.Show(ex.Message, "meseg");
            // }
        }

        private void TXTMUSIMG_Click(object sender, EventArgs e)
        {
          
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel3_Click(object sender, EventArgs e)
        {
         
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog foto = new OpenFileDialog();
            foto.ShowDialog();
            if (foto.ShowDialog() == DialogResult.OK)
            {
                imagePat = foto.FileName;
                pictureBox1.ImageLocation = foto.FileName;

            }
        }

        private void TXTTLF_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXTTLF_KeyPress(object sender, KeyPressEventArgs e)
        {
            TXTTLF.MaxLength = 15;
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TXTMUŞAD_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXTMUŞAD_KeyPress(object sender, KeyPressEventArgs e)
        {
            TXTMUŞAD.MaxLength = 15;
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

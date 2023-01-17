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
    public partial class ManavLeste : Form
    {

        MySqlConnection conn = new MySqlConnection("server=localhost;database=diliveri;port=3306;username=root;Password= ");
        MySqlDataAdapter ekle = new MySqlDataAdapter();
        DataTable tb = new DataTable();
        int id;
        string imagePat = "";
        private object file;

        void gunceleData()
        {
            try
            {
                tb = new DataTable();
                ekle = new MySqlDataAdapter("SELECT * FROM manavlar", conn);
                ekle.Fill(tb);
                dataGridView1.DataSource = tb;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "message");
            }
        
        }

        public ManavLeste()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            
            conn.Open();
            DataTable dt = new DataTable();
            string serhs = "SELECT * FROM manavlar WHERE MaName LIKE '%" + ARAMOTOR.Text + "%'";
            MySqlCommand cmd = new MySqlCommand(serhs, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            dataGridView1.DataSource = dt;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            gunceleData();
           

        }

        private void ManavLeste_Load(object sender, EventArgs e)
        {
            try
            {
                tb = new DataTable();
                ekle = new MySqlDataAdapter("SELECT * FROM manavlar", conn);
                ekle.Fill(tb);
                dataGridView1.DataSource = tb;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "message");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }



        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
           // {
             



                /* TXTMAD.Text = row.Cells["MaName"].Value.ToString();
                 TXTQR.Text = row.Cells["Code"].Value.ToString();
                 TXTFYT.Text = row.Cells["Fiyat"].Value.ToString();
                 TXTADT.Text = row.Cells["adet"].Value.ToString();
                 TXTNOT.Text = row.Cells["Not"].Value.ToString();
                 TXTIMG.ImageLocation = row.Cells["imege"].Value.ToString();
                 //TXTIMG.ImageLocation = Environment.CurrentDirectory + "\\fotograf\\manavelar\\" + row.id + ".jpg";*/






           // }
        }

        private void TXTQR_KeyPress(object sender, KeyPressEventArgs e)
        {
            TXTQR.MaxLength = 15;
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TXTADT_KeyPress(object sender, KeyPressEventArgs e)
        {
            TXTADT.MaxLength = 3;
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            YeniManav ac = new YeniManav();
            ac.ShowDialog();
        }

        private void TXTQR_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
             {



               

                conn.Open();
                
                string sqlq = "UPDATE `manavlar` SET `MaName`=@MaName,`Code`=@Code,`Fiyat`=@Fiyat,`not`=@not,`imege`=@imege, `adet`=@adet WHERE id=" + dataGridView1.CurrentRow.Cells[0].Value + "";
                MySqlCommand cmd = new MySqlCommand(sqlq, conn);
               // cmd.Parameters.AddWithValue("@id", textBox1.Text);
                cmd.Parameters.AddWithValue("@MaName", TXTMAD.Text);
                cmd.Parameters.AddWithValue("@Code", TXTQR.Text);
                cmd.Parameters.AddWithValue("@Fiyat", TXTFYT.Text);
                cmd.Parameters.AddWithValue("@not", TXTNOT.Text);
                cmd.Parameters.AddWithValue("@adet", TXTADT.Text);
              



                if (imagePat == "")
                {

                    cmd.Parameters.AddWithValue("@imege", TXTIMG.ImageLocation);

                }
                else
                {
                    string YenıPath = Environment.CurrentDirectory + "\\fotograflar\\manav\\" + TXTNOT.Text + ".jpg";
                    File.Copy(imagePat, YenıPath);
                    cmd.Parameters.AddWithValue("@imege", YenıPath);
                }
                  

                cmd.ExecuteNonQuery();
               dataGridView1.DataSource = tb;
                gunceleData();


                conn.Close();

                MessageBox.Show("ekledi");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "meseg");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                var r = MessageBox.Show("Silmek istyormuzunuz ?", "silmek Tamamladı", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {

                    conn.Open();
                    string dlet = "DELETE FROM manavlar WHERE id=" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + " ";
                    MySqlCommand cmd = new MySqlCommand(dlet, conn);

                    cmd.ExecuteNonQuery();


                    MessageBox.Show("selindi");
                    dataGridView1.DataSource = tb;
                    gunceleData();
                    conn.Close();

                }






            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "messeg");
            }
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            
           
               
                
                TXTMAD.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                TXTQR.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                TXTFYT.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                TXTNOT.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
               TXTIMG.ImageLocation = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                TXTADT.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXTADT_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

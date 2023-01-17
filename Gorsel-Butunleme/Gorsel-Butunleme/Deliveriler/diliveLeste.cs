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
    public partial class diliveLeste : Form
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
                ekle = new MySqlDataAdapter("SELECT * FROM dilivge", conn);
                ekle.Fill(tb);
                dataGridView1.DataSource = tb;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "message");
            }
        }
        public diliveLeste()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void TXTSEFRE_Click(object sender, EventArgs e)
        {

        }

        private void TXTDAD_KeyPress(object sender, KeyPressEventArgs e)
        {
            TXTDAD.MaxLength = 20;
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void diliveLeste_Load(object sender, EventArgs e)
        {
            try
            {
                ekle = new MySqlDataAdapter("SELECT * FROM dilivge", conn);
                ekle.Fill(tb);
                dataGridView1.DataSource = tb;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "message");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void TXTDTL_KeyPress(object sender, KeyPressEventArgs e)
        {
            TXTDTL.MaxLength = 14;
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Yenidiliv ac = new Yenidiliv();
            ac.Show();
        }

        private void TXTDAD_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            gunceleData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            DataTable dt = new DataTable();
            string serhs = "SELECT * FROM dilivge WHERE dilivname LIKE '%" + ARAMOTOR.Text + "%'";
            MySqlCommand cmd = new MySqlCommand(serhs, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

            TXTDAD.Text = row.Cells["dilivname"].Value.ToString();
            TXTDTL.Text = row.Cells["pone"].Value.ToString();
            TXTDADRS.Text = row.Cells["addres"].Value.ToString();
            TXTDEMALİ.Text = row.Cells["email"].Value.ToString();
            TXTNOT.Text = row.Cells["Nods"].Value.ToString();
            // checkBox1.Checked = row.Cells["isActiv"].Value.ToString(true);
            TXTIMG.ImageLocation = row.Cells["imege"].Value.ToString();*/
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {





                conn.Open();


               // string sqlq = "UPDATE `musterıler` SET `musname`= @musname,`addres`= @addres,`pone`= @pone,`email`= @email,`imege`= @imege,`Nods`= @Nods WHERE id=" + dataGridView1.CurrentRow.Cells[0].Value + " ";
                string sqlq = "UPDATE `dilivge` SET  `dilivname`=@dilivname,`addres`=@addres,`pone`=@pone,`email`=@email,`imege`=@imege,`Nods`=@Nods WHERE  id=" + dataGridView1.CurrentRow.Cells[0].Value + "";
                MySqlCommand cmd = new MySqlCommand(sqlq, conn);
                cmd.Parameters.AddWithValue("@dilivname", TXTDAD.Text);
                cmd.Parameters.AddWithValue("@pone", TXTDTL.Text);
                cmd.Parameters.AddWithValue("@addres", TXTDADRS.Text);
                cmd.Parameters.AddWithValue("@email", TXTDEMALİ.Text);
                cmd.Parameters.AddWithValue("@Nods", TXTNOT.Text);




                if (imagePat == "")
                {

                    cmd.Parameters.AddWithValue("@imege", TXTIMG.ImageLocation);

                }
                else
                {
                    string YenıPath = Environment.CurrentDirectory + "\\fotograflar\\Dileviri\\" + TXTNOT.Text + ".jpg";
                    File.Copy(imagePat, YenıPath);
                    cmd.Parameters.AddWithValue("@imege", YenıPath);
                    cmd.ExecuteNonQuery();
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            TXTDAD.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            TXTDTL.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            TXTDADRS.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            TXTDEMALİ.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            TXTIMG.ImageLocation = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            TXTNOT.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                var r = MessageBox.Show("Silmek istyormuzunuz ?", "silmek Tamamladı", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {

                    conn.Open();
                    string dlet = "DELETE FROM dilivge WHERE id=" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + " ";
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
    }
    
}

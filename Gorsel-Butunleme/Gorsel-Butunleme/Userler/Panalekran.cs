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
    public partial class Panalekran : Form
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

                ekle = new MySqlDataAdapter("SELECT * FROM manavlar", conn);
                dataGridView1.DataSource = tb;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "message");
            }
        }
        public Panalekran()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Anaekran ac = new Anaekran();
            ac.Show();
            this.Close();
        }

        private void textArama_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            DataTable dt = new DataTable();
            string serhs = "SELECT *FROM users WHERE Name  LIKE '%" + textArama.Text + "%'";
            MySqlCommand cmd = new MySqlCommand(serhs, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            textName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textpaswword.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textEmail.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
           
            TXTIMG.ImageLocation = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            
        }

        private void Panalekran_Load(object sender, EventArgs e)
        {
            try
            {
                ekle = new MySqlDataAdapter("SELECT * FROM users", conn);
                ekle.Fill(tb);
                dataGridView1.DataSource = tb;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "message");
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            YenıUser ac = new YenıUser();
            ac.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gunceleData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {





                conn.Open();


                string sqlq = "UPDATE `users` SET `Name`= @Name,`password`= @password,`email`= @email,`img`= @img WHERE id=" + dataGridView1.CurrentRow.Cells[0].Value + " ";
                MySqlCommand cmd = new MySqlCommand(sqlq, conn);
                cmd.Parameters.AddWithValue("@Name", textName.Text);
                cmd.Parameters.AddWithValue("@password", textpaswword.Text);
                cmd.Parameters.AddWithValue("@email", textEmail.Text);
               
              




                if (imagePat == "")
                {

                    cmd.Parameters.AddWithValue("@img", TXTIMG.ImageLocation);

                }
                else
                {
                    string YenıPath = Environment.CurrentDirectory + "\\fotograflar\\user\\" + textpaswword.Text + ".jpg";
                    File.Copy(imagePat, YenıPath);
                    cmd.Parameters.AddWithValue("@img", YenıPath);
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

        private void button5_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("Silmek istyormuzunuz ?", "silmek Tamamladı", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {

                conn.Open();
                string dlet = "DELETE FROM users WHERE id=" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + " ";
                MySqlCommand cmd = new MySqlCommand(dlet, conn);

                cmd.ExecuteNonQuery();


                MessageBox.Show("selindi");
                dataGridView1.DataSource = tb;
                gunceleData();
                conn.Close();

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

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 ac = new Form1();
            ac.Show();
        }
    }
}

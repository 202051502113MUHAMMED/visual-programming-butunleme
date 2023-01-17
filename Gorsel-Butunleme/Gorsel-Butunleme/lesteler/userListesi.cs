using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Gorsel_Butunleme.lesteler
{
    public partial class userListesi : Form
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
        public userListesi()
        {
            InitializeComponent();
        }

        private void userListesi_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            DataTable dt = new DataTable();
            string serhs = "SELECT *FROM users WHERE Name  LIKE '%" + ARAMOTOR.Text + "%'";
            MySqlCommand cmd = new MySqlCommand(serhs, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gunceleData();
        }
    }
}

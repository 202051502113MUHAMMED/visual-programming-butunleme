using Gorsel_Butunleme.Userler;
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

namespace Gorsel_Butunleme
{
    public partial class Form1 : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;database=diliveri;port=3306;username=root;Password= ");
        MySql.Data.MySqlClient.MySqlDataAdapter ekle;
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            YenıUser ac = new YenıUser();
            ac.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textName.Text)|| string.IsNullOrEmpty(textpaswword.Text))
            {
                MessageBox.Show("name or şefer gir");
                textName.Focus();
                textpaswword.Select();
            }
            else
            {
                DataTable db = new DataTable();
                string sqlq = "SELECT Name,password FROM diliveri.users WHERE Name='" + textName.Text + "'And password='" + textpaswword.Text + "'";
                ekle = new MySqlDataAdapter(sqlq,conn);
                ekle.Fill(db);

                if(db.Rows.Count <= 0)
                {
                    MessageBox.Show(" Name or password Yanliş", "Message");
                    textName.Text = "";
                    textpaswword.Text = "";
                }
                else
                {
                   
                    Anaekran ac = new Anaekran();
                    ac.ShowDialog();
                    


                }
                
            }
          


        }
    }
}

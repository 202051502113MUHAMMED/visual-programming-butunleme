using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gorsel_Butunleme.Deliveriler;
using Gorsel_Butunleme.lesteler;
using Gorsel_Butunleme.muşteriler22;
using Gorsel_Butunleme.muşterler;
using Gorsel_Butunleme.Userler;
using MySql.Data.MySqlClient;
namespace Gorsel_Butunleme
{
    
    public partial class Anaekran : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;database=diliveri;port=3306;username=root;Password= ");
        MySqlDataAdapter ekle = new MySqlDataAdapter();
        DataTable tb = new DataTable();
        int id;
        string imagePat = "";
        private object file;
        public Anaekran()
        {
            InitializeComponent();

        }

        private void listeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lesteMa ac = new lesteMa();
            ac.Show();
        }

        private void panalekranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panalekran ac = new Panalekran();
            ac.ShowDialog();
            
            

        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManavLeste ac = new ManavLeste();
            ac.ShowDialog();
        }

        private void muşterListeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listeMŞ ac = new listeMŞ();
            ac.Show();
        }

        private void duzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            muşterileste ac = new muşterileste();
            ac.Show();
        }

        private void yeniManavEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YeniManav ac = new YeniManav();
            ac.ShowDialog();
           
        }

        private void muşterEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MşteriEkle ac = new MşteriEkle();
            ac.ShowDialog();
        }

        private void dilvriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Yenidiliv ac = new Yenidiliv();
            ac.Show();
        }

        private void deliveriLesteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listeD ac = new listeD();
            ac.Show();



        }

        private void duzenleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            diliveLeste ac = new diliveLeste();
            ac.Show();
        }

        private void Anaekran_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ManavLeste ac = new ManavLeste();
            ac.Show();
        }

        private void satışToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void yeniKullancıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YenıUser ac = new YenıUser();
            ac.Show();
          
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void düzenleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Panalekran ac = new Panalekran();
            ac.Show();
        }

        private void userListeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userListesi ac = new userListesi();
            ac.Show();
        }
    }
}

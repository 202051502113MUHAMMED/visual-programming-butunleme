using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gorsel_Butunleme.Manavlar
{
    public partial class ManavLeste : Form
    {
        public ManavLeste()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            YeniManav ac = new YeniManav();
            ac.Show();
        }
    }
}

using Gorsel_Butunleme.Deliveriler;
using Gorsel_Butunleme.lesteler;
using Gorsel_Butunleme.muşteriler22;
using Gorsel_Butunleme.muşterler;
using Gorsel_Butunleme.Userler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gorsel_Butunleme
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

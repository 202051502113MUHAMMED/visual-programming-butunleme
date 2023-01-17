using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Gorsel_Butunleme
{
 
    class Class1
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;database=diliveri;port=3306;username=root;Password= ");
        MySqlDataAdapter ekle = new MySqlDataAdapter();
        DataTable tb = new DataTable();
        int id;
        string imagePat = "";
        private object file;

        private string name;
        private string email;
        private string sefre;
        private string foto;


       public string Name
        { 
            get { return name; }
            set { name = value; }
        
        
        }
        public string Email
        {
            get { return email; }
            set { email = value; }


        }

        public string Sefre
        {
            get { return sefre; }
            set { sefre = value; }


        }

        public string Foto
        {
            get { return foto; }
            set { foto = value; }


        }

        



    }
}

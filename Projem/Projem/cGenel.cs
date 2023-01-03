using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projem
{
    internal class cGenel
    {
        public string conString = "server=localhost;database=restaurant;uid=root;pwd=1234;";
        public static int _personelId;
        public static int _gorevId;
        public static string _ButtonValue;
        public static string _ButtonName;
        public static int _ServisTurNo;
        public static string _AdisyonId;
    }
}

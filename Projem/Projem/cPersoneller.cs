using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Projem
{
    internal class cPersoneller
    {
        cGenel gnl = new cGenel();
        #region Fields
        private int _PersonelId;
        private int _PersonelGorevId;
        private string _PersonelAd;
        private string _PersonelSoyad;
        private string _PersonelParola;
        private string _PersonelKullaniciAdi;
        private int _PersonelDurum;
        #endregion
        #region Properties
        public int PersonelId
        {
            get => _PersonelId;
            set => _PersonelId = value;
        }
        public int PersonelGorevId
        {
            get => _PersonelGorevId;
            set => _PersonelGorevId = value;
        }
        public string PersonelAd
        {
            get => _PersonelAd;
            set => _PersonelAd = value;
        }
        public string PersonelSoyad
        {
            get => _PersonelSoyad;
            set => _PersonelSoyad = value;
        }
        public string PersonelParola
        {
            get => _PersonelParola;
            set => _PersonelParola = value;
        }
        public string PersonelKullaniciAdi
        {
            get => _PersonelKullaniciAdi;
            set => _PersonelKullaniciAdi = value;
        }
        public int PersonelDurum
        {
            get => _PersonelDurum;
            set => _PersonelDurum = value;
        }
        #endregion

        public bool personelEntryControl(string password, int UserId)
        { 
            bool result = false;
            MySqlConnection con = new MySqlConnection(gnl.conString);
            MySqlCommand cmd = new MySqlCommand("Select * from Personeller where ID=@Id and PAROLA=@password", con);
            cmd.Parameters.Add("@Id", MySqlDbType.Int64).Value = UserId;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                { 
                    con.Open();
                }
                result = Convert.ToBoolean(cmd.ExecuteScalar());
            }
            catch (MySqlException ex)
            { 
                string hata = ex.Message;
                throw;
            }
            return result;
        }
        public void personelGetbyInformation(ComboBox cb)
        { 
            cb.Items.Clear();
            MySqlConnection con = new MySqlConnection(gnl.conString);
            MySqlCommand cmd = new MySqlCommand("Select * from Personeller ", con);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                 con.Open();
            }
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cPersoneller p = new cPersoneller();
                p._PersonelId = Convert.ToInt32(dr["ID"]);
                p._PersonelGorevId = Convert.ToInt32(dr["GOREVID"]);
                p._PersonelAd = Convert.ToString(dr["AD"]);
                p._PersonelSoyad = Convert.ToString(dr["SOYAD"]);
                p._PersonelParola = Convert.ToString(dr["PAROLA"]);
                p._PersonelKullaniciAdi = Convert.ToString(dr["KULLANICIADI"]);
                p._PersonelDurum = Convert.ToInt32(dr["DURUM"]);
                cb.Items.Add(p);
            }
            dr.Close();
            con.Close();
        }
        public override string ToString()
        {
            return PersonelAd + " " + PersonelSoyad;
        }
    }
}

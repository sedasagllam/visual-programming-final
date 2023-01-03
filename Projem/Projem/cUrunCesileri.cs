using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projem
{
    internal class cUrunCesileri
    {
        cGenel gnl = new cGenel();
        #region Fields
        private int _UrunTurNo;
        private string _KategoriAd;
        private string _Aciklama;
        #endregion

        #region Properties
        public int UrunTurNo
        {
            get => _UrunTurNo;
            set => _UrunTurNo = value;
        }
        public string KategoriAd
        {
            get => _KategoriAd;
            set => _KategoriAd = value;
        }
        public string Aciklama
        {
            get => _Aciklama;
            set => _Aciklama = value;
        }
        #endregion
        public void getByProductTypes(ListView Cesitler, Button btn)
        { 
            Cesitler.Items.Clear();
            MySqlConnection conn = new MySqlConnection(gnl.conString);
            MySqlCommand comm = new MySqlCommand("Select URUNAD,FIYAT,urunler.ID From kategoriler Inner Join urunler on kategoriler.ID=urunler.KATEGORIID where urunler.KATEGORIID=@KATEGORIID", conn);
            string aa = btn.Name;
            int uzunluk = aa.Length;
            comm.Parameters.Add("@KATEGORIID", MySqlDbType.Int32).Value = aa.Substring(uzunluk - 1, 1);
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            MySqlDataReader dr = comm.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                Cesitler.Items.Add(dr["URUNAD"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["FIYAT"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["ID"].ToString());
                i++;
            }
            conn.Close();
            conn.Dispose();
        }
        public void getByProductSearch(ListView Cesitler, int txt)
        {
            Cesitler.Items.Clear();
            MySqlConnection conn = new MySqlConnection(gnl.conString);
            MySqlCommand comm = new MySqlCommand("Select * from urunler where ID=@ID", conn);
            comm.Parameters.Add("@ID", MySqlDbType.Int32).Value = txt;
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            MySqlDataReader dr = comm.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                Cesitler.Items.Add(dr["URUNAD"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["FIYAT"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["ID"].ToString());
                i++;
            }
            conn.Close();
            conn.Dispose();
        }
    }
}

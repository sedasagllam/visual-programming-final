using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projem
{
    internal class cSiparis
    {
        cGenel gnl = new cGenel();
        #region Fields
        private int _Id;
        private int _adisyonID;
        private int _urunId;
        private int _adet;
        private int _masaId;
        #endregion

        #region Properties
        public int Id
        {
            get => _Id;
            set => _Id = value;
        }
        public int AdisyonID
        {
            get => _adisyonID;
            set => _adisyonID = value;
        }
        public int UrunId
        {
            get => _urunId;
            set => _urunId = value;
        }
        public int Adet
        {
            get => _adet;
            set => _adet = value;
        }
        public int MasaId
        {
            get => _masaId;
            set => _masaId = value;
        }
        #endregion
        public void getByOrder(ListView lv, int AdisyonId)
        {
            MySqlConnection con = new MySqlConnection(gnl.conString);
            MySqlCommand cmd = new MySqlCommand("Select URUNAD,FIYAT,satislar.ID,satislate.URUNID,satislar.ADET FROM satislar Inner Join urunler on satislar.URUNID=Urunler.ID Where ADISYONLAR=@AdisyonId",con);
            MySqlDataReader dr = null;
            cmd.Parameters.Add("@AdisyonId", MySqlDbType.Int32).Value = AdisyonId;
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADET"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNID"].ToString());
                    lv.Items[sayac].SubItems.Add(Convert.ToString(Convert.ToDecimal(dr["FIYAT"]) * Convert.ToDecimal(dr["ADET"])));
                    lv.Items[sayac].SubItems.Add(dr["ID"].ToString());
                    sayac++;
                }
            }
            catch (MySqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                //dr.Close();
                con.Dispose();
                con.Close();
            }
        }
        public bool setSaveOrder(cSiparis Bilgiler)
        { 
            bool sonuc = false;
            MySqlConnection con = new MySqlConnection(gnl.conString);
            MySqlCommand cmd = new MySqlCommand("Insert Into satislar(ADISYONID,URUNID,ADET,MASAID) values(@AdisyonNo,@UrunId,@Adet,@masaId)", con);
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@AdisyonNo", MySqlDbType.Int32).Value = Bilgiler._adisyonID;
                cmd.Parameters.Add("@UrunId", MySqlDbType.Int32).Value = Bilgiler._urunId;
                cmd.Parameters.Add("@Adet", MySqlDbType.Int32).Value = Bilgiler._adet;
                cmd.Parameters.Add("@MasaId", MySqlDbType.Int32).Value = Bilgiler._masaId;
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (MySqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
            return sonuc;
        }
        public void setDeleteOrder(int satisId)
        {
            MySqlConnection con = new MySqlConnection(gnl.conString);
            MySqlCommand cmd = new MySqlCommand("Delete from Satislar where ID=@SatisID", con);
            cmd.Parameters.Add("@SatisID", MySqlDbType.Int32).Value = satisId;

            if (con.State == System.Data.ConnectionState.Closed)
            { 
                con.Open();
            }
            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();
        }
    }
}

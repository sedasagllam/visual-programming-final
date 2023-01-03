using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projem
{
    internal class cAdisyon
    {
        cGenel gnl = new cGenel();

        #region Fields
        private int _ID;
        private int _ServisTurNo;
        private decimal _Tutar;
        private DateTime _Tarih;
        private int _PersonelId;
        private int _Durum;
        private int _MasaId;
        #endregion

        #region Properties
        public int ID
        {
            get => _ID;
            set => _ID = value;
        }
        public int ServisTurNo
        {
            get => _ServisTurNo;
            set => _ServisTurNo = value;
        }
        public decimal Tutar
        {
            get => _Tutar;
            set => _Tutar = value;
        }
        public DateTime Tarih
        {
            get => _Tarih;
            set => _Tarih = value;
        }
        public int PersonelId
        {
            get => _PersonelId;
            set => _PersonelId = value;
        }
        public int Durum
        {
            get => _Durum;
            set => _Durum = value;
        }
        public int MasaId
        {
            get => _MasaId;
            set => _MasaId = value;
        }
        #endregion
        public int GetByAddition(int MasaId)
        {
            MySqlConnection con = new MySqlConnection(gnl.conString);
            MySqlCommand cmd = new MySqlCommand("Select top 1 ID from Adisyonlar Where MASAID=@MasaId Order by ID desc", con);
            cmd.Parameters.Add("@MasaId", MySqlDbType.Int64).Value = MasaId;
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                MasaId = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return MasaId;
        }
        public bool setByAdditionNew(cAdisyon Bilgiler)
        {
            bool sonuc = false;
            MySqlConnection con = new MySqlConnection(gnl.conString);
            MySqlCommand cmd = new MySqlCommand("Insert Into Adisyonlar(SERVISNO,TARİH,PERSONELID,MASAID,DURUM) values(@ServisTurNo,@Tarih,@PersonelID,@MasaId,@Durum)",con);
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@ServisTurNo", MySqlDbType.Int32).Value = Bilgiler.ServisTurNo;
                cmd.Parameters.Add("@Tarih", MySqlDbType.DateTime).Value = Bilgiler.Tarih;
                cmd.Parameters.Add("@PersonelID", MySqlDbType.Int32).Value = Bilgiler.PersonelId;
                cmd.Parameters.Add("@MasaId", MySqlDbType.Int32).Value = Bilgiler.MasaId;
                cmd.Parameters.Add("@Durum", MySqlDbType.Int32).Value = 0;
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
    }
}

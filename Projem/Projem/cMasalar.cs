using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projem
{
    internal class cMasalar
    {
        #region Fields
        private int ID;
        private int _KAPASITE;
        private int _SERVISTURU;
        private int _DURUM;
        private string ONAY;
        #endregion
        #region Properties
        public int ID1
        {
            get => ID;
            set => ID = value;
        }
        public int KAPASITE
        {
            get => _KAPASITE;
            set => _KAPASITE = value;
        }
        public int SERVISTURU
        {
            get => _SERVISTURU;
            set => _SERVISTURU = value;
        }
        public int DURUM
        {
            get => _DURUM;
            set => _DURUM = value;
        }
        public string ONAY1
        {
            get => ONAY;
            set => ONAY = value;
        }
        #endregion
        cGenel gnl = new cGenel();
        public string SessionSum(int state, string masaId)
        {
            string dt = "";
            MySqlConnection con = new MySqlConnection(gnl.conString);
            MySqlCommand cmd = new MySqlCommand("Select Tarih,MasaId From adisyonlar Right Join Masalar on adisyonlar.MasaId=Masalar.ID Where Masalar.DURUM=@durum and adisyonlar.Durum=0 and masalar.ID=@masaId", con);
            MySqlDataReader dr = null;
            cmd.Parameters.Add("@durum",MySqlDbType.Int64).Value = state;
            cmd.Parameters.Add("@masaId", MySqlDbType.Int64).Value = Convert.ToInt32(masaId);
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dt = Convert.ToDateTime(dr["Tarih"]).ToString();
                }
            }
            catch (MySqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
            return dt;
        }
        public int TableGetbyNumber(string TableValue)
        {
            string aa = TableValue;
            int length = Convert.ToInt32(aa.Length);
            if (length > 8)
            {
                return (int)Convert.ToInt64(aa.Substring(length - 2, 1));
            }
            else
            {
                return (int)Convert.ToInt64(aa.Substring(length - 1, 1));
            }
        }
        public bool TableGetbyState(int ButtonName, int state)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(gnl.conString);
            MySqlCommand cmd = new MySqlCommand("Select durum from Masalar Where Id=@TableId and DURUM=@state ",con);
            cmd.Parameters.Add("@TableId", MySqlDbType.Int64).Value = ButtonName;
            cmd.Parameters.Add("@state", MySqlDbType.Int64).Value = state;
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
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
            return result;
        }
        public void setChangeTableState(string ButonName, int durum)
        {
            MySqlConnection con = new MySqlConnection(gnl.conString);
            MySqlCommand cmd = new MySqlCommand("Update masalar Set DURUM=@Durum where ID=@MasaNo",con);
            string masaNo = "";
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            string aa = ButonName;
            int uzunluk = aa.Length;
            cmd.Parameters.Add("@Durum", MySqlDbType.Int32).Value = durum;
            if (uzunluk > 8)
            {
                masaNo = aa.Substring(uzunluk - 2, 1);
            }
            else
            {
                masaNo = aa.Substring(uzunluk - 1, 1);
            }
            cmd.Parameters.Add("@MasaNo", MySqlDbType.Int32).Value = aa.Substring(uzunluk-1, 1);
            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();
        }
    }
}

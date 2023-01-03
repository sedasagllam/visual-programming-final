using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projem
{
    internal class cPersonelHareketleri
    {
        cGenel gnl = new cGenel();
        #region Fields
        private int _ID;
        private int _PersonelId;
        private string _Islem;
        private DateTime _Tarih;
        private int _Durum;
        #endregion
        #region Properties
        public int ID
        {
            get => _ID;
            set => _ID = value;
        }
        public int PersonelId
        {
            get => _PersonelId;
            set => _PersonelId = value;
        }
        public string Islem
        {
            get => _Islem;
            set => _Islem = value;
        }
        public DateTime Tarih
        {
            get => _Tarih;
            set => _Tarih = value;
        }
        public int Durum
        {
            get => _Durum;
            set => _Durum = value;
        }
        #endregion
        public bool PersonelActionSave(cPersonelHareketleri ph)
        { 
            bool result = false;
            MySqlConnection con = new MySqlConnection(gnl.conString);
            MySqlCommand cmd = new MySqlCommand("Insert Into personelhareketleri (PERSONELID,ISLEM,TARIH) Values (@personelId,@islem,@tarih)",con);
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@personelId", MySqlDbType.Int64).Value = ph._PersonelId;
                cmd.Parameters.Add("@islem", MySqlDbType.VarChar).Value = ph._Islem;
                cmd.Parameters.Add("@tarih", MySqlDbType.DateTime).Value = ph._Tarih;
                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (MySqlException ex)
            {
                string hata = ex.Message;
                //throw;
            }
            return result;
        }
    }
}

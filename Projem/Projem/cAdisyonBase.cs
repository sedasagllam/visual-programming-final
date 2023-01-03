using MySql.Data.MySqlClient;

namespace Projem
{
    internal class cAdisyonBase
    {
        cGenel gnl = new cGenel();
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
    }
}
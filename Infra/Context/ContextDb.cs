using CategoryBankTrades.Model;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace CategoryBankTrades.Infra.Context
{
    public class ContextDb : DbContext
    {
        string connection;
        public ContextDb()
        {
            var builder = WebApplication.CreateBuilder();
            connection = builder.Configuration.GetConnectionString("SqlConnection");
        }
       
        public List<Trade> GetTrades(string sqlCommand)
        {
            List<Trade> tradeList = new List<Trade>();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                var trade = new Trade();
                                trade.id = Convert.ToInt32(reader["id"]);
                                trade.Value = Convert.ToDouble(reader["value"]);
                                trade.ClientSector = reader["ClientSector"].ToString();
                                trade.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                                tradeList.Add(trade);
                            }
                        }
                    }
                }
                conn.Close();
            }
            return tradeList;
        }

        public int CreateOrUpdateTrade(string sqlCommand)
        {
            int response;
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, conn))
                {
                    response = cmd.ExecuteNonQuery();
                }
                conn.Close();
                return response;
            }
        }
    }
}

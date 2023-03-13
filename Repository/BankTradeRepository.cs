using CategoryBankTrades.Infra.Context;
using CategoryBankTrades.Model;
using CategoryBankTrades.Repository.Interface;

namespace CategoryBankTrades.Repository
{
    public class BankTradeRepository : IBankTradeRepository
    {

        public readonly ContextDb _context;
        public BankTradeRepository(ContextDb context)
        {
            _context = context;
        }

        public List<Trade> GetAllTrades()
        {
            var sqlCommand = "SELECT * FROM Trades";
            return _context.GetTrades(sqlCommand).ToList();

        }

        public void CreateTrade(double value, string clientSector)
        {
            var sqlCommand = $"INSERT INTO Trades (Value, ClientSector) VALUES ({value}, '{clientSector.ToUpper()}');";
            var response = _context.CreateOrUpdateTrade(sqlCommand);
            if (response == 0)
            {
                throw new Exception("Internal Server Error.");
            }
        }

        public void UpdateTrade(int id, double? value, string? clientSector)
        {
            var sqlCommand = $"UPDATE Trades  SET ";
            if (value.HasValue)
            {
                sqlCommand = sqlCommand + $"Value = {value} ";
            }
            if (!string.IsNullOrEmpty(clientSector))
            {
                if (value.HasValue)
                {
                    sqlCommand = sqlCommand + ",";
                }
                sqlCommand = sqlCommand + $"ClientSector = '{clientSector.ToUpper()}' ";
            }
            sqlCommand = sqlCommand + $"WHERE id = {id};";
            var response = _context.CreateOrUpdateTrade(sqlCommand);
            if (response == 0)
            {
                throw new Exception("Internal Server Error.");
            }
        }

        public void DeleteTrade(int id, byte isDeleted)
        {
            var sqlCommand = $"UPDATE Trades  SET IsDeleted = {isDeleted} WHERE id = {id};";
            var response = _context.CreateOrUpdateTrade(sqlCommand);
            if (response == 0)
            {
                throw new Exception("Internal Server Error.");
            }
        }
    }
}

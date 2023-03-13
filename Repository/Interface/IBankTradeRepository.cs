using CategoryBankTrades.Model;

namespace CategoryBankTrades.Repository.Interface
{
    public interface IBankTradeRepository
    {
        List<Trade> GetAllTrades();
        void CreateTrade(double value, string clientSector);
        void UpdateTrade(int id, double? value, string? clientSector);
        void DeleteTrade(int id, byte isDeleted);
    }
}

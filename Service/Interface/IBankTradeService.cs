using CategoryBankTrades.Model;
using CategoryBankTrades.Model.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CategoryBankTrades.Service.Interface
{
    public interface IBankTradeService
    {
        List<Trade> GetAllTrades();
        List<string> GetCategoryTrades(List<Trade> trade);
        string CreateTrade(double value, string clientSector);
        string UpdateTrade(int id, double value, string? clientSector);
        string DeleteTrade(int id, bool isDeleted);
    }
}

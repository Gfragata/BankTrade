using CategoryBankTrades.Model.Interface;
using CategoryBankTrades.Model;
using CategoryBankTrades.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using CategoryBankTrades.Repository.Interface;

namespace CategoryBankTrades.Service
{
    public class BankTradeService : IBankTradeService
    {
        public readonly IBankTradeRepository _bankTradeRepository;
        public BankTradeService(IBankTradeRepository bankTradeRepository)
        {
            _bankTradeRepository = bankTradeRepository;
        }

        public List<Trade> GetAllTrades()
        {
            return _bankTradeRepository.GetAllTrades();
        }

        public List<string> GetCategoryTrades(List<TradesToCategory> trade)
        {
            List<string> categories = new List<string>();
            foreach (var t in trade)
            {
                if (t.Value < 1000000 && t.ClientSector == "Public Sector")
                {
                    categories.Add("LOWRISK");
                }
                else if (t.Value >= 1000000 && t.ClientSector == "Public Sector")
                {
                    categories.Add("MEDIUMRISK");
                }
                else if (t.Value >= 1000000 && t.ClientSector == "Private Sector")
                {
                    categories.Add("HIGHRISK");
                }
                else
                {
                    categories.Add("Invalid Operation");
                }
            }

            return categories;
        }

        public string CreateTrade(double value, string clientSector)
        {
            if (value == 0)
            {
                throw new Exception("The value is not valid.");
            }
            else if (string.IsNullOrEmpty(clientSector))
            {
                throw new Exception("The Sector is not reported.");
            } else if (clientSector != "private sector" && clientSector != "public sector")
            {
                throw new Exception("Inform a valid sector");
            }

            _bankTradeRepository.CreateTrade(value, clientSector);
            return "New trade was created";
        }

        public string UpdateTrade(int id, double? value, string? clientSector)
        {
            if (id == 0)
            {
                throw new Exception("The trade id isn't reported.");
            }
            else if (!value.HasValue && string.IsNullOrEmpty(clientSector))
            {
                throw new Exception("It's necessary report one value or one sector");
            } else if (clientSector != "private sector" && clientSector != "public sector")
            {
                throw new Exception("Inform a valid sector");
            }

            _bankTradeRepository.UpdateTrade(id, value, clientSector);

            return "Trade has been updated!";
        }

        public string DeleteTrade(int id, bool isDeleted)
        {
            if (id == 0)
            {
                throw new Exception("The trade id isn't reported.");
            }

            _bankTradeRepository.DeleteTrade(id, Convert.ToByte(isDeleted));

            if (isDeleted)
            {
                return "Trade has been deleted!";
            }
            else
            {
                return "Trade has come back!";
            }

        }
    }
}


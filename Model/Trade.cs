using CategoryBankTrades.Model.Interface;

namespace CategoryBankTrades.Model
{
    public class Trade : ITrade
    {
        public int? id { get; set; }
        public double Value { get; set; }
        public string ClientSector { get; set; }
        public bool IsDeleted { get; set; }

    }
}

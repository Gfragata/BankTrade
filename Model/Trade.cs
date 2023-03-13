namespace CategoryBankTrades.Model
{
    public class Trade
    {
        public int? id { get; set; }
        public double Value { get; set; }
        public string ClientSector { get; set; }
        public bool IsDeleted { get; set; }

    }
}

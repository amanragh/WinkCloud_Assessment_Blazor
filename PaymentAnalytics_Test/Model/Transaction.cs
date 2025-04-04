namespace PaymentAnalytics_Test.Model
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime Timestamp { get; set; }
        public string CustomerName { get; set; } = "";
        public string TransactionType { get; set; } = "";
        public decimal Amount { get; set; }
        public string Result { get; set; } = "";
    }
}

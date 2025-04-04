namespace PaymentAnalytics_Test.Model
{
    public class KeyCustomer
    {
        public int CustomerKey { get; set; }
        public string? CustomerName { get; set; }
        public int TransactionCount { get; set; }
        public decimal TransactionAmount { get; set; }
    }
}

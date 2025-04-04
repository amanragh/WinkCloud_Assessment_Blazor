using Microsoft.Extensions.Diagnostics.HealthChecks;
using PaymentAnalytics_Test.Model;
using System.Net.Http;
using System.Net.Http.Headers;


namespace PaymentAnalytics_Test.Service
{
    public class TransactionService
    {
        public HttpClient httpClient { get; set; }
        public string requestUri = "https://demo.payment-gate.net/api/dashboard?RangeStart=01/04/2025&RangeEnd=03/04/2025&GrowthRangeStart=01/04/2025&GrowthRangeEnd=03/04/2025";
        public TransactionService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Transaction>> GetTransactions(string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await httpClient.GetFromJsonAsync<AllTransactions> (requestUri);
            return response!.RecentTransactions;
        }

        public async Task<List<KeyCustomer>> GetKeyCustomers(string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await httpClient.GetFromJsonAsync<AllKeyCustomers>(requestUri);
            return response!.KeyCustomers;
        }
    }

    public class AllTransactions
    {
        public List<Transaction> RecentTransactions { get; set; } = new();
    }

    public class AllKeyCustomers
    {
        public List<KeyCustomer> KeyCustomers { get; set; } = new();
    }


}

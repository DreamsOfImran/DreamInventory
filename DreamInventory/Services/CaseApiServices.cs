using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DreamInventory.Services
{
    public class CaseApiServices
    {
        public List<Cases> GetCases()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };

            using (var client = new HttpClient(handler))
            {
                //send a GET request
                string uri = "https://localhost:5001/cases?pageNumber=1&pageSize=20";
                var response = client.GetStringAsync(uri);
                var result = response.GetAwaiter().GetResult();

                //handling the answer
                var CasesList = JsonConvert.DeserializeObject<List<Cases>>(result);

                return CasesList;
            };
        }

        public async Task<bool> AddCaseAsync(string type, decimal? amount,
            string courtType, string caseType, DateTime? fillingDate,
            string judge, string docketType, string description,
            string caseNo, string caseUrl)
        {
            var client = new HttpClient();

            var model = new Cases
            {
                Type = type,
                Amount = amount,
                CourtType = courtType,
                CaseType = caseType,
                FillingDate = fillingDate,
                Judge = judge,
                DocketType = docketType,
                Description = description,
                CaseNo = caseNo,
                CaseUrl = caseUrl
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("https://localhost:5001/cases", content);

            return response.IsSuccessStatusCode;
        }
    }
}

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace DreamInventory.ViewModels
{
    public class CasesViewModel
    {
        public CasesViewModel()
        {
            GetCases();
        }

        private void GetCases()
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
                string uri = "https://localhost:5001/cases";
                var response = client.GetStringAsync(uri);
                var result = response.GetAwaiter().GetResult();

                //handling the answer
                var CasesList = JsonConvert.DeserializeObject<List<Cases>>(result);

                CasesCollection = new ObservableCollection<Cases>(CasesList);
            };
        }

        public ObservableCollection<Cases> CasesCollection { get; private set; }
    }
}

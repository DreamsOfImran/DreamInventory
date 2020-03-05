using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace DreamInventory.Helpers
{
    public class CaseModelHelper
    {
        public CaseModelHelper()
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

                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                //send a GET request
                // var uri = "https://localhost:5001/cases/8";
                // var result = await client.GetStringAsync(uri);

                string uri = "https://localhost:5001/cases";
                var response = client.GetStringAsync(uri);
                var result = response.GetAwaiter().GetResult();

                //handling the answer
                var CasesList = JsonConvert.DeserializeObject<List<Cases>>(result);

                CasesTest = new ObservableCollection<Cases>(CasesList);
            };
        }

        public ObservableCollection<Cases> CasesTest { get; private set; }
    }
}

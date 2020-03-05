using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;

namespace DreamInventory.Services
{
    public class PlaintiffApiService
    {
        public ObservableCollection<Plaintiffs> GetPlaintiffs()
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
                string uri = "https://localhost:5001/plaintiffs?pageNumber=1&pageSize=20";
                var response = client.GetStringAsync(uri);
                var result = response.GetAwaiter().GetResult();

                //handling the answer
                var PlaintiffsList = JsonConvert.DeserializeObject<List<Plaintiffs>>(result);

                PlaintiffsCollection = new ObservableCollection<Plaintiffs>(PlaintiffsList);

                return PlaintiffsCollection;
            };
        }

        public ObservableCollection<Plaintiffs> PlaintiffsCollection { get; private set; }
    }
}

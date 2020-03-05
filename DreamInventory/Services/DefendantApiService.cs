using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;

namespace DreamInventory.Services
{
    public class DefendantApiService
    {
        public ObservableCollection<Defendants> GetDefendants()
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
                string uri = "https://localhost:5001/defendants?pageNumber=1&pageSize=20";
                var response = client.GetStringAsync(uri);
                var result = response.GetAwaiter().GetResult();

                //handling the answer
                var DefendantsList = JsonConvert.DeserializeObject<List<Defendants>>(result);

                DefendantsCollection = new ObservableCollection<Defendants>(DefendantsList);

                return DefendantsCollection;
            };
        }

        public ObservableCollection<Defendants> DefendantsCollection { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace DreamInventory.Services
{
    public class DefendantApiService
    {
        public static string BaseAddress = Device.RuntimePlatform == Device.Android ? "https://10.0.2.2:5001" : "https://localhost:5001";

        public HttpClientHandler GetInsecureHandler()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }

        public ObservableCollection<Defendants> GetDefendants()
        {
            using (var client = new HttpClient(GetInsecureHandler()))
            {
                string uri = $"{BaseAddress}/defendants?pageNumber=1&pageSize=20";
                var response = client.GetStringAsync(uri);
                string result = response.GetAwaiter().GetResult();

                //handling the answer
                var DefendantsList = JsonConvert.DeserializeObject<List<Defendants>>(result);

                DefendantsCollection = new ObservableCollection<Defendants>(DefendantsList);

                return DefendantsCollection;
            };
        }

        public ObservableCollection<Defendants> DefendantsCollection { get; private set; }

    }
}

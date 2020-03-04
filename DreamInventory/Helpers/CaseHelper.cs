using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using Justice;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace DreamInventory.Models
{
    public class CaseHelper : ContentPage
    {
        public CaseHelper()
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

                string uri = "https://localhost:5001/cases/8";
                var response = client.GetStringAsync(uri);
                var result = response.GetAwaiter().GetResult();

                //handling the answer
                var CasesList = JsonConvert.DeserializeObject<List<Cases>>(result);

                Cases = new ObservableCollection<Cases>(CasesList);
            };
        }

        public ObservableCollection<Cases> Cases { get; private set; }
    }
}


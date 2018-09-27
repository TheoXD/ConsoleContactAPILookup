using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using Nito.AsyncEx;

using RestSharp;
using RestSharp.Authenticators;



namespace FullContactAPILib
{
    public class FullContactAPI : IFullContactApi
    {
        private string APIKey;

        public FullContactAPI() { }
        public FullContactAPI(string _APIKey) {
            this.APIKey = _APIKey;
        }

        public Task<FullContactPerson> LookupPersonByEmailAsync(string _email)
        {
            var client = new RestClient("https://api.fullcontact.com");
            
            var request = new RestRequest("v2/person.json?email=" + _email, Method.GET);

            request.AddHeader("X-FullContact-APIKey", this.APIKey);

            IRestResponse<FullContactPerson> response = client.Execute<FullContactPerson>(request);

            return Task.FromResult<FullContactPerson>(response.Data);
        }

    }
}

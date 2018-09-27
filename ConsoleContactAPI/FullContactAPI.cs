using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using Nito.AsyncEx;

using RestSharp;
using RestSharp.Authenticators;



namespace ConsoleContactAPI
{

    public class FullContactAPI : IFullContactApi
    {
        public Task<FullContactPerson> LookupPersonByEmailAsync(string _email)
        {
            var client = new RestClient("https://api.fullcontact.com");
            
            var request = new RestRequest("v2/person.json?email=" + _email, Method.GET);

            string api_key = DefaultConfig.APIKey;
            if (Config.Instance.APIKey.Length > 0)
            {
                api_key = Config.Instance.APIKey;
            }

            request.AddHeader("X-FullContact-APIKey", api_key);

            IRestResponse<FullContactPerson> response = client.Execute<FullContactPerson>(request);

            return Task.FromResult<FullContactPerson>(response.Data);
        }

    }
}

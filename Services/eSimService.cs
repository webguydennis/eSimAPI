using RestSharp;
using Newtonsoft.Json;
using System.Threading.Tasks;
using eSimAPI.Models;

namespace eSimAPI.Services {
    public class EsimService
    {
        private readonly RestClient _client;
        
        public EsimService(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public async Task<Profile> ProvisionEsimAsync(string activationCode)
        {
            var request = new RestRequest("api/esim/provision", Method.Post);
            request.AddJsonBody(new { ActivationCode = activationCode });

            var response = await _client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                var esimProfile = JsonConvert.DeserializeObject<Profile>(response.Content);
                return esimProfile;
            }
            else
            {
                throw new Exception($"Failed to provision e-SIM: {response.ErrorMessage}");
            }
        }

        public async Task<bool> ActivateEsimAsync(string esimId)
        {
            var request = new RestRequest($"api/esim/{esimId}/activate", Method.Put);

            var response = await _client.ExecuteAsync(request);
            return response.IsSuccessful;
        }
    }
}

using System.Net.Http;
using System.Text.Json;
using CEP.Domain.Entities;
using CEP.Domain.IRepository;

namespace CEP.Infra.Repositories
{
    public class CepApiRepository : ICepApiRepository
    {
        private readonly HttpClient _http;

        public CepApiRepository()
        {
            _http = new HttpClient();
            // var x = "https://viacep.com.br/ws/" + cep + "/json/";
        }

        public Cep GetCep(string cep)
        {
            var response = _http.GetAsync($"https://viacep.com.br/ws/{cep}/json/").Result;

            if (!response.IsSuccessStatusCode) return default;
            
            var responseContent = response.Content; 

            var responseString = responseContent.ReadAsStringAsync().Result;
            var test = JsonSerializer.Deserialize<CepError>(responseString, SerializerOptions);
            if (test is {Erro: true}) return default;
            return JsonSerializer.Deserialize<Cep>(responseString, SerializerOptions);
            

        }
        
        private static JsonSerializerOptions SerializerOptions => new() { PropertyNameCaseInsensitive = true };



    }

    public class CepError
    {
        public bool Erro { get; set; }
    }


}
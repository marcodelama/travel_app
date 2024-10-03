using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace travel_app.Services
{
    public class ApiService
    {
        private static readonly HttpClient _client = new HttpClient();
        private readonly string _baseUrl = "http://192.168.18.4:4000/api/v1/";
        public async Task<T> GetAsync<T>(string endpoint)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_baseUrl + endpoint);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(jsonResponse);
                }
                return default(T);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al realizar la solicitud: {ex.Message}");
                throw;
            }
        }


        // Método genérico para enviar datos a la API (POST)
        public async Task<T> PostAsync<T>(string endpoint, object data)
        {
            using (HttpClient client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(_baseUrl + endpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseJson = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(responseJson);
                }

                throw new Exception($"Error: {response.StatusCode}, Message: {response.ReasonPhrase}");
            }
        }

    }
}

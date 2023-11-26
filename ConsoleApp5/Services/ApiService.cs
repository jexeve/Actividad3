using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Configuration;
using static System.Net.WebRequestMethods;

namespace ConsoleApp5.Service
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private string _apiUrl;

        public ApiService()
        {
            _apiUrl = "http://api.tutiempo.net/json/?lan=es&apid=XCEXq4qazz49z4S&lid=56608";
            _httpClient = new HttpClient();
        }

        public async Task<string> GetDataFromApiAsync()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return apiResponse;
                }
                else
                {
                    Console.WriteLine($"Error en la solicitud. Código de estado: {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al consumir la API: {ex.Message}");
                return null;
            }
            finally
            {
                _httpClient.Dispose();
            }
        }
    }
}

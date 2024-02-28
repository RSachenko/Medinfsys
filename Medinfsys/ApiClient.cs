using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Medinfsys
{
    public class ApiClient
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<string> GetPersonLocations()
        {
            string apiUrl = "http://10.30.76.66:8082/PersonLocations";

            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                // Обработка ошибок, например, вывод в лог или обновление интерфейса
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}

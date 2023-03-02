using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Febogotchi_administration
{
    public class ApiSender
    {
        HttpClient client = new HttpClient();
        public async void CreateUser(string username,string password,string token)
        {
            string url = "http://localhost:8881/api/admin/users?=";
            var registerdata = new
            {
                name = username,
                password = password
            };
            string jsonRequestData = JsonSerializer.Serialize(registerdata);
            var content = new StringContent(jsonRequestData, System.Text.Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                // Get the response data
                string responseData = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Sikeres regisztráció!");
            }
            else
            {
                MessageBox.Show("Sikertelen regisztráció!");
            }
        }
    }
}

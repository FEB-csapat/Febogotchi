using System;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Febogotchi_administration
{
    public class ApiSender
    {
        HttpClient client = new HttpClient();
        public string token { get; set; }
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
            //TODO: move authentication to global
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Sikeres regisztráció!");
            }
            else
            {
                MessageBox.Show("Sikertelen regisztráció!");
            }
        }
        public async void Login(string username,string password,LoginWindow window)
        {
            string url = "http://localhost:8881/api/login";
            var registerdata = new
            {
                name = username,
                password = password
            };
            string jsonRequestData = JsonSerializer.Serialize(registerdata);
            var content = new StringContent(jsonRequestData, System.Text.Encoding.UTF8, "application/json");
            //TODO: move authentication to global
            HttpResponseMessage response = await client.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                JsonDocument jsondata = JsonDocument.Parse(responseData);
                token = jsondata.RootElement.GetProperty("token").GetString();
                MessageBoxResult result = MessageBox.Show("Sikeres bejelentkezés", "Bejelentkezés", MessageBoxButton.OK);

                switch (result)
                {
                    case MessageBoxResult.OK:
                        MainWindow mainwindow = new MainWindow(this.token);
                        mainwindow.Show();
                        window.Close();
                        break;

                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Sikertelen bejelentkezés", "Bejelentkezés", MessageBoxButton.OK);
            }
        }
    }
}

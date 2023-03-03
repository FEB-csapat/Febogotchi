using System;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace Febogotchi_administration
{
    public class ApiSender
    {
        HttpClient client = new HttpClient();
        public string token { get; set; }
        public string message { get; set; }
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
                string responseData = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Sikeres regisztráció!");
            }
            else
            {
                MessageBox.Show("Sikertelen regisztráció!");
            }
        }
        public async void Login(string username,string password)
        {
            string url = "http://localhost:8881/api/login";
            var registerdata = new
            {
                name = username,
                password = password
            };
            string jsonRequestData = JsonSerializer.Serialize(registerdata);
            var content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");
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
                        break;
                }
            }
            else
            {
                message = "Password mismatch";
                MessageBoxResult result = MessageBox.Show("Sikertelen bejelentkezés", "Bejelentkezés", MessageBoxButton.OK);
            }
        }
        public async void UpdateUser(int userid,string username, string password,string token)
        {
            string url = "http://localhost:8881/api/admin/users/" + userid;
            var updateddata = new
            {
                name = username,
                password = password
            };
            string jsonRequestData = JsonSerializer.Serialize(updateddata);
            var content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.PutAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Sikeresen megváltosztatta a jelszavat!");
            }
            else
            {
                MessageBox.Show("Sikertelen jelszóváltoztatás!");
            }
        }
        public async void DeleteUser(int userid, string token)
        {
            string url = "http://localhost:8881/api/admin/users/" + userid;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Sikeresen törölte a felhasználót!");
            }
            else
            {
                MessageBox.Show("Sikertelen törlés!");
            }
        }
    }
}

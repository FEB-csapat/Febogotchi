using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Windows;

namespace Febogotchi_administration
{
    public class ApiReader
    {
        HttpClient kliens = new HttpClient();
        public ApiReader(string base_url)
        {
            kliens.BaseAddress = new Uri(base_url);
            kliens.DefaultRequestHeaders.Accept.Clear();
            kliens.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public Users GetUser(string path)
        {
            Users visszateres = null;
            HttpResponseMessage valasz = kliens.GetAsync(path).Result;
            if (valasz.IsSuccessStatusCode)
            {
                string str = valasz.Content.ReadAsStringAsync().Result;
                visszateres = JsonSerializer.Deserialize<Users>(str);
            }
            return visszateres;
        }
        public Users[] GetUsers(string path)
        {
            Users[] visszateres = null;
            HttpResponseMessage valasz = kliens.GetAsync(path).Result;
            if (valasz.IsSuccessStatusCode)
            {
                string str = valasz.Content.ReadAsStringAsync().Result;
                visszateres = JsonSerializer.Deserialize<Users[]>(str);
            }
            return visszateres;
        }
    }
}

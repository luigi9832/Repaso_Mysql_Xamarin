using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Repaso_Mysql_Xamarin.Classes
{
    class Estudiante_Manager
    {
        private HttpClient getCliente()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");
            return client;
        }
        public async Task<IEnumerable<Estudiante>> getUsuarios()
        {
            HttpClient client = getCliente();
            var res = await client.GetAsync(App.url + "verUser.php");
            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Estudiante>>(content);
            }
            return Enumerable.Empty<Estudiante>();
        }

        public async Task<IEnumerable<Estudiante>> TraerEstudiantes(string rne)
        {
            HttpClient client = getCliente();
            var res = await client.GetAsync(App.url + "verUser.php?rne=" + rne);
            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Estudiante>>(content);
            }
            return Enumerable.Empty<Estudiante>();
        }
    }
}

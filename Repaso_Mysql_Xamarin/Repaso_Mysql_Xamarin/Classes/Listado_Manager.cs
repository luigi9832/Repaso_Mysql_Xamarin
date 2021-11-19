using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Repaso_Mysql_Xamarin.Classes
{
    class Listado_Manager
    {
        private HttpClient getCliente()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");
            return client;
        }

        public async Task<IEnumerable<Listado>> TraerEstudiantes(String anio)
        {
            HttpClient client = getCliente();
            var res = await client.GetAsync(App.url + "verUser1.php?anio=" + anio);
            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Listado>>(content);
            }
            return Enumerable.Empty<Listado>();
        }
    }
}

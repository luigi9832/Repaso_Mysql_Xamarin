using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Repaso_Mysql_Xamarin.Classes;
using Xamarin.Forms.Xaml;

namespace Repaso_Mysql_Xamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            if (verifBD())
            {
                
            }
            else
            {
                cerrar();
            }
        }

        public async void cerrar()
        {
            await DisplayAlert("Mensaje", "Problemas de Conectividad. La aplicacion se va a cerrar", "OK");
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        private bool verifBD()
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                byte[] response = cliente.UploadValues(App.url + "conexion2.php", "POST", parametros);
                string c = Encoding.ASCII.GetString(response);
                //DisplayAlert("Mensaje", c, "OK");
                if (c.Equals("1")) return true;
                else return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

       

      

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        private async void Alumnos_Perfil(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Perfil_Alumno());
        }

        private async void Listado_Septimo(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Listado_Septimo());
        }

    }
}

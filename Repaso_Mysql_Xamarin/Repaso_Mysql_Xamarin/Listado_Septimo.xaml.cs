using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repaso_Mysql_Xamarin.Classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Repaso_Mysql_Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Listado_Septimo : ContentPage
    {
        public Listado_Septimo()
        {
            InitializeComponent();
        }
        private async void traerEstudiantes(String anio)
        {
            
            try
            {
                Listado_Manager manager = new Listado_Manager();
                var res = await manager.TraerEstudiantes(anio);
                if (res != null)
                {
                    lstEstudent.ItemsSource = res;
                }
            }
            catch (Exception e)
            {
                await DisplayAlert("Mensaje de Error", e.Message.ToString(), "OK");
            }
        }

        private void Alumnos_Perfil(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAnio.Text))
            {

            }
            else traerEstudiantes(txtAnio.Text);
        }
    }
}
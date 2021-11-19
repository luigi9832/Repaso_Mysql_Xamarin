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
    public partial class Perfil_Alumno : ContentPage
    {
        public Perfil_Alumno()
        {
            InitializeComponent();
        }

        private async void traerEstudiantes(string rne)
        {
            try
            {
                Estudiante_Manager manager = new Estudiante_Manager();
                var res = await manager.TraerEstudiantes(rne);
                if (res != null)
                {
                    lstEstudents.ItemsSource = res;
                }
            }
            catch (Exception e)
            {
                await DisplayAlert("Mensaje de Error", e.Message.ToString(), "OK");
            }
        }

        private void Alumnos_Perfil(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEstudiante.Text))
            {

            }
            else traerEstudiantes(txtEstudiante.Text);
        }
    }
}
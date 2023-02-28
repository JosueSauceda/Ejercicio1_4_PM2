using Ejercicio4.Controller;
using Ejercicio4.View;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio4
{
    public partial class App : Application
    {
        static DB_Empleados basedatos;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Empleados_List());
        }
        public static DB_Empleados BaseDatos
        {
            get
            {
                if (basedatos == null)
                {
                    basedatos = new DB_Empleados(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DB_Empleados.db3"));
                }
                return basedatos;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
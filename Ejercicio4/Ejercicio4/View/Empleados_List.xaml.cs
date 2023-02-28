using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ejercicio4.Model;

namespace Ejercicio4.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Empleados_List : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public Empleados_List()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            listapersonas.ItemsSource = await App.BaseDatos.obtenerListaEmple();
        }


        private async void listapersonas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var persona = (Empleados)e.Item;
            Image page = new Image();
            page.BindingContext = persona;
            await Navigation.PushAsync(page);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travel_app.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace travel_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lugares : ContentPage
    {
        public Lugares()
        {
            InitializeComponent();
            boton.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new HotelesPage());
            };
        }
        async void OnDetailsButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Machu Pichu", "- Ubicado en los Andes peruanos, a 2,430 metros sobre el nivel del mar.\n\n" +
                     "- Construida en la ciudad inca del siglo XV.\n\n" +
                     "- Estructuras de piedra ensambladas sin mortero.\n\n" +
                     "- Rodeada de montañas y selva tropical.\n\n" +
                     "- Sitio arqueológico y Patrimonio de la Humanidad.\n\n" +
                     "- Es una de las Nuevas Siete Maravillas del Mundo.", "Cerrar");
        }
        async void OnValleButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Valle Del Colca", "- Ubicado en el Sur de Perú, en la región de Arequipa.\n\n" +
                     "- Esta aproximadamente 3,270 metros, uno de los cañones más profundos del mundo.\n\n" +
                     "- Paisaje andino con terrazas agrícolas preincaicas.\n\n" +
                     "- Hogar de cóndores andinos y otros animales autóctonos.\n\n" +
                     "- Destino popular para senderismo y avistamiento de cóndores.\n\n" +
                     "- Poblaciones locales conservan tradiciones y vestimenta típica.", "Cerrar");
        }
        async void OnResdeButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Titicaca", "- Ubicado entre Perú y Bolivia.\n\n" +
                     "- Esta aproximadamente 36,180 hectáreas protegidas.\n\n" +
                     "- Ecosistema lacustre, con islas flotantes y vegetación acuática.\n\n" +
                     "- Hogar de especies endémicas como el zambullidor del Titicaca y la rana gigante.\n\n" +
                     "- Comunidades indígenas Uros habitan en islas flotantes de totora.\n\n" +
                     "- Conservación de biodiversidad y patrimonio cultural del altiplano andino.", "Cerrar");
        }
        async void OnArdeButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Arequipa", "- Ubicado en el Sur de Perú, a 2,335 metros sobre el nivel del mar.\n\n" +
                     "- Llamada la Ciudad Blanca por sus edificios de sillar, una piedra volcánica clara.\n\n" +
                     "- Rodeada de tres volcanes, destacando el Misti.\n\n" +
                     "- Es el centro histórico Patrimonio de la Humanidad por la UNESCO.\n\n" +
                     "- Famosa por platos típicos como el rocoto relleno y el adobo.\n\n" +
                     "- Rica en historia colonial y arquitectura barroca mestiza.", "Cerrar");
        }
    }
}
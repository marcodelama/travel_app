using System;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using travel_app;
using travel_app.Services;
using travel_app.Views;
using Xamarin.Forms;


namespace travel_app.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string username;
        private string password;
        private bool isLoading;
        private ApiService client;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public bool IsLoading
        {
            get => isLoading;
            set
            {
                isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
            client = new ApiService();
        }


        private async Task Login()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Por favor, complete todos los campos", "OK");
                return;
            }

            IsLoading = true;

            try
            {
                var loginData = new
                {
                    username = Username,
                    password = Password
                };

                // Hacer la solicitud POST a la API
                var response = await client.PostAsync("usuario/login", loginData);

                // Si llegas aquí, asumimos que la respuesta fue exitosa
                await App.Current.MainPage.DisplayAlert("Éxito", "Inicio de sesión exitoso", "OK");

                // Redirigir a HomePage.xaml sin comprobar el estado de la respuesta
                Application.Current.MainPage = new NavigationPage(new HomePage());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Ocurrió un error al iniciar sesión", "OK");
            }
            finally
            {
                IsLoading = false;
            }
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
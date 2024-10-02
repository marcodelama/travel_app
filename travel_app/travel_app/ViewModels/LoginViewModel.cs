using System;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using travel_app;
using Xamarin.Forms;


namespace travel_app.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string username;
        private string password;
        private bool isLoading;

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
                // Creación del cliente HTTP
                using (HttpClient client = new HttpClient())
                {
                    var loginData = new
                    {
                        email = Username,
                        password = Password
                    };

                    var json = JsonConvert.SerializeObject(loginData);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Hacer la solicitud POST a la API
                    HttpResponseMessage response = await client.PostAsync("usuario/login", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        // Procesar la respuesta según la estructura de tu API
                        await App.Current.MainPage.DisplayAlert("Éxito", "Inicio de sesión exitoso", "OK");
                        // Navegar a la siguiente página aquí
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "Credenciales inválidas", "OK");
                    }
                }
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
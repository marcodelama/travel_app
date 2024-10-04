using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using travel_app.Services;
using System.Threading.Tasks;
using System;
using travel_app;

namespace travel_app.ViewModels
{
    public class RegistrarViewModel : INotifyPropertyChanged
    {
        private string nombre;
        private string apellido;
        private string dni;
        private string telefono;
        private string correo;
        private string contraseña;
        private bool isLoading;

    public event PropertyChangedEventHandler PropertyChanged;

    public string Nombre
    {
        get => nombre;
        set
        {
            nombre = value;
            OnPropertyChanged(nameof(Nombre));
        }
    }

    public string Apellido
    {
        get => apellido;
        set
        {
            apellido = value;
            OnPropertyChanged(nameof(Apellido));
        }
    }

    public string Dni
    {
        get => dni;
        set
        {
            dni = value;
            OnPropertyChanged(nameof(Dni));
        }
    }

    public string Telefono
    {
        get => telefono;
        set
        {
            telefono = value;
            OnPropertyChanged(nameof(Telefono));
        }
    }

    public string Correo
    {
        get => correo;
        set
        {
            correo = value;
            OnPropertyChanged(nameof(Correo));
        }
    }

    public string Contraseña
    {
        get => contraseña;
        set
        {
            contraseña = value;
            OnPropertyChanged(nameof(Contraseña));
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

    public ICommand RegistrarCommand { get; }

    public RegistrarViewModel()
    {
        RegistrarCommand = new Command(async () => await Registrar());
    }

    private async Task Registrar()
    {
        if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Apellido) ||
            string.IsNullOrWhiteSpace(Dni) || string.IsNullOrWhiteSpace(Telefono) ||
            string.IsNullOrWhiteSpace(Correo) || string.IsNullOrWhiteSpace(Contraseña))
        {
            await App.Current.MainPage.DisplayAlert("Error", "Por favor, completa todos los campos.", "OK");
            return;
        }

        IsLoading = true;

        try
        {
            var clienteData = new
            {
                num_dni = Dni,
                nombre = Nombre,
                apellido = Apellido,
                username = Correo,
                password = Contraseña,
                telefono = Telefono
            };

            var apiService = new ApiService();
            var resultado = await apiService.PostAsync("usuario/cliente/create", clienteData);

            await App.Current.MainPage.DisplayAlert("Éxito", $"Usuario registrado: {resultado.Mensaje}", "OK");
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
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
using FUMiniHotelSystem.BusinessLogic;
using FUMiniHotelSystem.Models;
using FUMiniHotelSystem.Views;
using System.Windows;
using System.Windows.Input;

namespace FUMiniHotelSystem.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IAuthenticationService _authenticationService;
        private string _email;
        private string _password;

        public LoginViewModel()
        {
            _authenticationService = new AuthenticationService();
            LoginCommand = new RelayCommand(Login);
            _email = "";
            _password = "";
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public ICommand LoginCommand { get; }

        private void Login(object parameter)
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Please enter email and password.", "Login Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_authenticationService.AuthenticateAdmin(Email, Password))
            {
                var adminWindow = new AdminWindow();
                adminWindow.Show();
                Application.Current.MainWindow?.Close();
                return;
            }

            var customer = _authenticationService.AuthenticateCustomer(Email, Password);
            if (customer != null)
            {
                var customerWindow = new CustomerWindow(customer);
                customerWindow.Show();
                Application.Current.MainWindow?.Close();
                return;
            }

            MessageBox.Show("Invalid email or password.", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

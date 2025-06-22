using FUMiniHotelSystem.BusinessLogic;
using FUMiniHotelSystem.Models;
using FUMiniHotelSystem.Views;
using System.Windows;
using System.Windows.Input;

namespace FUMiniHotelSystem.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        private readonly ICustomerService _customerService;
        private Customer _currentCustomer;

        public CustomerViewModel(Customer customer)
        {
            _customerService = new CustomerService();
            _currentCustomer = customer;

            UpdateProfileCommand = new RelayCommand(_ => UpdateProfile());
            LogoutCommand = new RelayCommand(_ => Logout());
        }

        public Customer CurrentCustomer
        {
            get => _currentCustomer;
            set => SetProperty(ref _currentCustomer, value);
        }

        public ICommand UpdateProfileCommand { get; }
        public ICommand LogoutCommand { get; }

        private void UpdateProfile()
        {
            var dialog = new CustomerDialog(CurrentCustomer);
            if (dialog.ShowDialog() == true)
            {
                _customerService.UpdateCustomer(dialog.Customer);
                CurrentCustomer = dialog.Customer;
                MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Logout()
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            Application.Current.MainWindow?.Close();
        }
    }
}

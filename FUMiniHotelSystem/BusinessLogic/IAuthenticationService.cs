using FUMiniHotelSystem.Models;

namespace FUMiniHotelSystem.BusinessLogic
{
    public interface IAuthenticationService
    {
        bool AuthenticateAdmin(string email, string password);
        Customer AuthenticateCustomer(string email, string password);
    }
}

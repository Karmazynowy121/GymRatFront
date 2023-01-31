using GymRatApi.ModuleData.Dto;
using GymRatFront.Pages;

namespace GymRatFront.ClientService
{
    public class AuthenticationService : IAuthenticationService, IDisposable
    {
        public event EventHandler<LoggedUserDto> LogdChanged;
        public LoggedUserDto User { get; private set; }


        public void LogoutUser()
        {
            User = null;
            LogdChanged?.Invoke(this, User);
        }

        public void LogIn(LoggedUserDto user)
        {
            User = user;
            LogdChanged?.Invoke(this, User);
        }

        public void Dispose()
        {
            User = null;
        }
    }
}

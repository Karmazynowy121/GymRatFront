using GymRatApi.ModuleData.Dto;

namespace GymRatFront.ClientService
{
    public interface IAuthenticationService
    {
        event EventHandler<LoggedUserDto> LogdChanged;
        LoggedUserDto User { get; }
        void LogoutUser();
        void LogIn(LoggedUserDto user);
    }
}

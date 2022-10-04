using Core.Security.Dtos;
using Core.Security.Entities;

namespace Kodlama.io.Devs.Application.Services
{
    public interface IAuthenticationService
    {
        Task<User> RegisterAsync(UserForRegisterDto userForRegisterDto);
        Task<User> LoginAsync(UserForLoginDto userForLoginDto);
    }
}

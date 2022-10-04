using Core.Security.Dtos;

namespace Kodlama.io.Devs.Application.Features.Developers.Models
{
    public class DeveloperCreateModel : UserForRegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}

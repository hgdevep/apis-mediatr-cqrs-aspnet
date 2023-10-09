using MediatR;
using patients_web_apis.Application.Dtos.Response;

namespace patients_web_apis.Application.Commands
{
    public class CreatePatientCommand : IRequest<ResponseDto>
    {
        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string Email { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;
    }
}

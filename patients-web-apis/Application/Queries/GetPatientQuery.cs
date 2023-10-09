using MediatR;
using patients_web_apis.Application.Dtos.Response;

namespace patients_web_apis.Application.Queries
{
    public class GetPatientQuery : IRequest<ResponseDto>
    {
        public string Id { get; set; } = default!;
    }
}

using MediatR;
using patients_web_apis.Api.Controllers.Patients;
using patients_web_apis.Application.Dtos.Patient;
using patients_web_apis.Application.Dtos.Response;
using patients_web_apis.Application.Queries;
using patients_web_apis.Domain.Responses.Patient;
using patients_web_apis.Infrastructure.Repositories;

namespace patients_web_apis.Application.Handlers
{
    public class GetPatientHandlers : IRequestHandler<GetPatientQuery, ResponseDto>
    {
        private readonly ILogger<GetPatientHandlers> _logger;
        private readonly IPatientRepository _patientRepository;
        private readonly PatientDtoMapper _mapper;

        public GetPatientHandlers(ILogger<GetPatientHandlers> logger, IPatientRepository patientRepository, PatientDtoMapper mapper)
        {
            _logger = logger;
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto> Handle(GetPatientQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Init to get patient by id async");

            GetPatientResponse response = await _patientRepository.GetPatientByIdAsync(request.Id);

            _logger.LogInformation("Mapping patient entity to patient Dto");

            PatientDto? patientDto = _mapper.PatientEntityToPatientDto(response.Data);

            ResponseDto responseDto = new()
            {
                Data = patientDto,
                Metadata = new ResponseMetadataDto()
                {
                    Error = response.Failure != null ? new ResponseErrorDto()
                    {
                        Type = response.Failure.Type,
                        Message = response.Failure.Message
                    } : null
                }
            };

            _logger.LogInformation("Get patient by id async response sucessful");

            return responseDto;
        }
    }
}

using MediatR;
using patients_web_apis.Application.Dtos.Patient;
using patients_web_apis.Application.Dtos.Response;
using patients_web_apis.Application.Queries;
using patients_web_apis.Domain.Responses.Patient;
using patients_web_apis.Infrastructure.Repositories;

namespace patients_web_apis.Application.Handlers
{
    public class GetAllPatientsHandlers : IRequestHandler<GetAllPatientsQuery, ResponseDto>
    {
        private readonly ILogger<GetAllPatientsHandlers> _logger;
        private readonly IPatientRepository _patientRepository;
        private readonly PatientDtoMapper _mapper;

        public GetAllPatientsHandlers(ILogger<GetAllPatientsHandlers> logger, IPatientRepository patientRepository, PatientDtoMapper mapper)
        {
            _logger = logger;
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Init to get all patients async");

            GetPatientsResponse response = await _patientRepository.GetPatientsAsync();

            _logger.LogInformation("Mapping all patients entities to patients Dtos");

            PatientDto[]? patientsDtos = _mapper.PatientsEntitiesToPatientsDtos(response.Data);

            ResponseDto responseDto = new()
            {
                Data = patientsDtos,
                Metadata = new ResponseMetadataDto()
                {
                    Total = response.Total,
                    PageSize = response.PageSize,
                    Error = response.Failure != null ? new ResponseErrorDto()
                    {
                        Type = response.Failure.Type,
                        Message = response.Failure.Message
                    } : null
                }
            };

            _logger.LogInformation("Get all patients async response sucessful");

            return responseDto;
        }
    }
}

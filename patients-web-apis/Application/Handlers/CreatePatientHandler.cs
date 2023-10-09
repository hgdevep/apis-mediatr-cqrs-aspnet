using MediatR;
using patients_web_apis.Application.Commands;
using patients_web_apis.Application.Dtos.Patient;
using patients_web_apis.Application.Dtos.Response;
using patients_web_apis.Domain.Entities;
using patients_web_apis.Domain.Responses.Patient;
using patients_web_apis.Infrastructure.Repositories;

namespace patients_web_apis.Application.Handlers
{
    public class CreatePatientHandler : IRequestHandler<CreatePatientCommand, ResponseDto>
    {
        private readonly ILogger<CreatePatientHandler> _logger;
        private readonly IPatientRepository _patientRepository;
        private readonly PatientDtoMapper _mapper;

        public CreatePatientHandler(ILogger<CreatePatientHandler> logger, IPatientRepository patientRepository, PatientDtoMapper mapper)
        {
            _logger = logger;
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Init to create patient async");

            CreatePatientEntity createPatientEntity = new()
            {
                FirstName = request.FirstName, LastName = request.LastName, Email = request.Email, PhoneNumber = request.PhoneNumber
            };

            CreatePatientResponse response = await _patientRepository.CreatePatientAsync(createPatientEntity);

            _logger.LogInformation("Mapping patient entity create to patient Dto");

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

            _logger.LogInformation("Create patient async response sucessful");

            return responseDto;
        }
    }
}

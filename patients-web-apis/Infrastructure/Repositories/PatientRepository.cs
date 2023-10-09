using patients_web_apis.Domain.Entities;
using patients_web_apis.Domain.Failures;
using patients_web_apis.Domain.Models;
using patients_web_apis.Domain.Responses.Patient;
using patients_web_apis.Infrastructure.Mapping.Patient;

namespace patients_web_apis.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ILogger<PatientRepository> _logger;
        private readonly PatientMappers _mapper;

        public PatientRepository(ILogger<PatientRepository> logger, PatientMappers mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<GetPatientsResponse> GetPatientsAsync()
        {
            try
            {
                _logger.LogInformation("Get data of patients");

                PatientModel[] data =
                {
                new() { Id = Guid.Parse("eb493440-bbc2-41ee-b6f2-f0f76531619a"), Nombre = "Jenny", Apellido = "Rodriguez", Correo = "jenny.rodriguez@gmail.com", Telefono = "12345" },
                new() { Id = Guid.Parse("36765868-52ff-449b-a306-53af011269ff"), Nombre = "Jorge", Apellido = "Luis", Correo = "jorge.luis@gmail.com", Telefono = "123456" }
            };

                PatientEntity[] patients = Array.Empty<PatientEntity>();

                if (data.Length > 0)
                {
                    _logger.LogInformation("Mapping list data of patients to patients entity list");

                    for (int i = 0; i < data.Length; i++)
                    {
                        _logger.LogInformation("Starting mapping patient data to entity " + i);

                        PatientEntity patientEntity = _mapper.patientModelToPatientEntity(data[i]);

                        if (patientEntity != null)
                        {
                            patients = patients.Append(patientEntity).ToArray();
                        }
                    }
                }

                GetPatientsResponse getPatientsResponse = new()
                {
                    Data = patients,
                    Total = patients.Length,
                    PageSize = 10
                };

                await Task.Delay(1000);

                _logger.LogInformation("Get patients async sucessful with length of " + patients.Length);

                return getPatientsResponse;
            } catch (Exception ex)
            {
                _logger.LogInformation("A error has ocurred to get patients async with message: " + ex.Message);

                PatientFailure failure = new()
                {
                    Type = PatientFailuresTypes.ServerError,
                    Message = PatientFailuresMessages.ServerError
                };

                GetPatientsResponse getPatientsResponse = new()
                {
                    Failure = failure,
                };

                return getPatientsResponse;
            }
        }

        public async Task<GetPatientResponse> GetPatientByIdAsync(string id)
        {
            try
            {
                _logger.LogInformation("Get data of patient by id");

                PatientModel[] data =
                {
                new() { Id = Guid.Parse("eb493440-bbc2-41ee-b6f2-f0f76531619a"), Nombre = "Jenny", Apellido = "Rodriguez", Correo = "jenny.rodriguez@gmail.com", Telefono = "12345" },
                new() { Id = Guid.Parse("36765868-52ff-449b-a306-53af011269ff"), Nombre = "Jorge", Apellido = "Luis", Correo = "jorge.luis@gmail.com", Telefono = "123456" }
            };

                PatientEntity patient = new();

                if (data.Length > 0)
                {
                    for (int i = 0; i < data.Length; i++)
                    {
                        if (data[i].Id.ToString() == id)
                        {
                            _logger.LogInformation("Starting mapping patient data to entity");

                            PatientEntity patientEntity = _mapper.patientModelToPatientEntity(data[i]);

                            if (patientEntity != null)
                            {
                                patient = patientEntity;
                            }

                            break;
                        }
                    }
                }

                GetPatientResponse getPatientResponse = new()
                {
                    Data = patient,
                };

                await Task.Delay(1000);

                _logger.LogInformation("Get patients async sucessful with id ", getPatientResponse.Data.Id);

                return getPatientResponse;
            } catch (Exception ex)
            {
                _logger.LogInformation("A error has ocurred to get patient by id async with message: " + ex.Message);

                PatientFailure failure = new()
                {
                    Type = PatientFailuresTypes.ServerError,
                    Message = PatientFailuresMessages.ServerError
                };

                GetPatientResponse getPatientResponse = new()
                {
                    Failure = failure
                };

                return getPatientResponse;
            }
        }

        public async Task<CreatePatientResponse> CreatePatientAsync(CreatePatientEntity createPatientEntity)
        {
            try
            {
                _logger.LogInformation("Create patient in database");

                PatientModel[] data =
                {
                new() { Id = Guid.Parse("eb493440-bbc2-41ee-b6f2-f0f76531619a"), Nombre = "Jenny", Apellido = "Rodriguez", Correo = "jenny.rodriguez@gmail.com", Telefono = "12345" },
                new() { Id = Guid.Parse("36765868-52ff-449b-a306-53af011269ff"), Nombre = "Jorge", Apellido = "Luis", Correo = "jorge.luis@gmail.com", Telefono = "123456" }
            };

                _logger.LogInformation("Simulate create patient in database");

                data.Append(_mapper.createPatientEntityToPatientModel(createPatientEntity));

                PatientEntity patient = _mapper.createPatientEntityToPatientEntity(createPatientEntity);

                await Task.Delay(1000);

                CreatePatientResponse createPatientResponse = new()
                {
                    Data = patient,
                };

                _logger.LogInformation("Create patient async sucessful with id ", createPatientResponse.Data.Id);

                return createPatientResponse;
            } catch (Exception ex)
            {
                _logger.LogInformation("A error has ocurred to create patient async with message: " + ex.Message);

                PatientFailure failure = new()
                {
                    Type = PatientFailuresTypes.ServerError,
                    Message = PatientFailuresMessages.ServerError
                };

                CreatePatientResponse createPatientResponse = new()
                {
                    Failure = failure
                };

                return createPatientResponse;
            }
        }
    }
}

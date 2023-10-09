using patients_web_apis.Domain.Entities;
using patients_web_apis.Domain.Responses.Patient;

namespace patients_web_apis.Infrastructure.Repositories
{
    public interface IPatientRepository
    {
        Task<GetPatientsResponse> GetPatientsAsync();
        Task<GetPatientResponse> GetPatientByIdAsync(string id);

        Task<CreatePatientResponse> CreatePatientAsync(CreatePatientEntity createPatientEntity);
    }
}

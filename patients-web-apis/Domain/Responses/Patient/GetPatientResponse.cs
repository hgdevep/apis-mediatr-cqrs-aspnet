using patients_web_apis.Domain.Entities;
using patients_web_apis.Domain.Failures;

namespace patients_web_apis.Domain.Responses.Patient
{
    public class GetPatientResponse
    {
        public PatientEntity Data { get; set; } = default!;

        public PatientFailure? Failure { get; set; }
    }
}

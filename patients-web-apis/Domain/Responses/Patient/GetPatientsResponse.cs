using patients_web_apis.Domain.Entities;
using patients_web_apis.Domain.Failures;

namespace patients_web_apis.Domain.Responses.Patient
{
    public class GetPatientsResponse
    {
        public IList<PatientEntity> Data { get; set; } = default!;

        public int Total { get; set; } = 0;

        public int PageSize { get; set; } = 0;

        public PatientFailure? Failure { get; set; }

    }
}

using patients_web_apis.Domain.Entities;

namespace patients_web_apis.Application.Dtos.Patient
{
    public class PatientDtoMapper
    {
        public PatientDto? PatientEntityToPatientDto(PatientEntity patientEntity)
        {
            PatientDto? patientDto = null;

            if (patientEntity != null)
            {
                patientDto = new()
                {
                    Id = patientEntity.Id,
                    FirstName = patientEntity.FirstName,
                    LastName = patientEntity.LastName,
                    FullName = patientEntity.FirstName + " " + patientEntity.LastName,
                    Email = patientEntity.Email,
                    PhoneNumber = patientEntity.PhoneNumber
                };
            }

            return patientDto;
        }

        public PatientDto[] PatientsEntitiesToPatientsDtos(IList<PatientEntity> patientsEntities)
        {
            PatientDto[] patients = Array.Empty<PatientDto>();

            if (patientsEntities != null && patientsEntities.Count > 0)
            {
                for (int i = 0; i < patientsEntities.Count; i++)
                {
                    PatientDto? patientDto = this.PatientEntityToPatientDto(patientsEntities[i]);

                    if (patientDto != null)
                    {
                        patients = patients.Append(patientDto).ToArray();
                    }
                }
            }
           
            return patients;
        }
    }
}

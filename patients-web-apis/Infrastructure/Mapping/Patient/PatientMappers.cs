using patients_web_apis.Domain.Entities;
using patients_web_apis.Domain.Models;

namespace patients_web_apis.Infrastructure.Mapping.Patient
{
    public class PatientMappers
    {
        public PatientEntity patientModelToPatientEntity(PatientModel data)
        {
            PatientEntity patientEntity = new()
            {
                Id = data.Id,
                FirstName = data.Nombre ?? "",
                LastName = data.Apellido ?? "",
                Email = data.Correo ?? "",
                PhoneNumber = data.Telefono ?? "",
            };

            return patientEntity;
        }

        public PatientModel createPatientEntityToPatientModel(CreatePatientEntity createPatientEntity)
        {
            PatientModel patientModel = new()
            {
                Id = createPatientEntity.Id,
                Nombre = createPatientEntity.FirstName,
                Apellido = createPatientEntity.LastName,
                Correo = createPatientEntity.Email,
                Telefono = createPatientEntity.PhoneNumber,
            };

            return patientModel;
        }

        public PatientEntity createPatientEntityToPatientEntity(CreatePatientEntity createPatientEntity)
        {
            PatientEntity patientEntity = new()
            {
                Id = createPatientEntity.Id,
                FirstName = createPatientEntity.FirstName ?? "",
                LastName = createPatientEntity.LastName ?? "",
                Email = createPatientEntity.Email ?? "",
                PhoneNumber = createPatientEntity.PhoneNumber ?? "",
            };

            return patientEntity;
        }
    }
}

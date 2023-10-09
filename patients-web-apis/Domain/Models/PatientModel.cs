namespace patients_web_apis.Domain.Models
{
    public class PatientModel
    {
        public Guid Id { get; set; } = default!;

        public string Nombre { get; set; } = default!;

        public string Apellido { get; set; } = default!;

        public string Correo { get; set; } = default!;

        public string Telefono { get; set; } = default!;
    }
}

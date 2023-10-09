namespace patients_web_apis.Domain.Failures
{
    public class PatientFailure : Failure
    {
        
    }

    public static class PatientFailuresTypes
    {
        public const string ServerError = "SERVER_ERROR";
    }

    public static class PatientFailuresMessages
    {
        public const string ServerError = "A server error has occurred";
    }
}

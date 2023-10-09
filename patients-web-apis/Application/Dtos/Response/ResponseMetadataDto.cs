namespace patients_web_apis.Application.Dtos.Response
{
    public class ResponseMetadataDto
    {
        public int? Total { get; set; }
        public int? PageSize { get; set; }

        public ResponseErrorDto? Error { get; set; }
    }
}

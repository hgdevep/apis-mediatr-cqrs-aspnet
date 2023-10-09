namespace patients_web_apis.Application.Dtos.Response
{
    public class ResponseDto
    {
        public dynamic? Data { get; set; } = default!;
        public ResponseMetadataDto Metadata { get; set; } = default!;
    }
}

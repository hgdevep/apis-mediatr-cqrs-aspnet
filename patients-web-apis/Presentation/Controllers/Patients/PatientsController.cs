using MediatR;
using Microsoft.AspNetCore.Mvc;
using patients_web_apis.Application.Commands;
using patients_web_apis.Application.Dtos.Response;
using patients_web_apis.Application.Queries;
using patients_web_apis.Domain.Failures;

namespace patients_web_apis.Api.Controllers.Patients
{
    [ApiController]
    public class PatientsController : ControllerBase
    {
        
        private readonly IMediator _mediator;

        public PatientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("api/patients")]
        [HttpGet]
        public async Task<ActionResult<ResponseDto>> GetPatients()
        {
            var query = new GetAllPatientsQuery();
            var result = await _mediator.Send(query);

            if (result.Metadata.Error != null)
            {
                switch (result.Metadata.Error.Type)
                {
                    case PatientFailuresTypes.ServerError:
                        return StatusCode(StatusCodes.Status500InternalServerError, result);
                }
            }

            return result;
        }

        [Route("api/patients/{patientId}")]
        [HttpGet]
        public async Task<ActionResult<ResponseDto>> GetPatientById(string patientId)
        {
            var query = new GetPatientQuery{ 
                Id=patientId
            };
            var result = await _mediator.Send(query);

            if (result.Metadata.Error != null)
            {
                switch (result.Metadata.Error.Type)
                {
                    case PatientFailuresTypes.ServerError:
                        return StatusCode(StatusCodes.Status500InternalServerError, result);
                }
            }

            return result;
        }

        [Route("api/patients/create")]
        [HttpPost]
        public async Task<ActionResult<ResponseDto>> CreatePatient([FromBody] CreatePatientCommand request)
        {
            var result = await _mediator.Send(request);

            if (result.Metadata.Error != null)
            {
                switch (result.Metadata.Error.Type) 
                {
                    case PatientFailuresTypes.ServerError:
                        return StatusCode(StatusCodes.Status500InternalServerError, result);
                }
            }

            return StatusCode(StatusCodes.Status201Created, result); ;
        }
    }
}
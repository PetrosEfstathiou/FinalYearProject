using FinalYearProject.Dtos.patient.Treatment;
using FinalYearProject.Dtos.patient.Xray;
using FinalYearProject.Models;
using FinalYearProject.Services.patientService;
using FinalYearProject.Services.patientService.TreatmentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalYearProject.Controllers
{
   // [Authorize]
    [ApiController]
    [Route("TreatmentController")]
    public class TreatmentController :ControllerBase
    {
        private readonly ITreatmentService _TreatmentService;

        public TreatmentController(TreatmentService TreatmentService)
        {
            _TreatmentService = TreatmentService;

        }

        [HttpGet]
        [Route("GetbyID")]
        public async Task<ActionResult<ServiceResponse<List<TreatmentDto>>>> GetbyID(int id)
        {
            return Ok(await _TreatmentService.GetTreatment(id));
        }
        
         [HttpPost]
        [Route("AddTreatment")]
        public async Task<ActionResult<ServiceResponse<int>>> AddTreatment(TreatmentDto newTreatment)
        {
                    return Ok(await _TreatmentService.AddTreatment(newTreatment));
        }

        [HttpPut]
        [Route("EditTreatment")]
        public async Task<ActionResult<ServiceResponse<TreatmentDto>>> EditTreatment(TreatmentDto updatedTreatment)
        {
            var response = await _TreatmentService.EditTreatment(updatedTreatment);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            response.Message = "Treatment changes saved!!!";
            return Ok(response);
        }

        
    }
}
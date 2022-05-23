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

        public TreatmentController(ITreatmentService TreatmentService)
        {
            _TreatmentService = TreatmentService;

        }

        [HttpGet]
        [Route("GetbyID")]
        public async Task<ActionResult<ServiceResponse<TreatmentDto>>> GetbyID(int id)
        {
            return Ok(await _TreatmentService.GetTreatment(id));
        }
        [HttpGet]
        [Route("GetbyAppID")]
        public async Task<ActionResult<ServiceResponse<TreatmentDto>>> GetbyAppID(int id)
        {
            return Ok(await _TreatmentService.GetTreatmentbyAppID(id));
        }

         [HttpPost]
        [Route("AddTreatment")]
        public async Task<ActionResult<ServiceResponse<int>>> AddTreatment(AddTreatmentDto newTreatment)
        {
                    return Ok(await _TreatmentService.AddTreatment(newTreatment));
        }

        [HttpPut]
        [Route("EditTreatment")]
        public async Task<ActionResult<ServiceResponse<int>>> EditTreatment(TreatmentDto updatedTreatment)
        {
            var response = await _TreatmentService.EditTreatment(updatedTreatment);
            if (response.Data == 0)
            {
                return NotFound(response);
            }
            response.Message = "Treatment changes saved!!!";
            return Ok(response);
        }

        
    }
}
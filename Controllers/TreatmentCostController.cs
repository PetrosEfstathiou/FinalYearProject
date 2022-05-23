
using FinalYearProject.Dtos.patient.Treatment;
using FinalYearProject.Dtos.patient.TreatmentCost;
using FinalYearProject.Dtos.patient.Xray;
using FinalYearProject.Models;
using FinalYearProject.Services.patientService;
using FinalYearProject.Services.patientService.TreatmentCostService;
using FinalYearProject.Services.patientService.TreatmentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace FinalYearProject.Controllers
{
   // [Authorize]
    [ApiController]
    [Route("TreatmentCostController")]
    public class TreatmentCostController :ControllerBase
    {
        private readonly ITreatmentCostService _TreatmentCostService;

        public TreatmentCostController(ITreatmentCostService TreatmentCostService)
        {
            _TreatmentCostService = TreatmentCostService;

        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<TreatmentCostDto>>>> GetAllTC()
        {
                return Ok(await _TreatmentCostService.GetAll());
        }
        
         [HttpPost]
        [Route("AddTreatmentCost")]
        public async Task<ActionResult<ServiceResponse<TreatmentCostDto>>> AddTC(TreatmentCost newTC)
        {
                    return Ok(await _TreatmentCostService.AddTC(newTC));
        }

        [HttpDelete]
        [Route("DeletebyId")]
        public async Task<ActionResult<ServiceResponse<List<TreatmentCostDto>>>> DeleteTC(int id)
        {
             var response = await _TreatmentCostService.DeleteTC(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            response.Message = "Treatment Controller!!!";
            return Ok(response);
        }
        
    }
}
using FinalYearProject.Dtos.patient.Xray;
using FinalYearProject.Models;
using FinalYearProject.Services.patientService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalYearProject.Controllers
{
   // [Authorize]
    [ApiController]
    [Route("XrayController")]
    public class XrayController : ControllerBase
    {
        private readonly IXrayService _XrayService;

        public XrayController(IXrayService XrayService)
        {
            _XrayService = XrayService;

        }
        
        [HttpGet]
        [Route("GetbyID")]
        public async Task<ActionResult<ServiceResponse<List<XrayDto>>>> GetbyID(int id)
        {
            return Ok(await _XrayService.GetXray(id));
        }

        [HttpPost]
        [Route("AddXray")]
        public async Task<ActionResult<ServiceResponse<int>>> AddXray(AddXrayDto newXray)
        {
                    return Ok(await _XrayService.AddXray(newXray));
        }

        [HttpDelete]
        [Route("DeletebyId")]
        public async Task<ActionResult<ServiceResponse<int>>> Delete(int id)
        {
             var response = await _XrayService.DeleteXray(id);
            if (response.Data == 0)
            {
                return NotFound(response);
            }
            response.Message = "Xray deleted!!!";
            return Ok(response);
        }

    }
}
using FinalYearProject.Services.patientService;
using FinalYearProject.Models;
using Microsoft.AspNetCore.Mvc;
using FinalYearProject.Dtos.patient;
using Microsoft.AspNetCore.Authorization;

namespace FinalYearProject.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("PatientController")]
    public class patientcontroller : ControllerBase
    {
        private readonly IpatientService _patientService;

        public patientcontroller(IpatientService patientService)
        {
            _patientService = patientService;

        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetPatientDto>>>> Get()
        {
            return Ok(await _patientService.GetAllpatients());
        }

        [HttpGet]
        [Route("GetSingle")]
        public async Task<ActionResult<ServiceResponse<List<GetPatientDto>>>> GetSingle(int id)
        {
            var response =await _patientService.GetpatientById(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            response.Message = "Patient Found";
            return Ok (response);
        }

        [HttpGet]
        [Route("GetSinglebyTel")]
        public async Task<ActionResult<ServiceResponse<List<GetPatientDto>>>> GetbyTel(int tel)
        {
            var response =await _patientService.GetpatientById(tel);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            response.Message = "Patients Found";
            return Ok (response);
        }

        [HttpPost]
        [Route("Newpatient")]
        public async Task<ActionResult<ServiceResponse<List<GetPatientDto>>>> Addpatient(AddPatientDto newPatient)
        {
            return Ok(await _patientService.AddPatient(newPatient));
        }

        [HttpPut]
        [Route("UpdatePatient")]
        public async Task<ActionResult<ServiceResponse<GetPatientDto>>> UpdatePatient(UpdatePatientDto updatedPatient)
        {
            var response = await _patientService.UpdatePatient(updatedPatient);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            response.Message = "Patient changes saved!!!";
            return Ok(response);
        }

         [HttpDelete]
        [Route("DeletebyID")]
        public async Task<ActionResult<ServiceResponse<List<GetPatientDto>>>> Delete(int id)
        {
             var response = await _patientService.DeletePatient(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            response.Message = "Patient deleted!!!";
            return Ok(response);
        }
    }
}
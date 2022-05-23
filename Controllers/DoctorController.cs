using FinalYearProject.Services.patientService.DoctorService;
using FinalYearProject.Models;
using Microsoft.AspNetCore.Mvc;
using FinalYearProject.Dtos.patient;
using Microsoft.AspNetCore.Authorization;
using FinalYearProject.Dtos.patient.Doctor;

namespace FinalYearProject.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("DoctorController")]
    
    public class DoctorController:ControllerBase
    {private readonly IDoctorService _DoctorService;

        public DoctorController(IDoctorService DoctorService)
        {
            _DoctorService = DoctorService;

        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<DoctorDto>>>> GetAll()
        {
            return Ok(await _DoctorService.GetAllDoctors());
        }

        [HttpGet]
        [Route("GetSingle")]
        public async Task<ActionResult<ServiceResponse<List<DoctorDto>>>> GetSingle(int id)
        {
            var response =await _DoctorService.GetDoctorById(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            response.Message = "Doctor Found";
            return Ok (response);
        }

        [HttpPost]
        [Route("AddDoctor")]
        public async Task<ActionResult<ServiceResponse<List<DoctorDto>>>> AddDoctor(AddDoctorDto newDoctor)
        {
            return Ok(await _DoctorService.AddDoctor(newDoctor));
        }

        [HttpPut]
        [Route("UpdateDoctor")]
        public async Task<ActionResult<ServiceResponse<DoctorDto>>> UpdateDoctor(DoctorDto updatedDoctor)
        {
            var response = await _DoctorService.UpdateDoctor(updatedDoctor);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            response.Message = "Doctor changes saved!!!";
            return Ok(response);
        }

    
    }
}
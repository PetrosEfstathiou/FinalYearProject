using FinalYearProject.Models;
using Microsoft.AspNetCore.Mvc;
using FinalYearProject.Services.patientService.AppointmentService;
using FinalYearProject.Dtos.patient.Appointment;
using Microsoft.AspNetCore.Authorization;

namespace FinalYearProject.Controllers
{
   // [Authorize]
    [ApiController]
    [Route("AppointmentController")]
    public class AppController : ControllerBase
    {
        private readonly IAppService _AppService;

        public AppController(IAppService AppService)
        {
            _AppService = AppService;

        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetAppointmentDto>>>> GetAll()
        {
            return Ok(await _AppService.GetAllAppointments());
        }

        [HttpGet]
        [Route("GetbyID")]
        public async Task<ActionResult<ServiceResponse<List<GetAppointmentDto>>>> GetbyID(int id)
        {
            return Ok(await _AppService.GetAppointmentsbyID(id));
        }

        [HttpPost]
        [Route("AddAppointment")]
        public async Task<ActionResult<ServiceResponse<List<GetAppointmentDto>>>> AddApp(AddAppointmentDto newAppointment)
        {
                    return Ok(await _AppService.AddAppointment(newAppointment));
        }

        [HttpPut]
        [Route("UpdateAppointment")]
        public async Task<ActionResult<ServiceResponse<GetAppointmentDto>>> UpdateApp(UpdateAppointmentDto updatedAppointment)
        {
            var response = await _AppService.UpdateAppointment(updatedAppointment);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            response.Message = "Appointment changes saved!!!";
            return Ok(response);
        }

        [HttpPut]
        [Route("CancelAppointment")]
        public async Task<ActionResult<ServiceResponse<List<GetAppointmentDto>>>> CancelApp(UpdateAppointmentDto cancelledAppointment)
        {
             var response = await _AppService.CancelAppointment(cancelledAppointment);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            response.Message = "Appointment Cancelled!";
            return Ok(response);
        }
    }
}

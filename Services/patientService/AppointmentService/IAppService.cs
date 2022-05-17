using FinalYearProject.Dtos.patient.Appointment;
using FinalYearProject.Models;

namespace FinalYearProject.Services.patientService.AppointmentService
{
    public interface IAppService
    {
        Task<ServiceResponse<List<GetAppointmentDto>>> GetAllAppointments();
        Task<ServiceResponse<List<GetAppointmentDto>>> GetAppointmentsbyID(int id);
        Task<ServiceResponse<GetAppointmentDto>> CancelAppointment (UpdateAppointmentDto updatedAppointment);
        Task<ServiceResponse<List<GetAppointmentDto>>> AddAppointment(AddAppointmentDto newAppointment);
        Task<ServiceResponse<GetAppointmentDto>> UpdateAppointment(UpdateAppointmentDto updatedAppointment);

    }
}
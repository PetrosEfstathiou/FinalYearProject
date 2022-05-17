using System.Collections.Generic;
using System.Linq;
using FinalYearProject.Models;
using System.Threading.Tasks;
using FinalYearProject.Dtos.patient;
using AutoMapper;
using FinalYearProject.Data;
using Microsoft.EntityFrameworkCore;
using FinalYearProject.Services.patientService.AppointmentService;
using FinalYearProject.Dtos.patient.Appointment;

namespace FinalYearProject.Services.patientService
{
    public class AppService : IAppService

    {

        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public AppService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<ServiceResponse<List<GetAppointmentDto>>> AddAppointment(AddAppointmentDto newAppointment)
        {
            var ServiceResponse = new ServiceResponse<List<GetAppointmentDto>>();
            Appointment appointment = (_mapper.Map<Appointment>(newAppointment));
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            ServiceResponse.Data = await _context.Appointments.Select(a => _mapper.Map<GetAppointmentDto>(a)).ToListAsync();
            return ServiceResponse;
        }


        public async Task<ServiceResponse<GetAppointmentDto>> CancelAppointment(UpdateAppointmentDto updatedAppointment)
        {
             var ServiceResponse = new ServiceResponse<GetAppointmentDto>();
            try
            {
                Appointment appointment = await _context.Appointments.FirstOrDefaultAsync(a=>a.id == updatedAppointment.id);
                appointment.cancelled = true;
                appointment.CancelReason = updatedAppointment.CancelReason;
                await _context.SaveChangesAsync();
                ServiceResponse.Data = _mapper.Map<GetAppointmentDto>(appointment);
            }
            catch (Exception Ex)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = "Appointment does not exist";
              
                }
            return ServiceResponse;
        }


        public async Task<ServiceResponse<List<GetAppointmentDto>>> GetAllAppointments()
        {
            var ServiceResponse = new ServiceResponse<List<GetAppointmentDto>>();
            var dbAppointments = await _context.Appointments.ToListAsync();
            ServiceResponse.Data = dbAppointments.Select(a => _mapper.Map<GetAppointmentDto>(a)).ToList();
            return ServiceResponse;
        }


        public async Task<ServiceResponse<List<GetAppointmentDto>>> GetAppointmentsbyID(int id)
        {
            var ServiceResponse = new ServiceResponse<List<GetAppointmentDto>>();
            var dbAppointments = await _context.Appointments.Where(a => a.patient ==id).ToListAsync();
            ServiceResponse.Data = dbAppointments.Select(a=> _mapper.Map<GetAppointmentDto>(a)).ToList();
            return ServiceResponse;
        }


        public async Task<ServiceResponse<GetAppointmentDto>> UpdateAppointment(UpdateAppointmentDto updatedAppointment)
        {
             var ServiceResponse = new ServiceResponse<GetAppointmentDto>();
            try
            {
                Appointment appointment = await _context.Appointments.FirstOrDefaultAsync(a => a.patient == updatedAppointment.id);
                appointment.AppReason = updatedAppointment.AppReason;
                appointment.cancelled = updatedAppointment.cancelled;
                appointment.CancelReason = updatedAppointment.CancelReason;
                appointment.dateTime = updatedAppointment.dateTime;
                appointment.mduration = updatedAppointment.mduration;

                await _context.SaveChangesAsync();
                ServiceResponse.Data = _mapper.Map<GetAppointmentDto>(appointment);
            }
            catch (Exception Ex)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = "Appointment does not exist";
              
                }
            return ServiceResponse;
        }

        
    }
}

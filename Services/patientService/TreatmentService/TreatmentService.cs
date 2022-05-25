using AutoMapper;
using FinalYearProject.Data;
using FinalYearProject.Dtos.patient.Treatment;
using FinalYearProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalYearProject.Services.patientService.TreatmentService
{
    public class TreatmentService : ITreatmentService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public TreatmentService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<ServiceResponse<int>> AddTreatment(AddTreatmentDto newTreatment)
        {
            var ServiceResponse = new ServiceResponse<int>();
            Treatment treat = (_mapper.Map<Treatment>(newTreatment));
            _context.Treatments.Add(treat);
            await _context.SaveChangesAsync();
            ServiceResponse.Data = 1;
            return ServiceResponse;
        }

        public async Task<ServiceResponse<int>> EditTreatment(TreatmentDto updatedTreatment)
        {
          var ServiceResponse = new ServiceResponse<int>();
            try
            {
                Treatment treatment = await _context.Treatments.FirstOrDefaultAsync(t => t.id == updatedTreatment.id);
                treatment.appointment = updatedTreatment.appointment;
                treatment.cost = updatedTreatment.cost;
                treatment.patient = updatedTreatment.patient;
                treatment.timage = updatedTreatment.timage;
                treatment.treatment = updatedTreatment.treatment;
                await _context.SaveChangesAsync();
                ServiceResponse.Data = 1;
            }
            catch (Exception Ex)
            {
                ServiceResponse.Data = 0;
                ServiceResponse.Success = false;
                ServiceResponse.Message = "Treatment does not exist";
            }
            return ServiceResponse;
        }

        public async Task<ServiceResponse<TreatmentDto>> GetTreatment(int tid)
        {
          var ServiceResponse = new ServiceResponse<TreatmentDto>();
            var dbtreat = await _context.Treatments.FirstOrDefaultAsync(t => t.id == tid);
            ServiceResponse.Data = _mapper.Map<TreatmentDto>(dbtreat);
            if (ServiceResponse.Data == null)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = "Treatment not found";
            }
            return ServiceResponse;
        }

        public async Task<ServiceResponse<TreatmentDto>> GetTreatmentbyAppID(int id)
        {   
           var ServiceResponse = new ServiceResponse<TreatmentDto>();
            var dbtreat = await _context.Treatments.FirstOrDefaultAsync(t => t.appointment == id);
            ServiceResponse.Data = _mapper.Map<TreatmentDto>(dbtreat);
            if (ServiceResponse.Data == null)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = "Treatment not found for that Appointment";
            }
            return ServiceResponse;
          
        }

        public async Task<ServiceResponse<List<TreatmentDto>>> GetTreatmentbyPatientID(int pid)
        {
               var ServiceResponse = new ServiceResponse<List<TreatmentDto>>();
            var dbTreatments = await _context.Treatments.Where(t => t.patient == pid).ToListAsync();
            ServiceResponse.Data = dbTreatments.Select(t=> _mapper.Map<TreatmentDto>(t)).ToList();
            if (ServiceResponse.Data.Count == 0)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = "Treatments not found for that patient";
                return ServiceResponse; 
            }
            return ServiceResponse;
        }
    }
}
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

        public async Task<ServiceResponse<int>> AddTreatment(TreatmentDto newTreatment)
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
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<TreatmentDto>>> GetTreatment(int pid)
        {
          var ServiceResponse = new ServiceResponse<List<TreatmentDto>>();
          var dbtreatments = await _context.Treatments.Where(t => t.patient == pid).ToListAsync();
          ServiceResponse.Data = dbtreatments.Select(t=> _mapper.Map<TreatmentDto>(t)).ToList();
          return ServiceResponse;
        }
    }

}
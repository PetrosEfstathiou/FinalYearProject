using AutoMapper;
using FinalYearProject.Data;
using FinalYearProject.Dtos.patient.TreatmentCost;
using FinalYearProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalYearProject.Services.patientService.TreatmentCostService
{
    public class TreatmentCostService : ITreatmentCostService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public TreatmentCostService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<ServiceResponse<List<TreatmentCostDto>>> AddTC(TreatmentCost newTCost)
        {
            var ServiceResponse = new ServiceResponse<List<TreatmentCostDto>>();
            TreatmentCost treatmentCost = (_mapper.Map<TreatmentCost>(newTCost));
            _context.TreatmentCosts.Add(newTCost);
            await _context.SaveChangesAsync();
            ServiceResponse.Data = await _context.TreatmentCosts.Select(t => _mapper.Map<TreatmentCostDto>(t)).ToListAsync();
            ServiceResponse.Message = "Treatment Costs succesfully added";
            return ServiceResponse;
        }

        public async Task<ServiceResponse<List<TreatmentCostDto>>> DeleteTC(int id)
        {
            var ServiceResponse = new ServiceResponse<List<TreatmentCostDto>>();
            try
            {
                TreatmentCost treatmentCost = await _context.TreatmentCosts.FirstAsync(t => t.Id == id);
                _context.TreatmentCosts.Remove(treatmentCost);
                await _context.SaveChangesAsync();
                ServiceResponse.Data = _context.TreatmentCosts.Select(t => _mapper.Map<TreatmentCostDto>(t)).ToList(); ;
            }
            catch (Exception Ex)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = "Treatment Costs does not exist";
                //    ServiceResponse.Message = Ex.Message;
            }
            return ServiceResponse;
        }

        public async Task<ServiceResponse<List<TreatmentCostDto>>> GetAll()
        {
            var ServiceResponse = new ServiceResponse<List<TreatmentCostDto>>();
            var dbTreatmentCosts = await _context.TreatmentCosts.ToListAsync();
            ServiceResponse.Data = dbTreatmentCosts.Select(t => _mapper.Map<TreatmentCostDto>(t)).ToList();
            return ServiceResponse;
        }
    }
}
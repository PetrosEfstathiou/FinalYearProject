using FinalYearProject.Dtos.patient.TreatmentCost;
using FinalYearProject.Models;

namespace FinalYearProject.Services.patientService.TreatmentCostService

{
    public interface ITreatmentCostService
    
    {
        Task<ServiceResponse<List<TreatmentCostDto>>> GetAll();
         Task<ServiceResponse<List<TreatmentCostDto>>> AddTC(TreatmentCost newTCost);
         Task<ServiceResponse<List<TreatmentCostDto>>> DeleteTC(int id);
    }
}
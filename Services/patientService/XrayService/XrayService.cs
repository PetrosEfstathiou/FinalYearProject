using AutoMapper;
using FinalYearProject.Data;

using FinalYearProject.Dtos.patient.Xray;
using FinalYearProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalYearProject.Services.patientService.XrayService
{
    public class XrayService : IXrayService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public XrayService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<ServiceResponse<int>> AddXray(AddXrayDto newXray)
        {
            var ServiceResponse = new ServiceResponse<int>();
            Xray xray = (_mapper.Map<Xray>(newXray));
            _context.Xrays.Add(xray);
            await _context.SaveChangesAsync();
            ServiceResponse.Data = 1;
            return ServiceResponse;
        }

        public async Task<ServiceResponse<int>> DeleteXray(int id)
        {
             var ServiceResponse = new ServiceResponse<int>();
            try
            {
                Xray xray = await _context.Xrays.FirstAsync(x => x.id == id);
                _context.Xrays.Remove(xray);
                await _context.SaveChangesAsync();
                ServiceResponse.Data = 1;
            }
            catch (Exception Ex)
            {
                ServiceResponse.Data = 0;
                ServiceResponse.Success = false;
                ServiceResponse.Message = "Xray does not exist";
                //    ServiceResponse.Message = Ex.Message;
            }
            return ServiceResponse;
        }

        public async Task<ServiceResponse<List<XrayDto>>> GetXray(int patientid)
        {
            var ServiceResponse = new ServiceResponse<List<XrayDto>>();
            var dbXrays = await _context.Xrays.Where(x => x.patient == patientid).ToListAsync();
            ServiceResponse.Data = dbXrays.Select(x=> _mapper.Map<XrayDto>(x)).ToList();
            return ServiceResponse;
        }
    }
}
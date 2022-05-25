using System.Collections.Generic;
using System.Linq;
using FinalYearProject.Models;
using System.Threading.Tasks;
using FinalYearProject.Dtos.patient;
using AutoMapper;
using FinalYearProject.Data;
using Microsoft.EntityFrameworkCore;

namespace FinalYearProject.Services.patientService
{
    public class patientService : IpatientService
    {

        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public patientService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<ServiceResponse<List<GetPatientDto>>> AddPatient(AddPatientDto newPatient)
        {
            var ServiceResponse = new ServiceResponse<List<GetPatientDto>>();
            patient patient = (_mapper.Map<patient>(newPatient));
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            ServiceResponse.Data = await _context.Patients.Select(p => _mapper.Map<GetPatientDto>(p)).ToListAsync();
            ServiceResponse.Message = "Patient succesfully added";
            return ServiceResponse;
        }

        public async Task<ServiceResponse<List<GetPatientDto>>> DeletePatient(int id)
        {
            var ServiceResponse = new ServiceResponse<List<GetPatientDto>>();
            try
            {
                patient patient = await _context.Patients.FirstAsync(p => p.Id == id);
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
                ServiceResponse.Data = _context.Patients.Select(p => _mapper.Map<GetPatientDto>(p)).ToList(); ;
            }
            catch (Exception Ex)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = "Patient does not exist";
            }
            return ServiceResponse;
        }

        public async Task<ServiceResponse<List<GetPatientDto>>> GetAllpatients()
        {
            var ServiceResponse = new ServiceResponse<List<GetPatientDto>>();
            var dbPatients = await _context.Patients.ToListAsync();
            ServiceResponse.Data = dbPatients.Select(p => _mapper.Map<GetPatientDto>(p)).ToList();
            if (ServiceResponse.Data == null)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = "Patients not found in database";
            }
            return ServiceResponse;
        }

        public async Task<ServiceResponse<GetPatientDto>> GetpatientById(int id)
        {
            var ServiceResponse = new ServiceResponse<GetPatientDto>();
            var dbPatient = await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
            ServiceResponse.Data = _mapper.Map<GetPatientDto>(dbPatient);
            if (ServiceResponse.Data == null)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = "Patient not found";
            }
            return ServiceResponse;
        }

        public async Task<ServiceResponse<List<GetPatientDto>>> GetpatientByTel(int tel)
        {
             var ServiceResponse = new ServiceResponse<List<GetPatientDto>>();
            var dbPatients = await _context.Patients.Where(p => p.telnum ==tel.ToString()).ToListAsync();
            ServiceResponse.Data = dbPatients.Select(p=> _mapper.Map<GetPatientDto>(p)).ToList();
            if (ServiceResponse.Data == null)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = "Patients not found";
            }
            return ServiceResponse;
        }

        public async Task<ServiceResponse<GetPatientDto>> UpdatePatient(UpdatePatientDto updatedPatient)
        {

            var ServiceResponse = new ServiceResponse<GetPatientDto>();
            try
            {
                patient patient = await _context.Patients.FirstOrDefaultAsync(p => p.Id == updatedPatient.Id);
                patient.Name = updatedPatient.Name;
                patient.Surname = updatedPatient.Surname;
                patient.email = updatedPatient.email;
                patient.telnum = updatedPatient.telnum;
                patient.nation = updatedPatient.nation;
                patient.dob = updatedPatient.dob;
                patient.bloodtype = updatedPatient.bloodtype;
                patient.address = updatedPatient.address;

                await _context.SaveChangesAsync();
                ServiceResponse.Data = _mapper.Map<GetPatientDto>(patient);
            }
            catch (Exception Ex)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = "Patient does not exist";
            }
            return ServiceResponse;

        }
    }
}
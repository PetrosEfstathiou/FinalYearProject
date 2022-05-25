using AutoMapper;
using FinalYearProject.Data;
using FinalYearProject.Dtos.patient.Doctor;
using FinalYearProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalYearProject.Services.patientService.DoctorService
{
    public class DoctorService : IDoctorService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public DoctorService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;

        }


        public async Task<ServiceResponse<List<DoctorDto>>> AddDoctor(AddDoctorDto newDoctor)
        {
            var ServiceResponse = new ServiceResponse<List<DoctorDto>>();
            Doctor doctor = (_mapper.Map<Doctor>(newDoctor));
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            ServiceResponse.Data = await _context.Doctors.Select(p => _mapper.Map<DoctorDto>(p)).ToListAsync();
            ServiceResponse.Message = "Doctor Added Successfully";
            return ServiceResponse;
        }

        public async Task<ServiceResponse<List<DoctorDto>>> GetAllDoctors()
        {
            var ServiceResponse = new ServiceResponse<List<DoctorDto>>();
            var dbDoctors = await _context.Doctors.ToListAsync();
            ServiceResponse.Data = dbDoctors.Select(p => _mapper.Map<DoctorDto>(p)).ToList();
            if (ServiceResponse.Data == null)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = "Doctors not found in database";
            }
            return ServiceResponse;
        }

        public async Task<ServiceResponse<DoctorDto>> GetDoctorById(int id)
        {
                    var ServiceResponse = new ServiceResponse<DoctorDto>();
            var dbDoctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == id);
            ServiceResponse.Data = _mapper.Map<DoctorDto>(dbDoctor);
            if (ServiceResponse.Data == null)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = "Doctor not found";
            }
            return ServiceResponse;
        }

        public async Task<ServiceResponse<DoctorDto>> UpdateDoctor(DoctorDto updatedDoctor)
        {
            var ServiceResponse = new ServiceResponse<DoctorDto>();
            try
            {
                Doctor doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == updatedDoctor.id);
                doctor.Name = updatedDoctor.Name;
                doctor.Surname = updatedDoctor.Surname;
                doctor.email = updatedDoctor.email;
                doctor.telnum = updatedDoctor.telnum;
                doctor.specialty = updatedDoctor.specialty;
                doctor.address = updatedDoctor.address;

                await _context.SaveChangesAsync();
                ServiceResponse.Data = _mapper.Map<DoctorDto>(doctor);
            }
            catch (Exception Ex)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = "Doctor does not exist";
            }
            return ServiceResponse;
        }
    }
}
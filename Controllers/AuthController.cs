using FinalYearProject.Data;
using FinalYearProject.Dtos.patient.User;
using FinalYearProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalYearProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;

        }
        [HttpPost]
        [Route("RegisterUser")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
        {
            var response = await _authRepo.Register(
            new User{Username=request.Username}, request.Password , request.macadd

            );
            if(!response.Success)
            {
            return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login(UserLoginDto request)
        {
            var response = await _authRepo.Login(request.Username, request.Password , request.macadd);
            if(!response.Success)
            {
            return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
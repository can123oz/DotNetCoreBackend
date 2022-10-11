using Business.Abstract;
using Entity.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;
        private IAuthService _authService;
        

        public AuthController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
    }


        [HttpPost("Register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExist = _authService.UserExist(userForRegisterDto.Email);
            if (userExist.Success)
            {
                return BadRequest(userExist.Message);
            }
            
            var userRegister = _authService.Register(userForRegisterDto);     
            if (!userRegister.Success)
            {
                return BadRequest(userRegister.Message);
            }

            var result = _authService.CreateAcccessToken(userRegister.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }

        [HttpPost("Login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userLogin = _authService.Login(userForLoginDto);
            if (!userLogin.Success)
            {
                return BadRequest(userLogin.Message);
            }

            var result = _authService.CreateAcccessToken(userLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }

    }
}

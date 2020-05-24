using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Visitors_Registration_System.Data;
using Visitors_Registration_System.Data.Interfaces;
using Visitors_Registration_System.Entities;
using Visitors_Registration_System.Helpers;
using Visitors_Registration_System.Models;

namespace Visitors_Registration_System.Controllers
{
    [Authorize(Roles = Role.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IAdmin _userService;
        private IMapper _mapper;


        public AdminController(
            IAdmin userService,
            IMapper mapper)

        {
            _userService = userService;
            _mapper = mapper;

        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AdminDTO userDto)
        {
            var user = _userService.Authenticate(userDto.UserName, userDto.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            // return basic user info (without password) and token to store client side
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]AdminDTO userDto)
        {
            // map dto to entity
            var user = _mapper.Map<Admin>(userDto);

            try
            {
                // save 
                _userService.Create(user, userDto.Password);
                return Ok(user);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var user = _userService.GetAll();
            var userDtos = _mapper.Map<IList<AdminDTO>>(user);
            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var user = _userService.GetById(id);
            var userDto = _mapper.Map<AdminDTO>(user);
            return Ok(userDto);
        }


    }
}
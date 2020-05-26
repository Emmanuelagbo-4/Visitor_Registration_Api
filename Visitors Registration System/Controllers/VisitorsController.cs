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
using Visitors_Registration_System.Data.Interfaces;
using Visitors_Registration_System.Entities;
using Visitors_Registration_System.Helpers;
using Visitors_Registration_System.Models;

namespace Visitors_Registration_System.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorsController : ControllerBase
    {
        private IVisitors _userService;
        private IMapper _mapper;


        public VisitorsController(
            IVisitors userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;

        }


        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]VisitorDTO userDTO)
        {
            //map dto to entity
            var user = _mapper.Map<Visitors>(userDTO);

            try
            {
                //save
                _userService.Create(user, userDTO.Email);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody]VisitorDTO visitorDTO)
        {
            _userService.Login(visitorDTO.Email);
            return Ok("Successful Login");
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var user = _userService.GetAll();
            var userDtos = _mapper.Map<IList<VisitorDTO>>(user);
            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var CurrentUserId = Guid.Parse(User.Identity.Name);
            if (id != CurrentUserId && !User.IsInRole(Role.Admin))
                return Forbid();

            var user = _userService.GetById(id);
            var userDto = _mapper.Map<VisitorDTO>(user);

            return Ok(userDto);
        }
    }
}
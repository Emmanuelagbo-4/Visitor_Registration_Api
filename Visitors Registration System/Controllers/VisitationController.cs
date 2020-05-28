using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Visitors_Registration_System.Data;
using Visitors_Registration_System.Data.Interfaces;
using Visitors_Registration_System.Entities;
using Visitors_Registration_System.Helpers;
using Visitors_Registration_System.Models;

namespace Visitors_Registration_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitationController : ControllerBase
    {
        private readonly IVisitation _visitation;
        private readonly IMapper _mapper;
       
        public VisitationController(
            IVisitation visitation,
            IMapper mapper)
        {
            _visitation = visitation;
            _mapper = mapper;
           
        }

        
        [HttpGet("{id}", Name = "ObVisitation")]
        public IActionResult GetById(Guid id)
        {
            var CurrentUserId = Guid.Parse(User.Identity.Name);
            if (id != CurrentUserId && !User.IsInRole(Role.Admin))
                return Forbid();

            var userVisitation = _visitation.GetById(id);
            var visitationDTO = _mapper.Map<VisitationDTO>(userVisitation);
            return Ok(visitationDTO);
        }


        [HttpPost("Create")]
        public IActionResult Create([FromBody]VisitationCreationDTO visitationCreationDTO)
        {
           
            try
            {
                var visitation = _mapper.Map<Visitation>(visitationCreationDTO);
                _visitation.Create(visitation);
                var visitationDTO = _mapper.Map<VisitationDTO>(visitation);

                return new CreatedAtRouteResult("ObVisitation", new { id = visitation.Id }, visitationDTO);
            }
            catch (AppException ex)
            {
                //return an error msg if there is an exception
                return BadRequest(new { message = ex.Message });
            }
        }

       

        [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var userVisitations = _visitation.GetAll();
            var visitationDTOs = _mapper.Map<IList<VisitationDTO>>(userVisitations);
            return Ok(visitationDTOs);
        }

        
        //Make this a Patch
        [HttpPut("{id}")]
        public IActionResult Leave(Guid id, VisitationDTO visitationDTO)
        {
            if (id != visitationDTO.Id)
                return BadRequest();

            var userVisitation = _mapper.Map<Visitation>(visitationDTO);

            try
            {
                //save
                _visitation.Leave(id, userVisitation);
                return Ok("Feeback received");
            }
            catch (AppException ex)
            {
                //return an error msg if there is an exception
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
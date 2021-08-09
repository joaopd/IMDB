using AutoMapper;
using Domain.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [AllowAnonymous]
    [Route("api/employee")]
    public class EmployeeController : ControllerBase
    {

        public readonly IMapper _mapper;
        public readonly IEmployee _employee;

        public EmployeeController(IMapper mapper, IEmployee employee)
        {
            _mapper = mapper;
            _employee = employee;
        }

        [HttpGet]
        [Route("GetEmployee")]
        public async Task<ActionResult> GetList()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                return Ok(await _employee.List());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}

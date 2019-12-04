using ApplicationCore.DomainModel;
using ApplicationCore.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Models.RequestModels;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var emps = await _employeeService.ListAllAsync();
            var data = _mapper.Map<List<EmployeeRequestModel>>(emps);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBy(int id)
        {
            var emps = await _employeeService.GetBy(id);
            var data = _mapper.Map<EmployeeRequestModel>(emps);
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult> Add(EmployeeRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);
            var emp = _mapper.Map<EmployeeDM>(model);
           await _employeeService.CreateAsync(emp);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            await _employeeService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(EmployeeRequestModel model)
        {
            var emp = _mapper.Map<EmployeeDM>(model);
            await _employeeService.UpdateAsync(emp);
            return Ok();
        }
    }
}
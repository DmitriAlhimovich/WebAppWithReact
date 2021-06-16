using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using WebAppWithReact.Models;

namespace WebAppWithReact.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private EmployeeContext _db;

        public EmployeesController(ILogger<EmployeesController> logger, IWebHostEnvironment hostingEnvironment, EmployeeContext context)
        {
            _logger = logger;
            _db = context;

            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IEnumerable<Employees> Get()
        {
            return _db.Employees.ToList();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Employees employee = _db.Employees.FirstOrDefault(x => x.ID.ToString() == id);
            if (employee == null)
                return NotFound();

            try
            {
                _db.Employees.Remove(employee);
                return Ok(employee.ID);
            }
            finally
            {
                _db.SaveChanges();
            }
        }

        [AllowAnonymous]
        [HttpPost("addemployee")]
        //[HttpPost("{fio} {gender} {dateOfBirth} {department} {post} {room} {phine} {email}")]
        public ActionResult AddEmployee([FromBody] EmployeeModel model)
        {

            Employees employee = new Employees() {FirstName = model.FirstName, Department = model.Department};
            _db.Employees.Add(employee);
            _db.SaveChanges();

            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("editemployee/{id}")]
        public Employees EditEmployee(string id)
        {

            Guid guid = Guid.Parse(id.ToUpper());
            Employees employee = _db.Employees.FirstOrDefault(x => x.ID == guid);

            if (employee == null)
                return null;

            return employee;
        }

        [AllowAnonymous]
        [HttpPost("editemployee")]
        public ActionResult EditEmployee([FromBody] EmployeeModel model)
        {
            Guid guid = Guid.Parse(model.Id.ToUpper());
            var item = _db.Employees.Find(guid); // найдем запись
            if (item != null)
            {
                item.Post = model.Post;
                _db.SaveChanges();
            }
            return Ok();
        }

    }
}

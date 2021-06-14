using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost("addemployee")]
        //[HttpPost("{fio} {gender} {dateOfBirth} {department} {post} {room} {phine} {email}")]
        public ActionResult AddEmployee([FromForm(Name ="fio")] string fio)
        {
            Employees empl = new Employees();
            empl.ID = Guid.NewGuid();
            empl.FirstName = fio;

            //_db.Employees.Add(empl);            

            return RedirectToAction("employees");
        }
      
    }
}

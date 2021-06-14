using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WebAppWithReact.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
       private readonly ILogger<EmployeesController> _logger;
       private readonly IWebHostEnvironment _hostingEnvironment;
       private List<Employees> _data;
       private string _error;
       private readonly string _file;


        public EmployeesController(ILogger<EmployeesController> logger, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _error = string.Empty;
            _file = Path.Combine(_hostingEnvironment.ContentRootPath, "Data") + "\\Employees.xml";
            _data = (List<Employees>)XMLFunction.ReadInformation(_file, new List<Employees>(), out _error);
        }
                             
        [HttpGet]
        public IEnumerable<Employees> Get()
        {
            return (_error.Length > 0) ? null : _data;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Employees employee = _data.FirstOrDefault(x => x.ID.ToString() == id);
            if (employee == null)
              return NotFound();

            try
            {
               _data.Remove(employee);
               return Ok(employee.ID);
            }
            finally
            {
                XMLFunction.SaveInformation(_data, _file);
            }
        }

        [HttpPost("addemployee")]
        //[HttpPost("{fio} {gender} {dateOfBirth} {department} {post} {room} {phine} {email}")]
        public ActionResult addemployee([FromForm(Name ="fio")] string fio)
        {
            Employees empl = new Employees();
            empl.ID = Guid.NewGuid();
            empl.FirstName = fio;
            _data.Add(empl);
            

            return RedirectToAction("employees");
        }
      
    }
}

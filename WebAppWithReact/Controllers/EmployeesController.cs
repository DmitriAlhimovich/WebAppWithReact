using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        }
                             
        [HttpGet]
        public IEnumerable<Employees> Get()
        {
            _data = (List<Employees>)XMLFunction.ReadInformation(_file, new List<Employees>(), out _error);
            return _data;            
        }

        [HttpPost("delete/{id}")]
        public IActionResult Post(string id)
        {
            Employees employee = _data.FirstOrDefault(x => x.ID.ToString() == id);
            if (employee == null)
            {
                return NotFound();
            }
            try
            {
               _data.Remove(employee);
               return Ok(employee);
            }
            finally
            {
                //XMLFunction.SaveInformation(_data, _file);
            }
        }
    }
}

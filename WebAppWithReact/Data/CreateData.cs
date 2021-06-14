using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebAppWithReact.Models;

namespace WebAppWithReact.Data
{
    public static class CreateData
    {
        public static void Initialize(EmployeeContext context, IWebHostEnvironment hostingEnvironment)
        {
            if (!context.Employees.Any())
            {
                string error = string.Empty;
                string file = Path.Combine(hostingEnvironment.ContentRootPath, "Data") + "\\Employees.xml";
                context.Employees.AddRange((List<Employees>)XMLFunction.ReadInformation(file, new List<Employees>(), out error));
                context.SaveChanges();
            }

        }
    }
}

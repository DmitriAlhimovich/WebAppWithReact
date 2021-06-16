using System;
using System.Xml.Serialization;

namespace WebAppWithReact.Models
{
    /// <summary>
    /// Сотрудник
    /// </summary>

    public class EmployeeModel
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }


        public string Department { get; set; }

        public string Post { get; set; }

        public string Id { get; set; }

    }
}

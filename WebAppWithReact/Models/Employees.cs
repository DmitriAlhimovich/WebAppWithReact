using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace WebAppWithReact.Models
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    [Serializable]
    public class Employees
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// ФИО сотрудника
        /// </summary>
        public string FIO 
        { 
            get
            {
                return string.Format("{0} {1} {2}", LastName, FirstName, MiddleName);
            }
        }

        /// <summary>
        /// ФИО сотрудника сокращенно
        /// </summary>
        public string ShortFIO
        {
            get
            {
                return string.Format("{0} {1}{2}", LastName,
                    !string.IsNullOrEmpty(FirstName) ? FirstName.Substring(0, 1) + "." : string.Empty,
                !string.IsNullOrEmpty(MiddleName) ? MiddleName.Substring(0, 1) + "." : string.Empty);
            }
        }

        /// <summary>
        /// Пол
        /// </summary>
        public string Gender { get; set; }              

        /// <summary>
        /// Дата рождения
        /// </summary>
        //[XmlIgnore]
        [XmlElement(DataType = "date")]
        public DateTime? DateOfBirth { get; set; }        

        /// <summary>
        /// Подразделение
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// Должность
        /// </summary>
        public string Post { get; set; }

        /// <summary>
        /// Комната
        /// </summary>
        public string Room { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Фотография
        /// </summary>
        public string Photo { get; set; }

        /// <summary>
        /// Фотография
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Роль сотрудника
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Дата модификации
        /// </summary>
        public DateTime ModifyDate { get; set; }

        public bool IsReadGymInstruction { get; set; }

        /// <summary>
        /// Идентификатор сотрудника из БД
        /// </summary>
        public string Oid { get; set; }

        public Employees()
        { }
    }
}
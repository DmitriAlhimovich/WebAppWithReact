using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppWithReact.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } // имя пользователя
        public int Age { get; set; } // возраст пользователя
    }
}

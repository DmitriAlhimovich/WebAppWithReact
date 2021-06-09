using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppWithReact.Services
{
    public class TimeService
    {
        public TimeService()
        {
            Time = System.DateTime.Now.ToString("hh:mm:ss");
        }
        public string Time { get; }
    }
}

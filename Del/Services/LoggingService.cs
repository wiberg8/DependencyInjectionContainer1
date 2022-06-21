using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Del.Services
{
    public class LoggingService
    {
        public void Logg(object value)
        {
            Console.WriteLine("Logg: " + value.ToString());
        }
    }
}

using Del.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Del.Services
{
    public class ConsoleService : IConsoleService
    {
        LoggingService loggingService;

        public ConsoleService(LoggingService loggingService)
        {
            this.loggingService = loggingService;
        }

        public void WriteLine(object? value)
        {
            Console.WriteLine(value);
            loggingService.Logg("ConsoleService WriteLine");
        }
    }
}

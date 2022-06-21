using Del.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Del.Services
{
    public class Service1 : IService1
    {
        ConsoleService consoleService;

        public Service1(ConsoleService consoleService)
        {
            this.consoleService = consoleService;
        }

        public void Foo()
        {
            consoleService.WriteLine("Foo");
        }
    }
}

using Del;
using Del.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Del.Interfaces;

namespace Test
{
    public class ServiceCollectionTest
    {
        public bool Simple()
        {
            ServiceCollection services = new ServiceCollection()
                .AddSingelton<ConsoleService>()
                .AddSingelton<Service1>()
                .AddSingelton<LoggingService>();
            var service1 = services.GetService<Service1>();
            service1.Foo();
            return true;
        }

        public bool Abstract()
        {
            ServiceCollection services = new ServiceCollection()
                .AddSingelton<ConsoleService>()
                .AddSingelton<LoggingService>()
                .AddTransient<IService1, Service1>();
            IService1 service = services.GetService<IService1>();
            service.Foo();
            return true;
        }

        public bool MoreAbstract()
        {
            ServiceCollection services = new ServiceCollection()
                .AddSingelton<IConsoleService, ConsoleService>()
                .AddSingelton<LoggingService>()
                .AddTransient<IService1, Service1>();
            IService1 service = services.GetService<IService1>();
            service.Foo();
            return true;
        }
    }
}

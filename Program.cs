using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Microsoft.Extensions.DependencyInjection;
namespace WServiceTest_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var services = ConfigureServices();

            var rc = HostFactory.Run(x =>                                   //1
            {
                x.Service<ServiceTest>(s =>                                   //2
                {
                    s.ConstructUsing(name => services.GetService<ServiceTest>());               //3
                    s.WhenStarted(tc => tc.Start());                         //4
                    s.WhenStopped(tc => tc.Stop());                          //5
                });
                x.RunAsLocalSystem();                                       //6

                x.SetDescription("MyService");                   //7
                x.SetDisplayName("My Service");                                  //8
                x.SetServiceName("This is a sample Topshelf service.");                                  //9
            });                                                             //10

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());  //11
            Environment.ExitCode = exitCode;



        }
        private static ServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            // Register services and dependencies here
            //serviceCollection.AddSingleton<ICOM_LogFile, COM_LogFileHandler>();
            serviceCollection.AddSingleton<ServiceTest>();
            //serviceCollection.AddSingleton<ITimerService, TimerService>();
            return serviceCollection.BuildServiceProvider();
        }
    }
}

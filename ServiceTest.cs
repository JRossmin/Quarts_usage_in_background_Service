using QuartzLibrary;
using System;
using Countercsharp;
using System.Threading.Tasks;

namespace WServiceTest_2
{
    public class ServiceTest
    {
        
        public ServiceTest() { }
        public void Start()
        {

            Console.WriteLine("HOLA");
             JobSchedulerManager.Instance.InitializeAsync().GetAwaiter().GetResult();
            var count = new Countercsharp.CounterTest();
            var countvb = new VBLibrary.Counter();
            count.Counter();
            countvb.Counter();

        }
        public  void Stop()
        {
             JobSchedulerManager.Instance.ShutdownAsync().GetAwaiter().GetResult();
        }
    }
}

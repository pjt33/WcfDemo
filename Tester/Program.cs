using Interface;
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.ServiceModel;

[assembly: AssemblyTitle("Tester")]
[assembly: ComVisible(false)]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("Direct");
            Test("Proxied");
            Console.ReadLine();
        }

        private static void Test(string endpoint)
        {
            var factory = new ChannelFactory<IDemoService>(endpoint);
            var svc = factory.CreateChannel();
            try
            {
                var result = svc.DoTheThing(new DemoRequest { Foo = "A", Bar = "B" });
                Console.WriteLine($"{result.Baz}\t{result.Quux}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (svc is ICommunicationObject client)
                {
                    if (client.State == CommunicationState.Faulted) client.Abort();
                    else client.Close();
                }

                factory.Close();
            }
        }
    }
}

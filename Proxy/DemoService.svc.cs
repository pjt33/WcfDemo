[assembly: System.Reflection.AssemblyTitle("Proxy")]
[assembly: System.Reflection.AssemblyVersion("1.0.0.0")]
[assembly: System.Reflection.AssemblyFileVersion("1.0.0.0")]
[assembly: System.Runtime.InteropServices.ComVisible(false)]

namespace Proxy
{
    public class DemoService : Interface.IDemoService
    {
        private readonly System.ServiceModel.ChannelFactory<Interface.IDemoService> factory =
            new System.ServiceModel.ChannelFactory<Interface.IDemoService>("Backend");

        public Interface.DemoResponse DoTheThing(Interface.DemoRequest request)
        {
            request.Bar += "-Proxied";

            var svc = factory.CreateChannel();
            try
            {
                return svc.DoTheThing(request);
            }
            finally
            {
                if (svc is System.ServiceModel.ICommunicationObject client)
                {
                    if (client.State == System.ServiceModel.CommunicationState.Faulted) client.Abort();
                    else client.Close();
                }
            }
        }
    }
}

using System.ServiceModel;
using System.ServiceModel.Web;

namespace Interface
{
    [ServiceContract(Namespace = "urn:fdc:cheddarmonk.org:2019:WcfDemo")]
    public interface IDemoService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        DemoResponse DoTheThing(DemoRequest request);
    }

    public class DemoRequest
    {
        public string Foo { get; set; }
        public string Bar { get; set; }
    }

    public class DemoResponse
    {
        public string Baz { get; set; }
        public string Quux { get; set; }
    }
}

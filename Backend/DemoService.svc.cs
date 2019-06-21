using Interface;
using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("Backend")]
[assembly: ComVisible(false)]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

namespace Backend
{
    public class DemoService : IDemoService
    {
        public DemoResponse DoTheThing(DemoRequest request) =>
            new DemoResponse
            {
                Baz = request.Foo + request.Bar,
                Quux = request.Bar + request.Foo
            };
    }
}

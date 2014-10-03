using Topshelf;
using Topshelf.Nancy;

namespace AfterSchool {
    class Program {
        static void Main(string[] args){
            var host = HostFactory.New(x =>{
                x.Service<AfterSchoolService>(s =>{
                    s.ConstructUsing(settings => new AfterSchoolService());
                    s.WhenStarted(service => service.Start());
                    s.WhenStopped(service => service.Stop());
                    s.WithNancyEndpoint(x, n => {
                        n.AddHost(port: 9090);
                    });
                });
                x.StartAutomatically();
                x.SetServiceName("AfterSchool");
                x.RunAsNetworkService();
            });

            host.Run();
        }
    }
}

using IOC;
using LenLog;
using System;

namespace FakeProject
{
    class Program
    {
        private static Logger log = Logger.Instance;
        static void Main(string[] args)
        {
            log.Write("beginnign program");

            Injector injector = new Injector();
            injector.Bind<IHelper, HelperImplementerClass>();
            injector.Bind<IMessager, MessageService>();
            var presenter = injector.Resolve<Presenter>();
           
            presenter.present();


            Console.ReadLine();
        }
    }
}

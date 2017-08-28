using IOC;
using System;

namespace FakeProject
{
    class Program
    {
        static void Main(string[] args)
        {

            Injector injector = new Injector();
            injector.Bind<IHelper, HelperImplementerClass>();
            injector.Bind<IMessager, MessageService>();
            var presenter = injector.Resolve<Presenter>();
           
            presenter.present();


            Console.ReadLine();
        }
    }
}

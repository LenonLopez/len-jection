using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeProject
{
    class MessageService: IMessager
    {

        public void WorKDoneHandler(object source, EventArgs args)
        {

            Console.WriteLine("work is complete");
        }
    }
}

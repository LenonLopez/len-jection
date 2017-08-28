using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenLog
{
    public class Logger
    {
        private static readonly Logger logger = new Logger();
        private Logger(){}

        public static Logger Instance { get { return logger; } }

        public void Write(string text)
        {
            Console.WriteLine(text);

        }
    }

}

using System;

namespace FakeProject
{
    class HelperImplementerClass : IHelper
    {
        public void help(string with)
        {
            Console.WriteLine($"the helper class is helping me with: {with}");
        }
    }
}

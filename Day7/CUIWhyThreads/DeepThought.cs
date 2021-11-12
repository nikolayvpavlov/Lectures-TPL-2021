using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CUIWhyThreads
{
    internal class DeepThought
    {
        public int ComputeTheUltimateAnswer()
        {
            //In the book, this took about 8 million years...
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
            }
            return 42;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASomeTalks
{
    internal class SomeClass
    {
        object myLock = new object();

        List<string> myList;
        
        static object globalLock = new object();
        static int InstanceCount = 0;

        public SomeClass()
        {
            //This is useless; a constructor cannot be re-entered from multiple threads. Don't do it.
            lock (myLock)
            {
                myList = new List<string>();
                myList.Add ("a");
            }

            //Now, if we touch some global resource, we need to lock
            lock (globalLock)
            {
                InstanceCount = InstanceCount + 1;
            }
        }
    }
}

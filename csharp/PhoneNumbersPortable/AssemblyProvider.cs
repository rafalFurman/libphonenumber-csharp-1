using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumbers
{
    static class AssemblyProvider
    {
        public static Assembly GetAssembly()
        {
            return typeof(AssemblyProvider).GetTypeInfo().Assembly;
        }
    }
}

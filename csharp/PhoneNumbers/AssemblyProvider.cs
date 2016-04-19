using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PhoneNumbers
{
    static class AssemblyProvider
    {
        public static Assembly GetAssembly()
        {
            return typeof(AssemblyProvider).Assembly;
        }
    }
}

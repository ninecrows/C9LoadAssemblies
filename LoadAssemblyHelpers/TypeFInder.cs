using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadAssemblyHelpers
{
    public class TypeFinder : MarshalByRefObject, ITypeFinder
    {
        public string WhatAmI() => "SomethingDifferent";

        public string WhereAmI()
        {
            string value = AppDomain.CurrentDomain.FriendlyName;
            return (value);
        }

        public static ITypeFinder MyFactory() => new TypeFinder();
    }
}

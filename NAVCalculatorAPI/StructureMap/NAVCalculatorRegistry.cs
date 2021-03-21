using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NAVCalculatorAPI.Business.StructureMap;

namespace NAVCalculatorAPI.StructureMap
{
    public class NAVCalculatorRegistry : Registry
    {
        public NAVCalculatorRegistry()
        {
            Scan(x =>
            {
                x.TheCallingAssembly();
                x.WithDefaultConventions();
            });

            IncludeRegistry<BusinessRegistry>();
        }
    }
}
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAVCalculatorAPI.Repository.StructureMap;

namespace NAVCalculatorAPI.Business.StructureMap
{
    public class BusinessRegistry : Registry
    {
        public BusinessRegistry()
        {
            Scan(x =>
                {
                    x.TheCallingAssembly();
                    x.WithDefaultConventions();
                });
            IncludeRegistry<RepositoryRegistry>();
        }
    }
}

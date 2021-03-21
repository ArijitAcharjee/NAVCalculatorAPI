using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAVCalculatorAPI.Repository.StructureMap
{
    public class RepositoryRegistry : Registry
    {
        public RepositoryRegistry()
        {
            Scan(x =>
                {
                    x.TheCallingAssembly();
                    x.WithDefaultConventions();
                });
            For<NAVCalculatorEntities>().AlwaysUnique();
        }
    }
}

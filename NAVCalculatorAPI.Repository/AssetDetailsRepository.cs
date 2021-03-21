using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAVCalculatorAPI.Repository
{
    public interface IAssetDetailsRepository
    {
        Task<List<TestTable>> GetTestData();
    }

    public class AssetDetailsRepository : IAssetDetailsRepository
    {

        public async Task<List<TestTable>> GetTestData()
        {
            try {

                NAVCalculatorEntities dc = new NAVCalculatorEntities();
                List<TestTable> result = null;

                using (var dbContextTransaction = dc.Database.BeginTransaction())
                {
                    var myTask = Task.Run(() => dc.TestTables.ToList());
                    result = await myTask;

                    return result;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}

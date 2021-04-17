using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAVCalculatorAPI.Contract;


namespace NAVCalculatorAPI.Repository
{
    public interface IAssetDetailsRepository
    {
        Task<List<TestTable>> GetTestData();
        Task<TestTable> GetTestData(int id);
        Task<int> CreateTestData(TestTableContractModel model);
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

        public async Task<TestTable> GetTestData(int id)
        {
            try
            {

                NAVCalculatorEntities dc = new NAVCalculatorEntities();
                TestTable result = null;

                using (var dbContextTransaction = dc.Database.BeginTransaction())
                {
                    var myTask = Task.Run(() => dc.TestTables
                                                .Where(t => t.TestTableId == id)
                                                .First());
                    result = await myTask;

                    return result;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }



        public async Task<int> CreateTestData(TestTableContractModel model)
        {
            int returnValue = 0;
            NAVCalculatorEntities dc = new NAVCalculatorEntities();
            using (var dbContextTransaction = dc.Database.BeginTransaction())
            {
                try
                {
                    var existsTestData = dc.TestTables
                                            .Where(t => t.TestTableId == model.TestTableId)
                                            .Select(t => t.TestTableId)
                                            .FirstOrDefault();

                    if(existsTestData > 0)
                    {
                        returnValue = -1;
                    }
                    else
                    {
                        var dataModel = dc.TestTables.Create();

                        dataModel.TestTableId = model.TestTableId;
                        dataModel.FirstName = model.FirstName;
                        dataModel.SurName = model.SurName;

                        dc.TestTables.Add(dataModel);
                        await dc.SaveChangesAsync();

                        int TestTableID = dataModel.TestTableId;
                        returnValue = TestTableID;

                        dbContextTransaction.Commit();

                    }
                    return returnValue;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw;
                }
            }
        }

    }
}

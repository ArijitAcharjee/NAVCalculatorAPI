using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAVCalculatorAPI.Common.Converters.DBModelToContractModel;
using NAVCalculatorAPI.Contract;
using NAVCalculatorAPI.Repository.StructureMap;
using NAVCalculatorAPI.Repository;

namespace NAVCalculatorAPI.Business.Managers
{
    public interface IAssetDetailsManager
    {
        Task<List<TestTableContractModel>> GetTestData();
    }

    public class AssetDetailsManager : IAssetDetailsManager
    {
        public async Task<List<TestTableContractModel>> GetTestData()
        {
            var testRepo = Container.For<RepositoryRegistry>();
            var testRepoInstance = testRepo.GetInstance<IAssetDetailsRepository>();
            var result = await testRepoInstance.GetTestData();

            return result.Select(ConvertDBModelToContractModel.ToTestTableContractModel).ToList();
        }

    }
}

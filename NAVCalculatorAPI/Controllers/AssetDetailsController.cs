using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using NAVCalculatorAPI.Business.StructureMap;
using NAVCalculatorAPI.Contract;
using NAVCalculatorAPI.Business.Managers;

namespace NAVCalculatorAPI.Controllers
{
    [RoutePrefix("api/AssetDetails")]
    public class AssetDetailsController : ApiController
    {

        [HttpGet]
        [Route("GetTestData")]
        public async Task<IHttpActionResult> GetTestData()
        {
            try
            {
                var assetDetailsManager = Container.For<BusinessRegistry>();
                var assetDetailsManagerInstance = assetDetailsManager.GetInstance<IAssetDetailsManager>();
                var model = await assetDetailsManagerInstance.GetTestData();

                return Ok(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetTestData/{id}")]
        public async Task<IHttpActionResult> GetTestData(int id)
        {
            try
            {
                var assetDetailsManager = Container.For<BusinessRegistry>();
                var assetDetailsManagerInstance = assetDetailsManager.GetInstance<IAssetDetailsManager>();
                var model = await assetDetailsManagerInstance.GetTestData(id);

                return Ok(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateTestData")]
        public async Task<IHttpActionResult> CreateTestData(TestTableContractModel model)
        {
            int TestTableID;
            try
            {
                var assetDetailsManager = Container.For<BusinessRegistry>();
                var assetDetailsManagerInstance = assetDetailsManager.GetInstance<IAssetDetailsManager>();
                TestTableID = await assetDetailsManagerInstance.CreateTestData(model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}

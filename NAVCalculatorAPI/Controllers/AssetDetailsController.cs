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
    public class AssetDetailsController : ApiController
    {
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
    }
}

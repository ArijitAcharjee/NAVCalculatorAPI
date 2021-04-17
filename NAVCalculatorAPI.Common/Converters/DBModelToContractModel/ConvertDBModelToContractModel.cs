using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAVCalculatorAPI.Contract;
using NAVCalculatorAPI.Repository;

namespace NAVCalculatorAPI.Common.Converters.DBModelToContractModel
{
    public static class ConvertDBModelToContractModel
    {
        public static TestTableContractModel ToTestTableContractModel(this TestTable a)
        {
            TestTableContractModel model = new TestTableContractModel();
            try
            {
                if(a == null)
                {
                    return model;
                }
                else
                {
                    model.TestTableId = a.TestTableId;
                    model.FirstName = a.FirstName.ToUpper();
                    model.SurName = a.SurName;

                    return model;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

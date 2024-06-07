using EmployeeData;
using EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRepository
{
    public class ResourceR
    {
        private Boolean disposed = false;
        private ResourceD aResourceData = null;
        private string APIDataOutput = null;
        public string InsertResources(ResourceM aResourceM)
        {
            string result = "";
            try
            {
                aResourceData = new ResourceD();
                result = aResourceData.InsertResources(aResourceM);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                aResourceData.Dispose();
                aResourceData = null;
            }
            return result;
        }
        public string UpdateResource(ResourceM aResourceU)
        {
            string result = "";
            try
            {
                aResourceData = new ResourceD();
                result = aResourceData.UpdateResource(aResourceU);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                aResourceData.Dispose();
                aResourceData = null;
            }
            return result;
        }
    }
}

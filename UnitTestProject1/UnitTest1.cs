using EmployeeData;
using EmployeeModel;
using EmployeeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                ResourceD Data = new ResourceD();
                ResourceM Mod = new ResourceM();
                ResourceR Rep = new ResourceR();
                AdditionalJson adJson = new AdditionalJson();

                Mod.ResourceType = "Developer";
                Mod.ResourceCode = "DB9090";
                Mod.ResourceName = "Kavi";
                Mod.PrimaryPhone = "8907654321";
                Mod.EmailID = "ak@gmail.com";
                Mod.IsActive = true;
                adJson.Address1 = "09";
                adJson.Address2 = "North-Usman";
                adJson.Address3 = "Chennai";
                adJson.Address4 = 600028;
                adJson.DOB = "09/09/1999";
                adJson.Gender = "Male";
                Mod.AdditionalInfo = adJson;

                Data.InsertResources(Mod);

                var responce = new
                {
                    Responce_Code = 2000,
                    ResponseMessage = "Success",
                    ResponseList =JsonConvert.SerializeObject(Mod)
            };

                string s = JsonConvert.SerializeObject(responce);

                Console.WriteLine(s);

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                var responce = new
                {
                    Responce_Code = 5000,
                    ResponseMessage = "",
                    ResponseList = ex.Message
                };

                string s = JsonConvert.SerializeObject(responce);

                Console.WriteLine(s);
            }
        }
    }
}

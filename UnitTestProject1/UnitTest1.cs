using EmployeeData;
using EmployeeModel;
using EmployeeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ResourceD Data = new ResourceD();
            ResourceM Mod = new ResourceM();
            ResourceR Rep = new ResourceR();
            AdditionalJson adJson = new AdditionalJson();
            try
            {
                Console.WriteLine("Insert--1,Update--2,Delete--3,ToGet--4");
                int input = int.Parse(Console.ReadLine());
                switch (input) {
                    case 1:
                    Mod.ResourceType = "Developer";
                    Mod.ResourceCode = "DB9090";
                    Mod.ResourceName = "Elango";
                    Mod.PrimaryPhone = "8907654321";                     
                    Mod.SecondaryPhone = "83290923683";
                    Mod.EmailID = "ak@gmail.com";
                    Mod.IsActive = true;
                    adJson.Address1 = "09";
                    adJson.Address2 = "North-Usman";
                    adJson.Address3 = "Chennai";
                    adJson.Address4 = 600028;
                    adJson.DOB = "09/09/1999";
                    adJson.Gender = "Male";
                    Mod.AdditionalInfo = adJson;

                     string answer1= Data.InsertResources(Mod);

                    var responce = new
                    {
                        Responce_Code = 2000,
                        ResponseMessage = answer1,
                        ResponseList = JsonConvert.SerializeObject(Mod)
                    };

                    string s = JsonConvert.SerializeObject(responce, Formatting.Indented);

                    Console.WriteLine(s);
                    break;
                    case 2:
                        Mod.ResourceUID = 1;
                        Mod.ResourceType = "Developer";
                        Mod.ResourceCode = "DB9090";
                        Mod.ResourceName = "kavin";
                        Mod.PrimaryPhone = "9489737331";
                        Mod.SecondaryPhone = "679801423";
                        Mod.EmailID = "ak@gmail.com";
                        Mod.IsActive = true;
                        adJson.Address1 = "09";
                        adJson.Address2 = "North-Usman";
                        adJson.Address3 = "Chennai";
                        adJson.Address4 = 600028;
                        adJson.DOB = "09/09/1999";
                        adJson.Gender = "Male";
                        Mod.AdditionalInfo = adJson;

                        string answer=Data.UpdateResource(Mod);

                        var responce1 = new
                        {
                            Responce_Code = 2000,
                            ResponseMessage = answer,
                            ResponseList = JsonConvert.SerializeObject(Mod)
                        };

                        string s1 = JsonConvert.SerializeObject(responce1, Formatting.Indented);

                        Console.WriteLine(s1);
                        break;

                    case 3:
                        Mod.ResourceUID = 10004;
                        Data.DeleteResource(Mod);
                        var responce2 = new
                        {
                            Responce_Code = 2000,
                            ResponseMessage = "Success",
                            ResponseList = JsonConvert.SerializeObject(Mod)
                        };

                        string s2 = JsonConvert.SerializeObject(responce2);

                        Console.WriteLine(s2);
                        break;
                    case 4:
                        List<ResourceM> employees = Rep.GetResources();

                        if (employees != null && employees.Count > 0)
                        {
                            foreach (var employee in employees)
                            {
                                PrintEmployeeDetails(employee);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No employees found.");
                        }
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }
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
        public void PrintEmployeeDetails(ResourceM employee)
        {
            Console.WriteLine("Employee Details:");
            Console.WriteLine($"ResourceUID: {employee.ResourceUID}");
            Console.WriteLine($"ResourceCode: {employee.ResourceCode}");
            Console.WriteLine($"ResourceType: {employee.ResourceType}");
            Console.WriteLine($"ResourceName: {employee.ResourceName}");
            Console.WriteLine($"PrimaryPhone: {employee.PrimaryPhone}");
            Console.WriteLine($"SecondaryPhone: {employee.SecondaryPhone}");
            Console.WriteLine($"EmailId: {employee.EmailID}");
            Console.WriteLine($"IsActive: {employee.IsActive}");
            Console.WriteLine("Additional Info:");
            Console.WriteLine($"  Address1: {employee.AdditionalInfo.Address1}");
            Console.WriteLine($"  Address2: {employee.AdditionalInfo.Address2}");
            Console.WriteLine($"  Address3: {employee.AdditionalInfo.Address3}");
            Console.WriteLine($"  Address4: {employee.AdditionalInfo.Address4}");
            Console.WriteLine($"  DOB: {employee.AdditionalInfo.DOB}");
            Console.WriteLine($"  Gender: {employee.AdditionalInfo.Gender}");
            Console.WriteLine("-------------------------------");
        }
    }
}
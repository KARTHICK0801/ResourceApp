using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeModel
{
    public class ResourceM
    {
        public decimal ResourceUID { get; set; }
        public string ResourceType { get; set; }
        public string ResourceCode { get; set; }
        public string ResourceName { get; set; }
        public string PrimaryPhone { get; set; }
        public string SecondaryPhone { get; set; }
        public string EmailID { get; set; }
        public bool IsActive { get; set; }
        public AdditionalJson AdditionalInfo { get; set; }
    }
    public class AdditionalJson
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public int Address4 { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
    }
}

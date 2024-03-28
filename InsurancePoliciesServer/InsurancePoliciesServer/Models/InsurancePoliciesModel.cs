using InsurancePoliciesServer.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsurancePoliciesServer.Models
{
    public class InsurancePoliciesModel
    {
        public int ID { get; set; }
        public string PolicyNumber { get; set; }
        public int InsuranceAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
    }
}

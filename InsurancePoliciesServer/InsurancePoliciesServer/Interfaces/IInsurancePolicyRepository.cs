using InsurancePoliciesServer.Entities;
using InsurancePoliciesServer.Models;

namespace InsurancePoliciesServer.Interfaces
{
    public interface IInsurancePolicyRepository
    {
        public List<InsurancePolicies> GetAllInsurancePolicies();
        public void AddInsurancePolicy(InsurancePoliciesModel insurancePolicy);
        public void UpdateInsurancePolicy(InsurancePoliciesModel insurancePolicy);
        public void DeleteInsurancePolicy(int userId);
        public List<InsurancePolicies> GetUserPolicies(int userId);
        public InsurancePolicies GetPolicyById(int userId);
    }
}

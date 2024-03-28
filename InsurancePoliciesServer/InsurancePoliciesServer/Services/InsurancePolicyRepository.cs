using InsurancePoliciesServer.Context;
using InsurancePoliciesServer.Entities;
using InsurancePoliciesServer.Interfaces;
using InsurancePoliciesServer.Models;
using System.Threading.Tasks;

namespace InsurancePoliciesServer.Services
{
    public class InsurancePolicyRepository : BaseService, IInsurancePolicyRepository
    {
        public InsurancePolicyRepository(
           ApplicationContext ctx,
           ILogger<InsurancePolicyRepository> logger) : base(ctx, logger)
        {
        }
        public void AddInsurancePolicy(InsurancePoliciesModel insurancePolicy)
        {
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                _dbContext.Add(new InsurancePolicies
                {
                    PolicyNumber = insurancePolicy.PolicyNumber,
                    InsuranceAmount = insurancePolicy.InsuranceAmount,
                    StartDate = insurancePolicy.StartDate,
                    EndDate = insurancePolicy.EndDate,
                    UserId = insurancePolicy.UserId
                });
                _dbContext.SaveChanges();
                dbContextTransaction.Commit();
            }
        }

        public void DeleteInsurancePolicy(int insurancePolicyId)
        {
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                InsurancePolicies deletedPolicy = _dbContext.InsurancePolicies.FirstOrDefault(t => t.ID == insurancePolicyId);
                if (null != deletedPolicy)
                {
                    _dbContext.Remove(deletedPolicy);
                }
                _dbContext.SaveChanges();
                dbContextTransaction.Commit();
            }
        }

        public List<InsurancePolicies> GetAllInsurancePolicies()
        {
            return _dbContext.InsurancePolicies.OrderBy(t => t.StartDate).ToList();
        }

        public List<InsurancePolicies> GetUserPolicies(int userId)
        {
            return _dbContext.InsurancePolicies.Where(t => t.UserId == userId).ToList();
        }

        public void UpdateInsurancePolicy(InsurancePoliciesModel insurancePolicy)
        {
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                InsurancePolicies updatedinsurancePolicy = _dbContext.InsurancePolicies.FirstOrDefault(t => t.ID == insurancePolicy.ID);
                if (null != updatedinsurancePolicy)
                {
                    updatedinsurancePolicy.InsuranceAmount = insurancePolicy.InsuranceAmount;
                    updatedinsurancePolicy.PolicyNumber = insurancePolicy.PolicyNumber;
                    updatedinsurancePolicy.StartDate = insurancePolicy.StartDate;
                    updatedinsurancePolicy.EndDate = insurancePolicy.EndDate;
                    updatedinsurancePolicy.UserId = insurancePolicy.UserId;
                    _dbContext.Update(updatedinsurancePolicy);
                }
                _dbContext.SaveChanges();
                dbContextTransaction.Commit();
            }
        }

        public InsurancePolicies GetPolicyById(int policyId)
        {
            InsurancePolicies policy = _dbContext.InsurancePolicies.FirstOrDefault(t => t.ID == policyId);
            if (null != policy)
                return policy;
            else
                throw new Exception("User Not Found");
        }
    }
}

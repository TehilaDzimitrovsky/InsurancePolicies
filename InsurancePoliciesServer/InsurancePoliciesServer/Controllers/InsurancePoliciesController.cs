using InsurancePoliciesServer.Entities;
using InsurancePoliciesServer.Interfaces;
using InsurancePoliciesServer.Models;
using InsurancePoliciesServer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InsurancePoliciesServer.Controllers
{
    [Route("InsurancePoliciesController")]
    [ApiController]
    public class InsurancePoliciesController : Controller
    {
        private readonly IInsurancePolicyRepository _insurancePolicyRepository;

        public InsurancePoliciesController(IInsurancePolicyRepository insurancePolicyRepository)
        {
            _insurancePolicyRepository = insurancePolicyRepository;
        }

        [HttpGet]
        [Route("GetAllInsurancePolicies")]
        public IActionResult GetAllInsurancePolicies()
        {
            try
            {
                List<InsurancePolicies> Tasks = _insurancePolicyRepository.GetAllInsurancePolicies();
                return Ok(Tasks);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddInsurancePolicy")]
        public IActionResult AddInsurancePolicy([FromBody] InsurancePoliciesModel policy)
        {
            try
            {
                _insurancePolicyRepository.AddInsurancePolicy(policy);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("UpdateInsurancePolicy")]
        public IActionResult UpdateInsurancePolicy([FromBody] InsurancePoliciesModel policy)
        {
            try
            {
                _insurancePolicyRepository.UpdateInsurancePolicy(policy);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteInsurancePolicy/{policyId}")]
        public IActionResult DeleteInsurancePolicy(int policyId)
        {
            try
            {
                _insurancePolicyRepository.DeleteInsurancePolicy(policyId);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetUserPolicies/{userId}")]
        public IActionResult GetUserPolicies(int userId)
        {
            try
            {
                List<InsurancePolicies> Tasks = _insurancePolicyRepository.GetUserPolicies(userId);
                return Ok(Tasks);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetPolicyById/{policyId}")]
        public IActionResult GetPolicyById(int policyId)
        {
            try
            {
                InsurancePolicies policy = _insurancePolicyRepository.GetPolicyById(policyId);
                return Ok(policy);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

using InsurancePoliciesServer.Context;

namespace InsurancePoliciesServer.Services
{
    public class BaseService
    {
        private readonly ILogger<BaseService> _logger;
        public ApplicationContext _dbContext;
        public BaseService(
   ApplicationContext dbContext,
   ILogger<BaseService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
    }
}

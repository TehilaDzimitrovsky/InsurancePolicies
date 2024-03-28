using InsurancePoliciesServer.Context;
using InsurancePoliciesServer.Entities;
using InsurancePoliciesServer.Interfaces;

namespace InsurancePoliciesServer.Services
{
    public class UserRepository : BaseService, IUserRepository
    {
        public UserRepository(
         ApplicationContext ctx,
         ILogger<UserRepository> logger) : base(ctx, logger)
        {
        }
        public async Task AddUser(Users user)
        {
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                _dbContext.Add(new Users
                {
                    Name = user.Name,
                    Email = user.Email,
                });
                _dbContext.SaveChanges();
                dbContextTransaction.Commit();
            }
        }

        public async Task DeleteUser(int userId)
        {
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                Users deletedUser = _dbContext.Users.FirstOrDefault(t => t.ID == userId);
                if (null != deletedUser)
                {
                    var usersPolicies = _dbContext.InsurancePolicies.Where(t => t.UserId == userId).ToList();
                    if (usersPolicies.Count() > 0)
                        _dbContext.RemoveRange(usersPolicies);
                    _dbContext.Remove(deletedUser);
                }
                _dbContext.SaveChanges();
                dbContextTransaction.Commit();
            }
        }

        public List<Users> GetAllUsers()
        {
            return _dbContext.Users.OrderBy(u => u.Name).ToList();
        }

        public async Task UpdateUser(Users user)
        {
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                Users UpdatedUser = _dbContext.Users.FirstOrDefault(t => t.ID == user.ID);
                if (null != UpdatedUser)
                {
                    UpdatedUser = user;
                    _dbContext.Update(UpdatedUser);
                }
                _dbContext.SaveChanges();
                dbContextTransaction.Commit();
            }
        }

        public Users GetUserById(int userId)
        {
            Users user = _dbContext.Users.FirstOrDefault(t => t.ID == userId);
            if (null != user)
                return user;
            else
                throw new Exception("User Not Found");
        }
    }
}

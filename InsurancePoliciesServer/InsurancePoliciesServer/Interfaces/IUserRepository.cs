using InsurancePoliciesServer.Entities;

namespace InsurancePoliciesServer.Interfaces
{
    public interface IUserRepository
    {
        public List<Users> GetAllUsers();
        public Task AddUser(Users user);
        public Task UpdateUser(Users user);
        public Task DeleteUser(int userId);
        public Users GetUserById(int userId);
    }
}

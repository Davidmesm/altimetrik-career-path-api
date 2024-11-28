using CareerPathCore.Domain.Entities;

namespace CareerPathCore.Contracts
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmail(string? email);
        Task<User> AddUser(User user);

        Task<UserProfile> AddUserProfile(UserProfile profile);
        Task<UserProfile> UpdateUserProfile(UserProfile profile);
        Task<bool> DeleteUserProfile(Guid Id);
        Task<UserProfile?> GetUserProfile(Guid Id);


    }
}

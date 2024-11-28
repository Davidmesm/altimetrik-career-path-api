using CareerPathCore.Contracts;
using CareerPathCore.Domain.Entities;
using CareerPathCore.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CareerPathCore.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByEmail(string? email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> AddUser(User user)
        {
            var currentTime = DateTime.UtcNow;

            user.CreatedAt = currentTime;
            user.UpdatedAt = currentTime;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<UserProfile> AddUserProfile(UserProfile profile)
        {
            var currentTime = DateTime.UtcNow;
            profile.CreatedAt = currentTime;
            profile.UpdatedAt = currentTime;

            await _context.UserProfiles.AddAsync(profile);
            await _context.SaveChangesAsync();

            return profile;
        }

        public async Task<UserProfile> UpdateUserProfile(UserProfile profile)
        {
            var existingProfile = await _context.UserProfiles.FindAsync(profile.Id);

            if (existingProfile == null)
            {
                throw new NotFoundException("User profile not found.");
            }

            existingProfile.FirstName = profile.FirstName ?? existingProfile.FirstName;
            existingProfile.LastName = profile.LastName ?? existingProfile.LastName;
            existingProfile.Bio = profile.Bio ?? existingProfile.Bio;
            existingProfile.CurrentJobRoleId = profile.CurrentJobRoleId;
            existingProfile.EducationLevel = profile.EducationLevel ?? existingProfile.EducationLevel;
            existingProfile.FieldOfStudy = profile.FieldOfStudy ?? existingProfile.FieldOfStudy;
            existingProfile.FutureJobRoleId = profile.FutureJobRoleId;

            existingProfile.UpdatedAt = DateTime.UtcNow;

            _context.UserProfiles.Update(existingProfile);
            await _context.SaveChangesAsync();

            return existingProfile;
        }


        public async Task<bool> DeleteUserProfile(Guid id)
        {
            var existingProfile = await _context.UserProfiles.FindAsync(id);

            if (existingProfile == null)
            {
                throw new NotFoundException("User profile not found.");
            }

            _context.UserProfiles.Remove(existingProfile);

            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<UserProfile?> GetUserProfile(Guid Id)
        {
            var profile = await _context.UserProfiles.FindAsync(Id);

            return profile;
        }
    }
}

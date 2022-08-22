using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Data.Entities;
using TestProject.Data.Repositories.Interfaces;

namespace TestProject.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ZipCoContext _context;

        public UserRepository(ZipCoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User> CreateAsync(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetAsync(string emailAddress)
        {
            return (await _context.Users.ToListAsync()).FirstOrDefault(x => string.Equals(x.EmailAddress, emailAddress, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
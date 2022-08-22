using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Data.Entities;
using TestProject.Data.Repositories.Interfaces;

namespace TestProject.Data.Repositories
{
    public class AccountRepository : IRepository<Account>
    {
        private readonly ZipCoContext _context;

        public AccountRepository(ZipCoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Account> CreateAsync(Account account)
        {
            _context.Add(account);
            await _context.SaveChangesAsync();

            return account;
        }

        public async Task<IEnumerable<Account>> ListAsync()
        {
            return await _context.Accounts.Include(x => x.User).Select(x => x).ToListAsync();
        }
    }
}
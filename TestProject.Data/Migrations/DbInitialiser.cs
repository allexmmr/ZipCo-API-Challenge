using System.Collections.Generic;
using System.Linq;
using TestProject.Common.Utils;
using TestProject.Data.Entities;

namespace TestProject.Data.Migrations
{
    public static class DbInitialiser
    {
        public static void Initialise(ZipCoContext context)
        {
            context.Database.EnsureCreated();

            // Look for any user
            if (context.Users.Any())
            {
                return; // DB has been seeded
            }

            // Create users
            var users = new List<User>
            {
                new User { Name = "Administrator", EmailAddress = "admin@zip.co", Password = Encryptor.EncryptMD5("Izi5XK0sLgpoHc56Nisv") },
            };

            foreach (var user in users)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();
        }
    }
}
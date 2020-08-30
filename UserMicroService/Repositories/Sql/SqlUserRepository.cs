using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserMicroService.Infraestructure.EntityFramework;
using UserMicroService.Models;
using UserMicroService.Repositories.Sql.EF;

namespace UserMicroService.Repositories.Sql
{
    public class SqlUserRepository : IUserMicroserviceRepository
    {
        private readonly IEFContextProvider _microserviceContext;

        public SqlUserRepository(IEFContextProvider microserviceContext)
        {
            _microserviceContext = microserviceContext;
        }

        public async Task<List<Users>> FindAllUsers()
        {
            try
            {
                await using (var context = (MicroservicesContext) _microserviceContext.GetContext())
                {
                    var users =
                        await context.Users
                            .ToListAsync();
                    return users;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error consulting users: " + exception.Message);
                throw new Exception(exception.Message);
            }
        }

        public async Task<Users> FindUserById(long userId)
        {
            try
            {
                await using (var context = (MicroservicesContext) _microserviceContext.GetContext())
                {
                    var users =
                        await context.Users.Where(x => x.Identification.Equals(userId)).FirstOrDefaultAsync();
                    return users;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error consulting users: " + exception.Message);
                throw new Exception(exception.Message);
            }
        }

        public async Task<bool> SaveUser(Users user)
        {
            try
            {
                await using (var context = (MicroservicesContext) _microserviceContext.GetContext())
                {
                    await context.Users.AddAsync(user);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error saving user: " + exception.Message);
                throw new Exception(exception.Message);
            }
        }

        public async Task<Users> UpdateUser(Users user)
        {
            try
            {
                await using (var context = (MicroservicesContext) _microserviceContext.GetContext())
                {
                    var userRequested =
                        await context.Users.SingleOrDefaultAsync(x => x.Identification.Equals(user.Identification));

                    if (userRequested == null) return null;
                    userRequested.Email = user.Email;
                    userRequested.Name = user.Name;
                    userRequested.Password = user.Password;
                    userRequested.Phone = user.Phone;
                    userRequested.Rol = user.Rol;
                    userRequested.LastName = user.LastName;

                    await context.SaveChangesAsync();

                    return userRequested;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error updating user: " + exception.Message);
                throw new Exception(exception.Message);
            }
        }

        public async Task<bool> DeleteUser(long userId)
        {
            try
            {
                await using (var context = (MicroservicesContext) _microserviceContext.GetContext())
                {
                    var userToRemove =
                        context.Users.SingleOrDefaultAsync(x =>
                            x.Identification.Equals(userId)); //returns a single item.

                    if (userToRemove == null) return false;

                    context.Users.Remove(userToRemove.Result);
                    await context.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error deleting user: " + exception.Message);
                throw new Exception(exception.Message);
            }
        }

        public async Task<Users> AutenticateUser(Autentication autenticationd)
        {
            try
            {
                await using (var context = (MicroservicesContext) _microserviceContext.GetContext())
                {
                    var userAutenticated =
                        await context.Users.SingleOrDefaultAsync(x =>
                            x.Email.Equals(autenticationd.Email) && x.Password.Equals(autenticationd.Password));

                    return userAutenticated;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error checking user credentials: " + exception.Message);
                throw new Exception(exception.Message);
            }
        }
    }
}
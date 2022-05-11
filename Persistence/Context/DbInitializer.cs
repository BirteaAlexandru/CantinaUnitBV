using Domain;

namespace Persistence.Context
{
    public class DbInitializer
    {
        public static void Initialize(CantinaBvContext context)
        {
            context.Database.EnsureCreated();

            var roleDbSet = context.Set<Role>();

            if (roleDbSet.Any())
            {
                return;
            }

            var roles = new[]
            {
                    new Role
                    {
                        Name ="user",
                        Type= RoleEnum.User
                    },
                    new Role
                    {
                        Name ="admin",
                        Type= RoleEnum.Admin
                    }
                };

            roleDbSet.AddRange(roles);

            //var basicUserRole = roles.First(p => p.Type == RoleEnum.User);
            //var adminRole = roles.First(p => p.Type == RoleEnum.Admin);

            //var users = new[]
            //{
            //    new User
            //    {
            //        Email = "test@yahoo.com",
            //        Password = "123",
            //        FirstName = "Andrei",
            //        SecondName= "Razvan",
            //        Role= basicUserRole
            //    },
            //    new User
            //    {
            //        Email = "test2@yahoo.com",
            //        Password = "123",
            //        FirstName = "Andrei2",
            //        SecondName= "Razvan2",
            //        Role= adminRole

            //    }
            //};

            //context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}

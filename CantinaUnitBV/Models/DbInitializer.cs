namespace CantinaUnitBV.Models
{
    public class DbInitializer
    {
        public static void Initialize(UserContext context)
        {
            context.Database.EnsureCreated();

            if (context.Roles.Any())
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

            context.Roles.AddRange(roles);

            var basicUserRole = roles.First(p => p.Type == RoleEnum.User);
            var adminRole = roles.First(p => p.Type == RoleEnum.Admin);

            var users = new[]
            {
                new User
                {
                    Email = "test@yahoo.com",
                    Password = "123",
                    FirstName = "Andrei",
                    SecondName= "Razvan",
                    Role= basicUserRole
                },
                new User
                {
                    Email = "test2@yahoo.com",
                    Password = "123",
                    FirstName = "Andrei2",
                    SecondName= "Razvan2",
                    Role= adminRole

                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}

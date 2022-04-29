namespace CantinaUnitBV.Models
{
    public class DbInitializer
    {
        public static void Initialize(UserContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
               return;
            }

            var users = new[]
            {
                new User
                {
                    Email = "test@yahoo.com",
                    Password = "123",
                    FirstName = "Andrei",
                    SecondName= "Razvan"

                },
                new User
                {
                    Email = "test2@yahoo.com",
                    Password = "123",
                    FirstName = "Andrei2",
                    SecondName= "Razvan2"

                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}

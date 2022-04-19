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

                }
            };

            context.Users.AddRange(users);


            context.SaveChanges();
        }
    }
}

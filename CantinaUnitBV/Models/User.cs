using System.ComponentModel.DataAnnotations.Schema;

namespace CantinaUnitBV.Models
{
    public class User
    {

        public long Id { get; set; }
        public User()
        {

        }
        public User(long id)
        {
            Id = id;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public UsereType? Type { get; set; }
    }
}

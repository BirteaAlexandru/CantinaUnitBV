using Domain.Base;

namespace Domain
{
    public enum RoleEnum { User, Admin}
    public class Role : Entity
    {
        public string Name { get; set; }
        public RoleEnum Type { get; set; }
        public ICollection<User> Users { get; set; }
    }
}

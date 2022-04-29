using System.ComponentModel.DataAnnotations.Schema;

namespace CantinaUnitBV.Models
{
    public enum RoleEnum { User, Admin}
    public class Role
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public RoleEnum Type { get; set; }

        public ICollection<User> Users { get; set; }
    }
}

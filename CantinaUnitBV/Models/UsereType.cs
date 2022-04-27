using System.ComponentModel.DataAnnotations.Schema;

namespace CantinaUnitBV.Models
{
    public enum Type { user, admin}
    public class UsereType
    {
        public long Id { get; set; }
        public Type tip { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}

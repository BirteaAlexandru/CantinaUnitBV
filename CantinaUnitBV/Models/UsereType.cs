using System.ComponentModel.DataAnnotations.Schema;

namespace CantinaUnitBV.Models
{
    public enum Type { user, admin}
    public class UsereType
    {
        [ForeignKey("User")]

        public long Id { get; set; }
        public Type tip { get; set; }

        User user { get; set; }
    }
}

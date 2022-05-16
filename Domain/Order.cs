using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Order: Entity
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public ICollection<RecipesOrder> RecipesOrders { get; set; }
    }
}

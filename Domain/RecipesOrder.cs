using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RecipesOrder: Entity
    {
        public long RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public long OrderId { get; set; }
        public Order Order { get; set; }
    }
}

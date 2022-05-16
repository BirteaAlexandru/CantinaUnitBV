using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Services.Orders.Responses
{
    public class OrderResponse
    {   
        public long Id { get; set; }
        public User User { get; set; }
        public ICollection<RecipesOrder> RecipesOrder { get; set; }

    }
}


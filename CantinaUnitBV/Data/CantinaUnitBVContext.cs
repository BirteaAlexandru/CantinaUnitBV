using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace CantinaUnitBV.Data
{
    public class CantinaUnitBVContext : DbContext
    {
        public CantinaUnitBVContext(DbContextOptions<CantinaUnitBVContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Order>? Order { get; set; }

        public DbSet<Domain.Recipe>? Recipe { get; set; }
    }
}

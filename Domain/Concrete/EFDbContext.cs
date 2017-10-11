using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Entities;

namespace Domain.Concrete
{
   public class EFDbContext: DbContext 
    {
        public EFDbContext() : base("TankMuseumDB") { }
        public DbSet<Exhibit> Exhibits { get; set; }
    }
}

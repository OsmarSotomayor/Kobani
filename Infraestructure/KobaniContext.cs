using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure
{
    public class KobaniContext: DbContext
    {
        public KobaniContext(DbContextOptions options)
            :base(options) 
        { 

        }

        public DbSet<Partner> Partners { get; set; }
        
    }

}
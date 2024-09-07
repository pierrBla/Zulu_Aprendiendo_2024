using Microsoft.EntityFrameworkCore;
using Zulu.Shared.Entities;

namespace Zulu.Api.Data
{
    //tenemos que eredar DbContext
    //instalamos el  entityFremeworkcore
    public class DataContext:DbContext
    {
        //crear ctor =contructor pasale DbContextOptions<DataContext>options
        public DataContext(DbContextOptions<DataContext>options):base(options) 
        
        {   

        }
        //crear una propieda para mapear las tablas 
        public DbSet<Country> Countries { get; set; }

        //para que no vea duplicado
        //override OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(x=>x.Name).IsUnique();
        }

    }

    }


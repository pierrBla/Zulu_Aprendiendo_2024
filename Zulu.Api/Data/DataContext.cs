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

        public DbSet<Category> Categories { get; set; }

        public DbSet<State> Staties { get; set; }

        public DbSet<City> Cities { get; set; }



        //para que no vea duplicado
        //override OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(x=>x.Name).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<State>().HasIndex("CountryId","Name").IsUnique();
            modelBuilder.Entity<City>().HasIndex("StateId", "Name").IsUnique();

            //cada vez que vea un cambio  de migracion
            //add-migration AddCategoriaAndCitiAndState
            // drop-database eliminar
            //update-database 



        }

    }

    }


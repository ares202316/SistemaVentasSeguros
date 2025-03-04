using BackendSeguros.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendSeguros.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Cobertura>()
               .HasOne(p => p.Ramo)
               .WithMany()
               .HasForeignKey(p => p.ramoId)
               .OnDelete(DeleteBehavior.Restrict);

                    builder.Entity<Poliza>()
                   .HasOne(p => p.Cliente)
                   .WithMany()  
                   .HasForeignKey(p => p.clienteId)
                   .OnDelete(DeleteBehavior.Restrict); 

           
            builder.Entity<Poliza>()
                .HasOne(p => p.Corredor)
                .WithMany()  
                .HasForeignKey(p => p.corredorId)
                .OnDelete(DeleteBehavior.Restrict);

            
            builder.Entity<Poliza>()
                .HasOne(p => p.Ramo)
                .WithMany()  
                .HasForeignKey(p => p.ramoId)
                .OnDelete(DeleteBehavior.Restrict);

        }




        //Aqui pasar todas las entidades (Modelos)

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Ramo> Ramo { get; set; }
        public DbSet<Cobertura> Cobertura { get; set; }

        public DbSet<Corredor> Corredor { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Poliza> Poliza { get; set; }


    }
}


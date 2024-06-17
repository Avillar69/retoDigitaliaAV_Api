using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using retoDigitaliaAV_Api.Models.Encuesta;

namespace retoDigitaliaAV_Api.Context
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EncuestaModel> Encuesta { get; set; }
        public DbSet<EncuestaOpcionModel> EncuestaOpcion { get; set; }
        public DbSet<VotacionModel> Votacion { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EncuestaModel>()
                .HasMany(s => s.Opciones)
                .WithOne(d => d.Encuesta)
                .HasForeignKey(d => d.idEncuesta);

            modelBuilder.Entity<EncuestaOpcionModel>()
                .HasMany(s => s.Votos)
                .WithOne(d => d.EncuestaOpcion)
                .HasForeignKey(d => d.idOpcion);
        }
    }
}

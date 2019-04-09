using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Disciplina> Disciplinas { get; set; }

        public DbSet<Curso> Cursos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name);
            }

           // modelBuilder.Entity<Curso>().HasOne<Usuario>(s => s.Coordenador).WithMany(g => g.Cursos);
            //modelBuilder.Entity<Usuario>().HasMany<Curso>(s => s.Cursos).WithOne().HasForeignKey(g => g.CoordenadorId);
            //HasForeignKey(s => s.CoordenadorId);
        }

    }

}    

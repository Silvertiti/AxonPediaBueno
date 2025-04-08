using Microsoft.EntityFrameworkCore;
using AxonPediaBueno.Models; // si nécessaire pour vos entités

namespace AxonPediaBueno.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Etudiant> Etudiants { get; set; }
    }
}

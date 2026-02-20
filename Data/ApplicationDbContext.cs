using Microsoft.EntityFrameworkCore;
using SistemaPlanillaUCENM.Models;

namespace SistemaPlanillaUCENM.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Esto crea las tablas físicas en la Base de Datos
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
    }
}
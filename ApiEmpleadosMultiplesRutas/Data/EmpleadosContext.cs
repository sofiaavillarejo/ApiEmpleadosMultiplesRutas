using NugetApiModelsSVR;
using Microsoft.EntityFrameworkCore;

namespace ApiEmpleadosMultiplesRutas.Data
{
    public class EmpleadosContext: DbContext
    {
        public EmpleadosContext(DbContextOptions<EmpleadosContext> options): base(options) { }
        public DbSet<Empleado> Empleados { get; set; }
    }
}

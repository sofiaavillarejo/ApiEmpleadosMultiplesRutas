using ApiEmpleadosMultiplesRutas.Data;
using NugetApiModelsSVR;
using Microsoft.EntityFrameworkCore;

namespace ApiEmpleadosMultiplesRutas.Repositories
{
    public class RepositoryEmpleados
    {
        private EmpleadosContext context;

        public RepositoryEmpleados(EmpleadosContext context)
        {
            this.context = context;
        }

        //todos los empleados
        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            return await this.context.Empleados.ToListAsync();
        }

        //buscar empleado
        public async Task<Empleado> FindEmpleadoAsync(int idEmpleado)
        {
            return await this.context.Empleados.FirstOrDefaultAsync(z => z.IdEmpleado == idEmpleado);
        }

        public async Task<List<Empleado>> GetEmpleadosOficiosAsync(string oficio)
        {
            var consulta = from datos in this.context.Empleados where oficio.Contains(datos.Oficio) select datos;
            return await consulta.ToListAsync();
        }

        public async Task<List<Empleado>> GetEmpleadosSalarioAsync(int salario, int idDepartamento)
        {
            return await this.context.Empleados.Where(z => z.Salario >= salario && z.IdDepartamento == idDepartamento).ToListAsync();
        }

        public async Task<List<string>> GetOficiosAsync()
        {
            var consulta = (from datos in this.context.Empleados select datos.Oficio).Distinct();
            return await consulta.ToListAsync();
        }

    }
}

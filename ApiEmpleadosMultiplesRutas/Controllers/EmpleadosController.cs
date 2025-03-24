using ApiEmpleadosMultiplesRutas.Data;
using ApiEmpleadosMultiplesRutas.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
//importacion del nuget creado para el model de empleado
using NugetApiModelsSVR;

namespace ApiEmpleadosMultiplesRutas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private RepositoryEmpleados repo;
        private EmpleadosContext context;

        public EmpleadosController(RepositoryEmpleados repo, EmpleadosContext context)
        {
            this.repo = repo;
            this.context = context;
        }

        [HttpGet]
        public async Task<List<Empleado>> GetEmpleados()
        {
            return await this.repo.GetEmpleadosAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> FindEmpleado(int id)
        {
            return await this.repo.FindEmpleadoAsync(id);
        }

        [HttpGet]
        [Route("[action]")] //aqui podemos poner el nombre de ruta que queramos
        public async Task<ActionResult<List<string>>> Oficios()
        {
            return await this.repo.GetOficiosAsync();
        }

        [HttpGet]
        [Route("[action]/{oficio}")]
        public async Task<ActionResult<List<Empleado>>> EmpleadosOficio(string oficio)
        {
            return await this.repo.GetEmpleadosOficiosAsync(oficio);
        }

        //SI TENEMOS MAS DE UN PARAMETRO DENTRO DE UN CONTROLLER, DEBEMOS MAPEAR LOS DATOS EN EL MISMO ORDEN Y CON EL MISMO NOMBRE QUE EN EL METODO
        [HttpGet]
        [Route("[action]/{salario}/{iddepartamento}")]
        public async Task<ActionResult<List<Empleado>>> EmpleadosSaalrioDepartamento(int salario, int iddepartamento)
        {
            return await this.repo.GetEmpleadosSalarioAsync(salario, iddepartamento);
        }
    }
}

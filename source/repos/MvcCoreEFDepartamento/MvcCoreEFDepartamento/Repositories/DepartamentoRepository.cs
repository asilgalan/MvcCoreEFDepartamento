using Microsoft.EntityFrameworkCore;
using MvcCoreEFDepartamento.Data;
using MvcCoreEFDepartamento.Models;

namespace MvcCoreEFDepartamento.Repositories
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly DepartamentoContext context;

        public DepartamentoRepository(DepartamentoContext context)
        {
            this.context = context;
        }

        public async Task<List<Departamento>> GetAllAsync()
        {
            var consulta = from datos in this.context.Departamentos
                          select datos;
            return await consulta.ToListAsync();
        }

        public async Task<Departamento?> GetByIdAsync(int id)
        {
            var consulta = from datos in this.context.Departamentos
                          where datos.idDepartamento == id
                          select datos;

            if (consulta.Count() == 0)
            {
                return null;
            }
            else
            {
                return await consulta.FirstAsync();
            }
        }

        public async Task CreateAsync(Departamento departamento)
        {
            this.context.Departamentos.Add(departamento);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Departamento departamento)
        {
            var consulta = from datos in this.context.Departamentos
                          where datos.idDepartamento == departamento.idDepartamento
                          select datos;

            if (consulta.Count() != 0)
            {
                var registro = await consulta.FirstAsync();
                registro.DNombre = departamento.DNombre;
                registro.Loc = departamento.Loc;
                await this.context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var consulta = from datos in this.context.Departamentos
                          where datos.idDepartamento == id
                          select datos;

            if (consulta.Count() != 0)
            {
                var departamento = await consulta.FirstAsync();
                this.context.Departamentos.Remove(departamento);
                await this.context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var consulta = from datos in this.context.Departamentos
                          where datos.idDepartamento == id
                          select datos;
            return consulta.Count() > 0;
        }
    }
}

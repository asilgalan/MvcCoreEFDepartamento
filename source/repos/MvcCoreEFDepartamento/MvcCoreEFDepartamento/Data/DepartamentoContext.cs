using Microsoft.EntityFrameworkCore;
using MvcCoreEFDepartamento.Models;

namespace MvcCoreEFDepartamento.Data
{
    public class DepartamentoContext : DbContext
    {
        public DepartamentoContext(DbContextOptions<DepartamentoContext> options)
            : base(options)
        {
        }

        public DbSet<Departamento> Departamentos { get; set; }
    }
}

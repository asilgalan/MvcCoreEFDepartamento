using MvcCoreEFDepartamento.Models;

namespace MvcCoreEFDepartamento.Repositories
{
    public interface IDepartamentoRepository
    {
        Task<List<Departamento>> GetAllAsync();
        Task<Departamento?> GetByIdAsync(int id);
        Task CreateAsync(Departamento departamento);
        Task UpdateAsync(Departamento departamento);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}

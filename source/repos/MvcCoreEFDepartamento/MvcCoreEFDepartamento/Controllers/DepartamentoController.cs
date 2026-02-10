using Microsoft.AspNetCore.Mvc;
using MvcCoreEFDepartamento.Models;
using MvcCoreEFDepartamento.Repositories;

namespace MvcCoreEFDepartamento.Controllers
{
    public class DepartamentoController : Controller
    {
        private IDepartamentoRepository repo;

        public DepartamentoController(IDepartamentoRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            List<Departamento> departamentos = await this.repo.GetAllAsync();
            return View(departamentos);
        }

        public async Task<IActionResult> Details(int id)
        {
            Departamento departamento = await this.repo.GetByIdAsync(id);
            return View(departamento);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Departamento departamento)
        { 
                await this.repo.CreateAsync(departamento);

                return RedirectToAction("Index");
            
           
        }

        public async Task<IActionResult> Edit(int id)
        {
            Departamento departamento = await this.repo.GetByIdAsync(id);
            return View(departamento);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Departamento departamento)
        {
        
                await this.repo.UpdateAsync(departamento);
                return RedirectToAction("Index");
          
        }

    
        public async Task<IActionResult> Delete(int id)
        {
            await this.repo.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}

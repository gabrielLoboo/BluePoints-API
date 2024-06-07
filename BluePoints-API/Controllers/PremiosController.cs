using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BluePoints_API.Data;
using BluePoints_API.Models;

namespace BluePoints_API.Controllers
{
    public class PremiosController : Controller
    {
        private readonly DataContext _context;

        public PremiosController(DataContext context)
        {
            _context = context;
        }

        // GET: Premios
        public async Task<IActionResult> Index()
        {
            var premios = _context.Premios.Include(p => p.Categoria);
            return View(await premios.ToListAsync());
        }

        // GET: Premios/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Nome");
            return View();
        }

        // POST: Premios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Pontos,CategoriaId")] Premio premio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(premio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Nome", premio.CategoriaId);
            return View(premio);
        }

        // GET: Premios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var premio = await _context.Premios.FindAsync(id);
            if (premio == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Nome", premio.CategoriaId);
            return View(premio);
        }

        // POST: Premios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Pontos,CategoriaId")] Premio premio)
        {
            if (id != premio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(premio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PremioExists(premio.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Nome", premio.CategoriaId);
            return View(premio);
        }

        // GET: Premios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var premio = await _context.Premios
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (premio == null)
            {
                return NotFound();
            }

            return View(premio);
        }

        // POST: Premios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var premio = await _context.Premios.FindAsync(id);
            if (premio != null)
            {
                _context.Premios.Remove(premio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PremioExists(int id)
        {
            return _context.Premios.Any(e => e.Id == id);
        }
    }
}

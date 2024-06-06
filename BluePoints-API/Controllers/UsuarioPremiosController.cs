using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BluePoints_API.Data;
using BluePoints_API.Models;

namespace BluePoints_API.Controllers
{
    public class UsuarioPremiosController : Controller
    {
        private readonly DataContext _context;

        public UsuarioPremiosController(DataContext context)
        {
            _context = context;
        }

        // GET: UsuarioPremios
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.UsuarioPremios.Include(u => u.Premio).Include(u => u.Usuario);
            return View(await dataContext.ToListAsync());
        }

        // GET: UsuarioPremios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioPremio = await _context.UsuarioPremios
                .Include(u => u.Premio)
                .Include(u => u.Usuario)
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (usuarioPremio == null)
            {
                return NotFound();
            }

            return View(usuarioPremio);
        }

        // GET: UsuarioPremios/Create
        public IActionResult Create()
        {
            ViewData["PremioId"] = new SelectList(_context.Premios, "Id", "Descricao");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email");
            return View();
        }


        // POST: UsuarioPremios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,PremioId,DataResgate")] UsuarioPremio usuarioPremio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarioPremio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PremioId"] = new SelectList(_context.Premios, "Id", "Descricao", usuarioPremio.PremioId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", usuarioPremio.UsuarioId);
            return View(usuarioPremio);
        }


        // GET: UsuarioPremios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioPremio = await _context.UsuarioPremios.FindAsync(id);
            if (usuarioPremio == null)
            {
                return NotFound();
            }
            ViewData["PremioId"] = new SelectList(_context.Premios, "Id", "Descricao", usuarioPremio.PremioId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", usuarioPremio.UsuarioId);
            return View(usuarioPremio);
        }


        // POST: UsuarioPremios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioId,PremioId,DataResgate")] UsuarioPremio usuarioPremio)
        {
            if (id != usuarioPremio.UsuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioPremio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioPremioExists(usuarioPremio.UsuarioId))
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
            ViewData["PremioId"] = new SelectList(_context.Premios, "Id", "Descricao", usuarioPremio.PremioId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", usuarioPremio.UsuarioId);
            return View(usuarioPremio);
        }

        // GET: UsuarioPremios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioPremio = await _context.UsuarioPremios
                .Include(u => u.Premio)
                .Include(u => u.Usuario)
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (usuarioPremio == null)
            {
                return NotFound();
            }

            return View(usuarioPremio);
        }

        // POST: UsuarioPremios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarioPremio = await _context.UsuarioPremios.FindAsync(id);
            if (usuarioPremio != null)
            {
                _context.UsuarioPremios.Remove(usuarioPremio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioPremioExists(int id)
        {
            return _context.UsuarioPremios.Any(e => e.UsuarioId == id);
        }
    }
}

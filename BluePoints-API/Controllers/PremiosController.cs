﻿using System;
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
            return View(await _context.Premios.ToListAsync());
        }

        // GET: Premios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var premio = await _context.Premios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (premio == null)
            {
                return NotFound();
            }

            return View(premio);
        }

        // GET: Premios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Premios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Pontos")] Premio premio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(premio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            return View(premio);
        }

        // POST: Premios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Pontos")] Premio premio)
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

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BodegaLucyCF.Models;

namespace BodegaLucyCF.Controllers
{
    public class PaquetesController : Controller
    {
        private readonly BdLucyContext _context;

        public PaquetesController(BdLucyContext context)
        {
            _context = context;
        }

        // GET: Paquetes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Paquetes.ToListAsync());
        }

        // GET: Paquetes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Paquetes == null)
            {
                return NotFound();
            }

            var paquete = await _context.Paquetes
                .FirstOrDefaultAsync(m => m.Codigo_Paquete == id);
            if (paquete == null)
            {
                return NotFound();
            }

            return View(paquete);
        }

        // GET: Paquetes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Paquetes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo_Paquete,Nombre_Paquete,Cantidad_Por_Paquete,Contenido_Por_Unidad,Descripcion_Paquete")] Paquete paquete)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paquete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paquete);
        }

        // GET: Paquetes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Paquetes == null)
            {
                return NotFound();
            }

            var paquete = await _context.Paquetes.FindAsync(id);
            if (paquete == null)
            {
                return NotFound();
            }
            return View(paquete);
        }

        // POST: Paquetes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo_Paquete,Nombre_Paquete,Cantidad_Por_Paquete,Contenido_Por_Unidad,Descripcion_Paquete")] Paquete paquete)
        {
            if (id != paquete.Codigo_Paquete)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paquete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaqueteExists(paquete.Codigo_Paquete))
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
            return View(paquete);
        }

        // GET: Paquetes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Paquetes == null)
            {
                return NotFound();
            }

            var paquete = await _context.Paquetes
                .FirstOrDefaultAsync(m => m.Codigo_Paquete == id);
            if (paquete == null)
            {
                return NotFound();
            }

            return View(paquete);
        }

        // POST: Paquetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Paquetes == null)
            {
                return Problem("Entity set 'BdLucyContext.Paquetes'  is null.");
            }
            var paquete = await _context.Paquetes.FindAsync(id);
            if (paquete != null)
            {
                _context.Paquetes.Remove(paquete);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaqueteExists(int id)
        {
          return _context.Paquetes.Any(e => e.Codigo_Paquete == id);
        }
    }
}

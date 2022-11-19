using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BodegaLucyCF.Models;
using BodegaLucyCF.Models.ViewModels;

namespace BodegaLucyCF.Controllers
{
    public class ComprasController : Controller
    {
        private readonly BdLucyContext _context;

        public ComprasController(BdLucyContext context)
        {
            _context = context;
        }

        //---------------------------- NUEVO -------------------------------------
        [HttpPost]
        public IActionResult Index([FromBody] CompraVM oCompraVM)
        {
            Compra oCompra = oCompraVM.oCompra;


            //oCompra.Detalle_Compras = oCompraVM.oDetalle_Compras;

            _context.Compras.Add(oCompra);
            _context.SaveChanges();



            return Json(new { respuesta = true });
        }
        //---------------------------- NUEVO -------------------------------------



        // GET: Compras
        public async Task<IActionResult> Index()
        {
            var bdLucyContext = _context.Compras.Include(c => c.distribuidor).Include(c => c.usuario);
            return View(await bdLucyContext.ToListAsync());
        }

        // GET: Compras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Compras == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras
                .Include(c => c.distribuidor)
                .Include(c => c.usuario)
                .FirstOrDefaultAsync(m => m.Codigo_Compra == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // GET: Compras/Create
        public IActionResult Create()
        {
            ViewData["Codigo_Distribuidor"] = new SelectList(_context.Distribuidores, "Codigo_Distribuidor", "Codigo_Distribuidor");
            ViewData["Codigo_Usuario"] = new SelectList(_context.Usuarios, "Codigo_Usuario", "Codigo_Usuario");
            return View();
        }

        // POST: Compras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo_Compra,Fecha_Compra,Tipo_Comprobante,Serie_Comprobante_Compra,Numero_Comprobante_Compra,Codigo_Usuario,Codigo_Distribuidor,IGV_Compra,Subtotal_Compra,Total_Compra")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Codigo_Distribuidor"] = new SelectList(_context.Distribuidores, "Codigo_Distribuidor", "Codigo_Distribuidor", compra.Codigo_Distribuidor);
            ViewData["Codigo_Usuario"] = new SelectList(_context.Usuarios, "Codigo_Usuario", "Codigo_Usuario", compra.Codigo_Usuario);
            return View(compra);
        }

        // GET: Compras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Compras == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }
            ViewData["Codigo_Distribuidor"] = new SelectList(_context.Distribuidores, "Codigo_Distribuidor", "Razon_Social_Distribuidor", compra.Codigo_Distribuidor);
            ViewData["Codigo_Usuario"] = new SelectList(_context.Usuarios, "Codigo_Usuario", "User_Usuario", compra.Codigo_Usuario);
            return View(compra);
        }

        // POST: Compras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo_Compra,Fecha_Compra,Tipo_Comprobante,Serie_Comprobante_Compra,Numero_Comprobante_Compra,Codigo_Usuario,Codigo_Distribuidor,IGV_Compra,Subtotal_Compra,Total_Compra")] Compra compra)
        {
            if (id != compra.Codigo_Compra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraExists(compra.Codigo_Compra))
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
            ViewData["Codigo_Distribuidor"] = new SelectList(_context.Distribuidores, "Codigo_Distribuidor", "Codigo_Distribuidor", compra.Codigo_Distribuidor);
            ViewData["Codigo_Usuario"] = new SelectList(_context.Usuarios, "Codigo_Usuario", "Codigo_Usuario", compra.Codigo_Usuario);
            return View(compra);
        }

        // GET: Compras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Compras == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras
                .Include(c => c.distribuidor)
                .Include(c => c.usuario)
                .FirstOrDefaultAsync(m => m.Codigo_Compra == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Compras == null)
            {
                return Problem("Entity set 'BdLucyContext.Compras'  is null.");
            }
            var compra = await _context.Compras.FindAsync(id);
            if (compra != null)
            {
                _context.Compras.Remove(compra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraExists(int id)
        {
          return _context.Compras.Any(e => e.Codigo_Compra == id);
        }
    }
}

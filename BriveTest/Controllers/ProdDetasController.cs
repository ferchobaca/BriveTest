using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BriveTest.Models;

namespace BriveTest.Controllers
{
    public class ProdDetasController : Controller
    {
        private readonly BriveContext _context;

        public ProdDetasController(BriveContext context)
        {
            _context = context;
        }

        // GET: ProdDetas
        public async Task<IActionResult> Index(string searchString)
        {
            var result = from x in  _context.ProdDeta select x;
            //var briveContext = _context.ProdDeta.Include(p => p.CodBarrNavigation).Include(p => p.IdSucursalNavigation);
            ViewData["CurrentFilter"] = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                result = result.Where(x => x.Nombre.Contains(searchString));
                
            }

            return View(await result.ToListAsync());
            //return View(await briveContext.ToListAsync());
        }

        // GET: ProdDetas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodDeta = await _context.ProdDeta
                .Include(p => p.CodBarrNavigation)
                .Include(p => p.IdSucursalNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalle == id);
            if (prodDeta == null)
            {
                return NotFound();
            }

            return View(prodDeta);
        }

        // GET: ProdDetas/Create
        public IActionResult Create()
        {
            ViewData["CodBarr"] = new SelectList(_context.Producto, "CodBarr", "Nombre");
            ViewData["IdSucursal"] = new SelectList(_context.Sucursal, "IdSucursal", "Nombre");
            return View();
        }

        // POST: ProdDetas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDetalle,CodBarr,Nombre,Cantidad,PrecUnit,IdSucursal")] ProdDeta prodDeta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prodDeta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodBarr"] = new SelectList(_context.Producto, "CodBarr", "Nombre", prodDeta.CodBarr);
            ViewData["IdSucursal"] = new SelectList(_context.Sucursal, "IdSucursal", "Nombre", prodDeta.IdSucursal);
            return View(prodDeta);
        }

        // GET: ProdDetas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodDeta = await _context.ProdDeta.FindAsync(id);
            if (prodDeta == null)
            {
                return NotFound();
            }
            ViewData["CodBarr"] = new SelectList(_context.Producto, "CodBarr", "Nombre", prodDeta.CodBarr);
            ViewData["IdSucursal"] = new SelectList(_context.Sucursal, "IdSucursal", "Nombre", prodDeta.IdSucursal);
            return View(prodDeta);
        }

        // POST: ProdDetas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDetalle,CodBarr,Nombre,Cantidad,PrecUnit,IdSucursal")] ProdDeta prodDeta)
        {
            if (id != prodDeta.IdDetalle)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prodDeta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdDetaExists(prodDeta.IdDetalle))
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
            ViewData["CodBarr"] = new SelectList(_context.Producto, "CodBarr", "Nombre", prodDeta.CodBarr);
            ViewData["IdSucursal"] = new SelectList(_context.Sucursal, "IdSucursal", "Nombre", prodDeta.IdSucursal);
            return View(prodDeta);
        }

        // GET: ProdDetas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodDeta = await _context.ProdDeta
                .Include(p => p.CodBarrNavigation)
                .Include(p => p.IdSucursalNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalle == id);
            if (prodDeta == null)
            {
                return NotFound();
            }

            return View(prodDeta);
        }

        // POST: ProdDetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prodDeta = await _context.ProdDeta.FindAsync(id);
            _context.ProdDeta.Remove(prodDeta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdDetaExists(int id)
        {
            return _context.ProdDeta.Any(e => e.IdDetalle == id);
        }
    }
}

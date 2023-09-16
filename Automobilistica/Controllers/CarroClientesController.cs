using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Automobilistica.Models;

namespace Automobilistica.Controllers
{
    public class CarroClientesController : Controller
    {
        private readonly AutomobilisticaContext _context;

        public CarroClientesController(AutomobilisticaContext context)
        {
            _context = context;
        }

        // GET: CarroClientes
        public async Task<IActionResult> Index()
        {
            var uLTRACARContext = _context.CarroCliente.Include(c => c.CccdcarroNavigation).Include(c => c.CccdclienteNavigation);
            return View(await uLTRACARContext.ToListAsync());
        }

        // GET: CarroClientes/Details/5
        public async Task<IActionResult> Details(int? idCar, int? idClie)
        {
            if (idCar == null || _context.CarroCliente == null || idClie == null)
            {
                return NotFound();
            }

            var carroCliente = await _context.CarroCliente
                .Include(c => c.CccdcarroNavigation)
                .Include(c => c.CccdclienteNavigation)
                .FirstOrDefaultAsync(m => m.Cccdcarro == idCar && m.Cccdcliente == idClie);
            if (carroCliente == null)
            {
                return NotFound();
            }

            return View(carroCliente);
        }

        // GET: CarroClientes/Create
        public IActionResult Create()
        {
            ViewData["Cccdcarro"] = new SelectList(_context.Carros, "Crcdcarro", "Crcdcarro");
            ViewData["Cccdcliente"] = new SelectList(_context.Cliente, "Clcdcliente", "Clcdcliente");
            return View();
        }

        // POST: CarroClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cccdcarro,Cccdcliente,Ccdtcadastro,Ccstatus")] CarroCliente carroCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carroCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cccdcarro"] = new SelectList(_context.Carros, "Crcdcarro", "Crcdcarro", carroCliente.Cccdcarro);
            ViewData["Cccdcliente"] = new SelectList(_context.Cliente, "Clcdcliente", "Clcdcliente", carroCliente.Cccdcliente);
            return View(carroCliente);
        }

        // GET: CarroClientes/Edit/5&5
        public async Task<IActionResult> Edit(int? idCar, int? idClie)
        {
            if (idCar == null || _context.CarroCliente == null || idClie == null)
            {
                return NotFound();
            }

            var carroCliente = await _context.CarroCliente.AsNoTracking().Where(e => e.Cccdcarro == idCar && e.Cccdcliente == idClie).FirstOrDefaultAsync();
            if (carroCliente == null)
            {
                return NotFound();
            }
            ViewData["Cccdcarro"] = new SelectList(_context.Carros, "Crcdcarro", "Crcdcarro", carroCliente.Cccdcarro);
            ViewData["Cccdcliente"] = new SelectList(_context.Cliente, "Clcdcliente", "Clcdcliente", carroCliente.Cccdcliente);
            return View(carroCliente);
        }

        // POST: CarroClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cccdcarro,Cccdcliente,Ccdtcadastro,Ccstatus")] CarroCliente carroCliente)
        {
            if (id != carroCliente.Cccdcarro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carroCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarroClienteExists(carroCliente.Cccdcarro))
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
            ViewData["Cccdcarro"] = new SelectList(_context.Carros, "Crcdcarro", "Crcdcarro", carroCliente.Cccdcarro);
            ViewData["Cccdcliente"] = new SelectList(_context.Cliente, "Clcdcliente", "Clcdcliente", carroCliente.Cccdcliente);
            return View(carroCliente);
        }

        // GET: CarroClientes/Delete/5
        public async Task<IActionResult> Delete(int? idCar, int? idClie)
        {
            if (idCar == null || _context.CarroCliente == null || idClie == null)
            {
                return NotFound();
            }

            var carroCliente = await _context.CarroCliente
                .Include(c => c.CccdcarroNavigation)
                .Include(c => c.CccdclienteNavigation)
                .FirstOrDefaultAsync(m => m.Cccdcarro == idCar && m.Cccdcliente == idClie);
            if (carroCliente == null)
            {
                return NotFound();
            }

            return View(carroCliente);
        }

        // POST: CarroClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int idCar, int idClie)
        {
            if (_context.CarroCliente == null)
            {
                return Problem("Entity set 'ULTRACARContext.CarroCliente'  is null.");
            }
            var carroCliente = await _context.CarroCliente.AsNoTracking().Where(e => e.Cccdcarro == idCar && e.Cccdcliente == idClie).FirstOrDefaultAsync();
            if (carroCliente != null)
            {
                _context.CarroCliente.Remove(carroCliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarroClienteExists(int id)
        {
          return (_context.CarroCliente?.Any(e => e.Cccdcarro == id)).GetValueOrDefault();
        }
    }
}

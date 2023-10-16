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
    public class EnderecosController : Controller
    {
        private readonly AutomobilisticaContext _context;

        public EnderecosController(AutomobilisticaContext context)
        {
            _context = context;
        }

        // GET: Enderecos
        public async Task<IActionResult> Index()
        {
              return _context.Enderecos != null ? 
                          View(await _context.Enderecos.ToListAsync()) :
                          Problem("Entity set 'automobilisticaContext.Enderecos'  is null.");
        }

        // GET: Enderecos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Enderecos == null)
            {
                return NotFound();
            }

            var enderecos = await _context.Enderecos
                .FirstOrDefaultAsync(m => m.Edcdendereco == id);
            if (enderecos == null)
            {
                return NotFound();
            }

            return View(enderecos);
        }

        // GET: Enderecos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enderecos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Edcdendereco,Edlogradouro,Ednumero,Edbairro,Edcidade,Eduf,Edcep,Edcomplemento,Edtipoendereco")] Enderecos enderecos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enderecos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enderecos);
        }

        // GET: Enderecos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Enderecos == null)
            {
                return NotFound();
            }

            var enderecos = await _context.Enderecos.FindAsync(id);
            if (enderecos == null)
            {
                return NotFound();
            }
            return View(enderecos);
        }

        // POST: Enderecos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Edcdendereco,Edlogradouro,Ednumero,Edbairro,Edcidade,Eduf,Edcep,Edcomplemento,Edtipoendereco")] Enderecos enderecos)
        {
            if (id != enderecos.Edcdendereco)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enderecos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnderecosExists(enderecos.Edcdendereco))
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
            return View(enderecos);
        }

        // GET: Enderecos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Enderecos == null)
            {
                return NotFound();
            }

            var enderecos = await _context.Enderecos
                .FirstOrDefaultAsync(m => m.Edcdendereco == id);
            if (enderecos == null)
            {
                return NotFound();
            }

            return View(enderecos);
        }

        // POST: Enderecos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Enderecos == null)
            {
                return Problem("Entity set 'automobilisticaContext.Enderecos'  is null.");
            }
            var enderecos = await _context.Enderecos.FindAsync(id);
            if (enderecos != null)
            {
                _context.Enderecos.Remove(enderecos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnderecosExists(int id)
        {
          return (_context.Enderecos?.Any(e => e.Edcdendereco == id)).GetValueOrDefault();
        }
    }
}

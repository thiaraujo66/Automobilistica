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
    public class ServicosController : Controller
    {
        private readonly AutomobilisticaContext _context;

        public ServicosController(AutomobilisticaContext context) 
        {
            _context = context;
        }

        // GET: Servicos
        public async Task<IActionResult> Index()
        {
            return _context.Servicos != null ?
                        View(await _context.Servicos.ToListAsync()) :
                        Problem("Entity set 'automobilisticaContext.Servicos'  is null.");
        }

        // GET: Servicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Servicos == null)
            {
                return NotFound();
            }

            var servicos = await _context.Servicos
                .FirstOrDefaultAsync(m => m.Srcdservico == id);
            if (servicos == null)
            {
                return NotFound();
            }

            return View(servicos);
        }

        // GET: Servicos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Servicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SRCDSERVICO,SRNOME,SRDESCRICAO,SRVALOR,SRSTATUS,SRDTCADASTRO")] Servicos servicos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(servicos);
        }

        // GET: Servicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Servicos == null)
            {
                return NotFound();
            }

            var servicos = await _context.Servicos.FindAsync(id);
            if (servicos == null)
            {
                return NotFound();
            }
            return View(servicos);
        }

        // POST: Servicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SRCDSERVICO,SRNOME,SRDESCRICAO,SRVALOR,SRSTATUS,SRDTCADASTRO")] Servicos servicos)
        {
            if (id != servicos.Srcdservico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicosExists(servicos.Srcdservico))
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
            return View(servicos);
        }

        // GET: Servicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Servicos == null)
            {
                return NotFound();
            }

            var servicos = await _context.Servicos
                .FirstOrDefaultAsync(m => m.Srcdservico == id);
            if (servicos == null)
            {
                return NotFound();
            }

            return View(servicos);
        }

        // POST: Servicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Servicos == null)
            {
                return Problem("Entity set 'automobilisticaContext.Servicos'  is null.");
            }
            var servicos = await _context.Servicos.FindAsync(id);
            if (servicos != null)
            {
                _context.Servicos.Remove(servicos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicosExists(int id)
        {
            return (_context.Servicos?.Any(e => e.Srcdservico == id)).GetValueOrDefault();
        }
    }
}

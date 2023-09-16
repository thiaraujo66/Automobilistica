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
    public class ContratosController : Controller
    {
        private readonly AutomobilisticaContext _context;

        public ContratosController(AutomobilisticaContext context)
        {
            _context = context;
        }

        // GET: Contratos
        public async Task<IActionResult> Index()
        {
            var uLTRACARContext = _context.Contrato.Include(c => c.CtcdprocessoNavigation).Include(c => c.CtcdpropostaNavigation);
            return View(await uLTRACARContext.ToListAsync());
        }

        // GET: Contratos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contrato == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contrato
                .Include(c => c.CtcdprocessoNavigation)
                .Include(c => c.CtcdpropostaNavigation)
                .FirstOrDefaultAsync(m => m.Ctcdcontrato == id);
            if (contrato == null)
            {
                return NotFound();
            }

            return View(contrato);
        }

        // GET: Contratos/Create
        public IActionResult Create()
        {
            ViewData["Ctcdprocesso"] = new SelectList(_context.Processos, "Pccdprocesso", "Pcdescricao");
            ViewData["Ctcdproposta"] = new SelectList(_context.Proposta, "Ppcdproposta", "Ppcdproposta");
            return View();
        }

        // POST: Contratos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ctcdcontrato,Ctcdproposta,Ctdtcadastro,Ctdtini,Ctdtfinal,Cttotalhoras,Ctcdprocesso")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contrato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Ctcdprocesso"] = new SelectList(_context.Processos, "Pccdprocesso", "Pcdescricao", contrato.Ctcdprocesso);
            ViewData["Ctcdproposta"] = new SelectList(_context.Proposta, "Ppcdproposta", "Ppcdproposta", contrato.Ctcdproposta);
            return View(contrato);
        }

        // GET: Contratos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contrato == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contrato.FindAsync(id);
            if (contrato == null)
            {
                return NotFound();
            }
            ViewData["Ctcdprocesso"] = new SelectList(_context.Processos, "Pccdprocesso", "Pcdescricao", contrato.Ctcdprocesso);
            ViewData["Ctcdproposta"] = new SelectList(_context.Proposta, "Ppcdproposta", "Ppcdproposta", contrato.Ctcdproposta);
            return View(contrato);
        }

        // POST: Contratos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ctcdcontrato,Ctcdproposta,Ctdtcadastro,Ctdtini,Ctdtfinal,Cttotalhoras,Ctcdprocesso")] Contrato contrato)
        {
            if (id != contrato.Ctcdcontrato)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contrato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratoExists(contrato.Ctcdcontrato))
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
            ViewData["Ctcdprocesso"] = new SelectList(_context.Processos, "Pccdprocesso", "Pcdescricao", contrato.Ctcdprocesso);
            ViewData["Ctcdproposta"] = new SelectList(_context.Proposta, "Ppcdproposta", "Ppcdproposta", contrato.Ctcdproposta);
            return View(contrato);
        }

        // GET: Contratos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contrato == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contrato
                .Include(c => c.CtcdprocessoNavigation)
                .Include(c => c.CtcdpropostaNavigation)
                .FirstOrDefaultAsync(m => m.Ctcdcontrato == id);
            if (contrato == null)
            {
                return NotFound();
            }

            return View(contrato);
        }

        // POST: Contratos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contrato == null)
            {
                return Problem("Entity set 'ULTRACARContext.Contrato'  is null.");
            }
            var contrato = await _context.Contrato.FindAsync(id);
            if (contrato != null)
            {
                _context.Contrato.Remove(contrato);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratoExists(int id)
        {
          return (_context.Contrato?.Any(e => e.Ctcdcontrato == id)).GetValueOrDefault();
        }
    }
}

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
    public class PropostaServicosController : Controller
    {
        private readonly AutomobilisticaContext _context;

        public PropostaServicosController(AutomobilisticaContext context)
        {
            _context = context;
        }

        // GET: PropostaServicos
        public async Task<IActionResult> Index()
        {
            var uLTRACARContext = _context.PropostaServico.Include(p => p.PrcdpropostaNavigation).Include(p => p.PrcdservicoNavigation);
            return View(await uLTRACARContext.ToListAsync());
        }

        // GET: PropostaServicos/Details/5
        public async Task<IActionResult> Details(int? idProp, int? idServ)
        {
            if (idProp == null || _context.PropostaServico == null || idServ == null)
            {
                return NotFound();
            }

            var propostaServico = await _context.PropostaServico
                .Include(p => p.PrcdpropostaNavigation)
                .Include(p => p.PrcdservicoNavigation)
                .FirstOrDefaultAsync(m => m.Prcdproposta == idProp && m.Prcdservico == idServ);
            if (propostaServico == null)
            {
                return NotFound();
            }

            return View(propostaServico);
        }

        // GET: PropostaServicos/Create
        public IActionResult Create()
        {
            ViewData["Prcdproposta"] = new SelectList(_context.Proposta, "Ppcdproposta", "Ppcdproposta");
            ViewData["Prcdservico"] = new SelectList(_context.Servicos, "Srcdservico", "Srcdservico");
            return View();
        }

        // POST: PropostaServicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Prcdproposta,Prcdservico,Prvalor")] PropostaServico propostaServico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(propostaServico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Prcdproposta"] = new SelectList(_context.Proposta, "Ppcdproposta", "Ppcdproposta", propostaServico.Prcdproposta);
            ViewData["Prcdservico"] = new SelectList(_context.Servicos, "Srcdservico", "Srcdservico", propostaServico.Prcdservico);
            return View(propostaServico);
        }

        // GET: PropostaServicos/Edit/5
        public async Task<IActionResult> Edit(int? idProp, int? idServ)
        {
            if (idProp == null || _context.PropostaServico == null || idServ == null)
            {
                return NotFound();
            }

            var propostaServico = await _context.PropostaServico.AsNoTracking().Where(e => e.Prcdproposta == idProp && e.Prcdservico == idServ).FirstOrDefaultAsync();
            if (propostaServico == null)
            {
                return NotFound();
            }
            ViewData["Prcdproposta"] = new SelectList(_context.Proposta, "Ppcdproposta", "Ppcdproposta", propostaServico.Prcdproposta);
            ViewData["Prcdservico"] = new SelectList(_context.Servicos, "Srcdservico", "Srcdservico", propostaServico.Prcdservico);
            return View(propostaServico);
        }

        // POST: PropostaServicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Prcdproposta,Prcdservico,Prvalor")] PropostaServico propostaServico)
        {
            if (id != propostaServico.Prcdproposta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propostaServico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropostaServicoExists(propostaServico.Prcdproposta))
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
            ViewData["Prcdproposta"] = new SelectList(_context.Proposta, "Ppcdproposta", "Ppcdproposta", propostaServico.Prcdproposta);
            ViewData["Prcdservico"] = new SelectList(_context.Servicos, "Srcdservico", "Srcdservico", propostaServico.Prcdservico);
            return View(propostaServico);
        }

        // GET: PropostaServicos/Delete/5
        public async Task<IActionResult> Delete(int? idProp, int? idServ)
        {
            if (idProp == null || _context.PropostaServico == null || idServ == null)
            {
                return NotFound();
            }

            var propostaServico = await _context.PropostaServico
                .Include(p => p.PrcdpropostaNavigation)
                .Include(p => p.PrcdservicoNavigation)
                .FirstOrDefaultAsync(m => m.Prcdproposta == idProp && m.Prcdservico == idServ);
            if (propostaServico == null)
            {
                return NotFound();
            }

            return View(propostaServico);
        }

        // POST: PropostaServicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int idProp, int idServ)
        {
            if (_context.PropostaServico == null)
            {
                return Problem("Entity set 'ULTRACARContext.PropostaServico'  is null.");
            }
            var propostaServico = await _context.PropostaServico.AsNoTracking().Where(e => e.Prcdproposta == idProp && e.Prcdservico == idServ).FirstOrDefaultAsync();
            if (propostaServico != null)
            {
                _context.PropostaServico.Remove(propostaServico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropostaServicoExists(int id)
        {
          return (_context.PropostaServico?.Any(e => e.Prcdproposta == id)).GetValueOrDefault();
        }
    }
}

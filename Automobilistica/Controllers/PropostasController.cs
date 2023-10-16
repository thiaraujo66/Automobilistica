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
    public class PropostasController : Controller
    {
        private readonly AutomobilisticaContext _context;

        public PropostasController(AutomobilisticaContext context)
        {
            _context = context;
        }

        // GET: Propostas
        public async Task<IActionResult> Index()
        {
            var automobilisticaContext = _context.Proposta.Include(p => p.PpcdcarroNavigation).Include(p => p.PpcdclienteNavigation).Include(p => p.PpcdfuncionarioNavigation);
            return View(await automobilisticaContext.ToListAsync());
        }

        // GET: Propostas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Proposta == null)
            {
                return NotFound();
            }

            var proposta = await _context.Proposta
                .Include(p => p.PpcdcarroNavigation)
                .Include(p => p.PpcdclienteNavigation)
                .Include(p => p.PpcdfuncionarioNavigation)
                .FirstOrDefaultAsync(m => m.Ppcdproposta == id);
            if (proposta == null)
            {
                return NotFound();
            }

            return View(proposta);
        }

        // GET: Propostas/Create
        public IActionResult Create()
        {
            ViewData["Ppcdcarro"] = new SelectList(_context.Carros, "Crcdcarro", "Crfabricante");
            ViewData["Ppcdcliente"] = new SelectList(_context.Cliente, "Clcdcliente", "Clcdcliente");
            ViewData["Ppcdfuncionario"] = new SelectList(_context.Funcionarios, "Fncdfunc", "Fncdfunc");
            return View();
        }

        // POST: Propostas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ppcdproposta,Ppcdcliente,Ppcdcarro,Ppcdfuncionario,Ppvalor,Ppdtcadastro,Ppstatus")] Proposta proposta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proposta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Ppcdcarro"] = new SelectList(_context.Carros, "Crcdcarro", "Crfabricante", proposta.Ppcdcarro);
            ViewData["Ppcdcliente"] = new SelectList(_context.Cliente, "Clcdcliente", "Clcdcliente", proposta.Ppcdcliente);
            ViewData["Ppcdfuncionario"] = new SelectList(_context.Funcionarios, "Fncdfunc", "Fncdfunc", proposta.Ppcdfuncionario);
            return View(proposta);
        }

        // GET: Propostas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Proposta == null)
            {
                return NotFound();
            }

            var proposta = await _context.Proposta.FindAsync(id);
            if (proposta == null)
            {
                return NotFound();
            }
            ViewData["Ppcdcarro"] = new SelectList(_context.Carros, "Crcdcarro", "Crfabricante", proposta.Ppcdcarro);
            ViewData["Ppcdcliente"] = new SelectList(_context.Cliente, "Clcdcliente", "Clcdcliente", proposta.Ppcdcliente);
            ViewData["Ppcdfuncionario"] = new SelectList(_context.Funcionarios, "Fncdfunc", "Fncdfunc", proposta.Ppcdfuncionario);
            return View(proposta);
        }

        // POST: Propostas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ppcdproposta,Ppcdcliente,Ppcdcarro,Ppcdfuncionario,Ppvalor,Ppdtcadastro,Ppstatus")] Proposta proposta)
        {
            if (id != proposta.Ppcdproposta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proposta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropostaExists(proposta.Ppcdproposta))
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
            ViewData["Ppcdcarro"] = new SelectList(_context.Carros, "Crcdcarro", "Crfabricante", proposta.Ppcdcarro);
            ViewData["Ppcdcliente"] = new SelectList(_context.Cliente, "Clcdcliente", "Clcdcliente", proposta.Ppcdcliente);
            ViewData["Ppcdfuncionario"] = new SelectList(_context.Funcionarios, "Fncdfunc", "Fncdfunc", proposta.Ppcdfuncionario);
            return View(proposta);
        }

        // GET: Propostas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Proposta == null)
            {
                return NotFound();
            }

            var proposta = await _context.Proposta
                .Include(p => p.PpcdcarroNavigation)
                .Include(p => p.PpcdclienteNavigation)
                .Include(p => p.PpcdfuncionarioNavigation)
                .FirstOrDefaultAsync(m => m.Ppcdproposta == id);
            if (proposta == null)
            {
                return NotFound();
            }

            return View(proposta);
        }

        // POST: Propostas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Proposta == null)
            {
                return Problem("Entity set 'automobilisticaContext.Proposta'  is null.");
            }
            var proposta = await _context.Proposta.FindAsync(id);
            if (proposta != null)
            {
                _context.Proposta.Remove(proposta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropostaExists(int id)
        {
          return (_context.Proposta?.Any(e => e.Ppcdproposta == id)).GetValueOrDefault();
        }
    }
}

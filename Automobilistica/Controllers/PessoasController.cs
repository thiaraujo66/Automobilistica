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
    public class PessoasController : Controller
    {
        private readonly AutomobilisticaContext _context;

        public PessoasController(AutomobilisticaContext context)
        {
            _context = context;
        }

        // GET: Pessoas
        public async Task<IActionResult> Index()
        {
            var automobilisticaContext = _context.Pessoas.Include(p => p.PscdenderecoNavigation);
            return View(await automobilisticaContext.ToListAsync());
        }

        // GET: Pessoas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pessoas == null)
            {
                return NotFound();
            }

            var pessoas = await _context.Pessoas
                .Include(p => p.PscdenderecoNavigation)
                .FirstOrDefaultAsync(m => m.Pscdpessoa == id);
            if (pessoas == null)
            {
                return NotFound();
            }

            return View(pessoas);
        }

        // GET: Pessoas/Create
        public IActionResult Create()
        {
            ViewData["Pscdendereco"] = new SelectList(_context.Enderecos, "Edcdendereco", "Edbairro");
            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pscdpessoa,Pscdendereco,Psnome,Psemail,Pscgc,Psdtnascimento,Psdtcadastro")] Pessoas pessoas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pessoas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Pscdendereco"] = new SelectList(_context.Enderecos, "Edcdendereco", "Edbairro", pessoas.Pscdendereco);
            return View(pessoas);
        }

        // GET: Pessoas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pessoas == null)
            {
                return NotFound();
            }

            var pessoas = await _context.Pessoas.FindAsync(id);
            if (pessoas == null)
            {
                return NotFound();
            }
            ViewData["Pscdendereco"] = new SelectList(_context.Enderecos, "Edcdendereco", "Edbairro", pessoas.Pscdendereco);
            return View(pessoas);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Pscdpessoa,Pscdendereco,Psnome,Psemail,Pscgc,Psdtnascimento,Psdtcadastro")] Pessoas pessoas)
        {
            if (id != pessoas.Pscdpessoa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoasExists(pessoas.Pscdpessoa))
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
            ViewData["Pscdendereco"] = new SelectList(_context.Enderecos, "Edcdendereco", "Edbairro", pessoas.Pscdendereco);
            return View(pessoas);
        }

        // GET: Pessoas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pessoas == null)
            {
                return NotFound();
            }

            var pessoas = await _context.Pessoas
                .Include(p => p.PscdenderecoNavigation)
                .FirstOrDefaultAsync(m => m.Pscdpessoa == id);
            if (pessoas == null)
            {
                return NotFound();
            }

            return View(pessoas);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pessoas == null)
            {
                return Problem("Entity set 'automobilisticaContext.Pessoas'  is null.");
            }
            var pessoas = await _context.Pessoas.FindAsync(id);
            if (pessoas != null)
            {
                _context.Pessoas.Remove(pessoas);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Não foi possível excluir essa pessoa, verifique se ela possui algum cadastro ativo.";
                return View(pessoas);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool PessoasExists(int id)
        {
          return (_context.Pessoas?.Any(e => e.Pscdpessoa == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Automobilistica.Models;
using QRCoder;
using System.Drawing;

namespace Automobilistica.Controllers
{
    public class ClientesController : Controller
    {
        private readonly AutomobilisticaContext _context;

        public ClientesController(AutomobilisticaContext context)
        {
            _context = context;
        }

        public void GerarQRCode()
        {
            string conteudo = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(conteudo, QRCodeGenerator.ECCLevel.Q);

            var qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(10);

            MemoryStream ms = new MemoryStream();
            qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] byteImage = ms.ToArray();
            ViewBag.QRCodeImageSrc = "data:image/png;base64," + Convert.ToBase64String(byteImage);
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var automobilisticaContext = _context.Cliente.Include(c => c.ClcdpessoaNavigation);
            return View(await automobilisticaContext.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cliente == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .Include(c => c.ClcdpessoaNavigation)
                .FirstOrDefaultAsync(m => m.Clcdcliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            GerarQRCode();
            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            ViewData["Clcdpessoa"] = new SelectList(_context.Pessoas, "Pscdpessoa", "Pscgc");
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Clcdcliente,Clcdpessoa,Cldtcadastro,Cldtalteracao,Clstatus")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Clcdpessoa"] = new SelectList(_context.Pessoas, "Pscdpessoa", "Pscgc", cliente.Clcdpessoa);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cliente == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            ViewData["Clcdpessoa"] = new SelectList(_context.Pessoas, "Pscdpessoa", "Pscgc", cliente.Clcdpessoa);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Clcdcliente,Clcdpessoa,Cldtcadastro,Cldtalteracao,Clstatus")] Cliente cliente)
        {
            if (id != cliente.Clcdcliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Clcdcliente))
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
            ViewData["Clcdpessoa"] = new SelectList(_context.Pessoas, "Pscdpessoa", "Pscgc", cliente.Clcdpessoa);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cliente == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .Include(c => c.ClcdpessoaNavigation)
                .FirstOrDefaultAsync(m => m.Clcdcliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cliente == null)
            {
                return Problem("Entity set 'automobilisticaContext.Cliente'  is null.");
            }
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente != null)
            {
                _context.Cliente.Remove(cliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
          return (_context.Cliente?.Any(e => e.Clcdcliente == id)).GetValueOrDefault();
        }
    }
}

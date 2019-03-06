using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SolNWebApp.Models;

namespace SolNWebApp.Controllers
{
    public class ControleLancamentoesController : Controller
    {
        private readonly SolNWebAppContext _context;

        public ControleLancamentoesController(SolNWebAppContext context)
        {
            _context = context;
        }

        // GET: ControleLancamentoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ControleLancamento.ToListAsync());
        }

        // GET: ControleLancamentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controleLancamento = await _context.ControleLancamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (controleLancamento == null)
            {
                return NotFound();
            }

            return View(controleLancamento);
        }

        // GET: ControleLancamentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ControleLancamentoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Controle,Data")] ControleLancamento controleLancamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(controleLancamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(controleLancamento);
        }

        // GET: ControleLancamentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controleLancamento = await _context.ControleLancamento.FindAsync(id);
            if (controleLancamento == null)
            {
                return NotFound();
            }
            return View(controleLancamento);
        }

        // POST: ControleLancamentoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Controle,Data")] ControleLancamento controleLancamento)
        {
            if (id != controleLancamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(controleLancamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ControleLancamentoExists(controleLancamento.Id))
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
            return View(controleLancamento);
        }

        // GET: ControleLancamentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controleLancamento = await _context.ControleLancamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (controleLancamento == null)
            {
                return NotFound();
            }

            return View(controleLancamento);
        }

        // POST: ControleLancamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var controleLancamento = await _context.ControleLancamento.FindAsync(id);
            _context.ControleLancamento.Remove(controleLancamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ControleLancamentoExists(int id)
        {
            return _context.ControleLancamento.Any(e => e.Id == id);
        }
    }
}

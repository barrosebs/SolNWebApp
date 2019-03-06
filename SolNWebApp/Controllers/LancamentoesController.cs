using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SolNWebApp.Models;
using SolNWebApp.Services;

namespace SolNWebApp.Controllers
{
    public class LancamentoesController : Controller
    {
        private readonly SolNWebAppContext _context;
        private readonly LancamentoService _lancamentoService;
        private readonly ControleService _controleService;

        public LancamentoesController(SolNWebAppContext context, LancamentoService lancamentoService, ControleService controleService)
        {
            _context = context;
            _controleService = controleService;
            _lancamentoService = lancamentoService;
        }

        // GET: Lancamentoes
        public async Task<IActionResult> Index()
        {
            var solNWebAppContext = _context.Lancamento.Include(l => l.Atleta).Include(l => l.ControleLancamento);
            return View(await solNWebAppContext.ToListAsync());
        }

        // GET: Lancamentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lancamento = await _context.Lancamento
                .Include(l => l.Atleta)
                .Include(l => l.ControleLancamento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lancamento == null)
            {
                return NotFound();
            }

            return View(lancamento);
        }

        // GET: Lancamentoes/Create
        public IActionResult Create()
        {
            ViewData["AtletaId"] = new SelectList(_context.Atleta, "Id", "Nome");
            ViewData["ControleLancamentoId"] = new SelectList(_context.ControleLancamento, "Id", "Controle");
            return View();
        }

        // POST: Lancamentoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Vencimento,Descricao,Detalhes,Valor,Status,Data,AtletaId,ControleLancamentoId")] Lancamento lancamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lancamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AtletaId"] = new SelectList(_context.Atleta, "Id", "Nome", lancamento.AtletaId);
            ViewData["ControleLancamentoId"] = new SelectList(_context.ControleLancamento, "Id", "Controle", lancamento.ControleLancamentoId);
            return View(lancamento);
        }

        // GET: Lancamentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lancamento = await _context.Lancamento.FindAsync(id);
            if (lancamento == null)
            {
                return NotFound();
            }
            ViewData["AtletaId"] = new SelectList(_context.Atleta, "Id", "Nome", lancamento.AtletaId);
            ViewData["ControleLancamentoId"] = new SelectList(_context.ControleLancamento, "Id", "Controle", lancamento.ControleLancamentoId);
            return View(lancamento);
        }

        // POST: Lancamentoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Vencimento,Descricao,Detalhes,Valor,Status,Data,AtletaId,ControleLancamentoId")] Lancamento lancamento)
        {
            if (id != lancamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _context.Update(lancamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LancamentoExists(lancamento.Id))
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
            ViewData["AtletaId"] = new SelectList(_context.Atleta, "Id", "Nome", lancamento.AtletaId);
            ViewData["ControleLancamentoId"] = new SelectList(_context.ControleLancamento, "Id", "Id", lancamento.ControleLancamentoId);
            return View(lancamento);
        }

        // GET: Lancamentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lancamento = await _context.Lancamento
                .Include(l => l.Atleta)
                .Include(l => l.ControleLancamento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lancamento == null)
            {
                return NotFound();
            }

            return View(lancamento);
        }

        // POST: Lancamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lancamento = await _context.Lancamento.FindAsync(id);
            _context.Lancamento.Remove(lancamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LancamentoExists(int id)
        {
            return _context.Lancamento.Any(e => e.Id == id);
        }


        public DateTime DateMoths(int month)
        {
            DateTime Vencimento = DateTime.Now;
            Vencimento = new DateTime(Vencimento.Year, month, 1);

            return Vencimento;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SolNWebApp.Models;
using SolNWebApp.Models.ViewModels;
using SolNWebApp.Services;
using SolNWebApp.Services.Exceptions;

namespace SolNWebApp.Controllers
{
    public class SituacaoDoAtletasController : Controller
    {
        private readonly SolNWebAppContext _context;
        private readonly AtletaService _atletaService;
        public SituacaoDoAtletasController(SolNWebAppContext context, AtletaService atletaService)
        {
            _context = context;
            _atletaService = atletaService;
        }

        // GET: SituacaoDoAtletas
        public async Task<IActionResult> Index()
        {
            return View(await _context.SituacaoDoAtleta.Include(obj => obj.Atleta).ToListAsync());
        }

        // GET: SituacaoDoAtletas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var situacaoDoAtleta = await _context.SituacaoDoAtleta.Include(obj => obj.Atleta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (situacaoDoAtleta == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(situacaoDoAtleta);
        }

        // GET: SituacaoDoAtletas/Create
        public IActionResult Create()
        {
            var atletas = _atletaService.FindAll();
            var viewModel = new AtletaFormViewModel { Atletas = atletas };
            return View(viewModel);
        }

        // POST: SituacaoDoAtletas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Situacao,Status,Data,Valor")] SituacaoDoAtleta situacaoDoAtleta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(situacaoDoAtleta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(situacaoDoAtleta);
        }

        // GET: SituacaoDoAtletas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var situacaoDoAtleta = await _context.SituacaoDoAtleta.FindAsync(id);
            if (situacaoDoAtleta == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            return View(situacaoDoAtleta);
        }

        // POST: SituacaoDoAtletas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Situacao,Status,Data,Valor")] SituacaoDoAtleta situacaoDoAtleta)
        {
            if (id != situacaoDoAtleta.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não correspondem" });
                //return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(situacaoDoAtleta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (!SituacaoDoAtletaExists(situacaoDoAtleta.Id))
                    {
                        return RedirectToAction(nameof(Error), new { message = e.Message });
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(situacaoDoAtleta);
        }

        // GET: SituacaoDoAtletas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não forcedido" });
            }

            var situacaoDoAtleta = await _context.SituacaoDoAtleta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (situacaoDoAtleta == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(situacaoDoAtleta);
        }

        // POST: SituacaoDoAtletas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var situacaoDoAtleta = await _context.SituacaoDoAtleta.FindAsync(id);
            _context.SituacaoDoAtleta.Remove(situacaoDoAtleta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SituacaoDoAtletaExists(int id)
        {
            return _context.SituacaoDoAtleta.Any(e => e.Id == id);
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        };
            return View(viewModel);
        }

        // GET: SituacaoDoAtletas
        public async Task<IActionResult> SimpleSearch()
        {
            return View();
        }

        public async Task<IActionResult> GroupingSearch()
        {
            return View();
        }
    }
}

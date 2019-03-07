using System;

using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolNWebApp.Models;
using SolNWebApp.Services;
using SolNWebApp.Services.Exceptions;
namespace SolNWebApp.Controllers
{
    public class AtletasController : Controller
    {
        private readonly SolNWebAppContext _context;
        private readonly AtletaService _atletaService;

        public AtletasController(SolNWebAppContext context, AtletaService atletaService)
        {
            _context = context;
            _atletaService = atletaService;
        }

        // GET: Atletas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Atleta.ToListAsync());
        }

        // GET: Atletas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atleta = await _context.Atleta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atleta == null)
            {
                return NotFound();
            }

            return View(atleta);
        }

        // GET: Atletas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Atletas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,NomeSocial,Posicao,MembroComissao,DataNascimento,Telefone, DataCadastro")] Atleta atleta)
        {
            if (ModelState.IsValid)
            {
                
                _context.Add(atleta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(atleta);
        }

        // GET: Atletas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atleta = await _context.Atleta.FindAsync(id);
            if (atleta == null)
            {
                return NotFound();
            }
            return View(atleta);
        }

        // POST: Atletas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,NomeSocial,Posicao,MembroComissao,DataNascimento,Telefone,DataCadastro")] Atleta atleta)
        {
            if (id != atleta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atleta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtletaExists(atleta.Id))
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
            return View(atleta);
        }

        // GET: Atletas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atleta = await _context.Atleta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atleta == null)
            {
                return NotFound();
            }

            return View(atleta);
        }

        // POST: Atletas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var atleta = await _context.Atleta.FindAsync(id);
                _context.Atleta.Remove(atleta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Error), new { message = "Atenção: Esse atleta não pode ser deletado. Ele tem registro em outras tabelas." });
            }


        }

        private bool AtletaExists(int id)
        {
            return _context.Atleta.Any(e => e.Id == id);
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
        public async Task<IActionResult> SearchBirthday()
        {

            int minDate = DateTime.Now.Month;

            var result = await _atletaService.FindByBirthdayAsync(minDate);
            if (result.Count == 0)
            {
                ViewData["ClassHeader"] = "x";
                ViewData["TitleMessage"] = "Atenção!";
                ViewData["Message"] = "Ohhhh! Esse mês não temos aniversariantes, que pena!";

            }
            return View(result);
        }

    }
}

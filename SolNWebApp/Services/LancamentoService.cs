using Microsoft.EntityFrameworkCore;
using SolNWebApp.Models;
using SolNWebApp.Services.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolNWebApp.Services
{
    public class LancamentoService
    {
        private readonly SolNWebAppContext _context;

        public LancamentoService(SolNWebAppContext context)
        {
            _context = context;

        }

        public List<Lancamento> FindAll()
        {
            return _context.Lancamento
                .Include(x => x.Atleta)
                .OrderBy(x => x.Id).ToList();
        }

        public async Task RemoAsync(int id)
        {
            try
            {
                var obj = await _context.Atleta.FindAsync(id);
                _context.Atleta.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {

                throw new IntegrityException(e.Message);
            }
        }

        

    }
}


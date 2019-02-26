using Microsoft.EntityFrameworkCore;
using SolNWebApp.Models;
using SolNWebApp.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolNWebApp.Services
{
    public class AtletaService
    {
        private readonly SolNWebAppContext _context;

        public AtletaService(SolNWebAppContext context)
        {
            _context = context;
        }

        public List<Atleta> FindAll()
        {
            return _context.Atleta.OrderBy(x => x.Nome).ToList();
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

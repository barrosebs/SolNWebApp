using Microsoft.EntityFrameworkCore;
using SolNWebApp.Models;
using SolNWebApp.Services.Exceptions;
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

        public async Task<List<Atleta>> FindByBirthdayAsync(int minDate)
        {

            var result = from obj in _context.Atleta select obj;

                result = result.Where(x => x.DataNascimento.Month == minDate);
            
            return await result
                .OrderBy(x => x.DataNascimento.Day)
                .ToListAsync();//result.ToList(); retorna uma consulta em lista  
        }
    }
}

using SolNWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SolNWebApp.Services
{
    public class SituacaoService
    {
        private readonly SolNWebAppContext _context;

        public SituacaoService(SolNWebAppContext context)
        {
            _context = context;
        }

        public async Task<List<SituacaoDoAtleta>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SituacaoDoAtleta select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Data >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Data <= maxDate.Value);
            }

            return await result
                .Include(x => x.Atleta)//realizando join com a tabela atleta
                .OrderByDescending(x => x.Data)
                .ToListAsync();//result.ToList(); retorna uma consulta em lista 
        }
    }
}

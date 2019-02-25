using SolNWebApp.Models;
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
    }
}

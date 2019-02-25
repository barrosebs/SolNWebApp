using SolNWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace SolNWebApp.Services
{
    public class SituacaoService
    {
        private readonly SolNWebAppContext _context;

        public SituacaoService(SolNWebAppContext context)
        {
            _context = context;
        }

        public List<SituacaoDoAtleta> FindAll()
        {
            return _context.SituacaoDoAtleta.ToList();
        }
    }
}

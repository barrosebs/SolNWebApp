using SolNWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SolNWebApp.Services
{
    public class ControleService
    {
        private readonly SolNWebAppContext _context;

        public ControleService(SolNWebAppContext context)
        {
            _context = context;

        }

        public List<ControleLancamento> FindAll()
        {
            return _context.ControleLancamento
                .OrderBy(X => X.Controle)
                .ToList();
        }
    }
}

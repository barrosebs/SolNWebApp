using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SolNWebApp.Models;

namespace SolNWebApp.Models
{
    public class SolNWebAppContext : DbContext
    {
        public SolNWebAppContext (DbContextOptions<SolNWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<SituacaoDoAtleta> SituacaoDoAtleta { get; set; }

        public DbSet<Atleta> Atleta { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

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

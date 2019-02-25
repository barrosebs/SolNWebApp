using SolNWebApp.Models;
using SolNWebApp.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolNWebApp.Data
{
    public class SeedService
    {
        private SolNWebAppContext _context;

        public SeedService(SolNWebAppContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            //verifica se ja existe dados na tabela 
            if (_context.Atleta.Any() || _context.SituacaoDoAtleta.Any())
            {
                return; //DB has been seeded
            }

            Atleta a1 = new Atleta("Eduardo Barros","Neno", Posicao.Goleiro, new DateTime(1977,02,27),"71993521182",DateTime.Now);
            Atleta a2 = new Atleta("Mário Mendes", "Sebastian", Posicao.Jogador, new DateTime(1981,05,28), "71991967256", DateTime.Now);
            Atleta a3 = new Atleta("Galdino","Kal" , Posicao.Jogador, new DateTime(1974,10,30), "71987761487", DateTime.Now);
            Atleta a4 = new Atleta("Marcos","Nato", Posicao.Goleiro, new DateTime(1985,04,20), "71991148155", DateTime.Now);
            Atleta a5 = new Atleta("Marcelo Porcino","Negão", Posicao.Jogador, new DateTime(1978,11,12), "71987749095", DateTime.Now);
            Atleta a6 = new Atleta("Gineto","Sr.", Posicao.Jogador, new DateTime(1955,10,19), "71987143882", DateTime.Now);
            Atleta a7 = new Atleta("Edson Dias","Marezia", Posicao.Jogador, new DateTime(1967,10,02), "7188105420", DateTime.Now);
            Atleta a8 = new Atleta("Luis Pinto","Bola no Mato", Posicao.Jogador, new DateTime(1979,11,21), "71986086623", DateTime.Now);
            Atleta a9 = new Atleta("Wanderley Dantas","Pirinho", Posicao.Jogador, new DateTime(1982,11,04), "71986254733", DateTime.Now);
            Atleta a10 = new Atleta("Valdenor Dantas","Denor", Posicao.Jogador, new DateTime(1970,05,17), "71985223815", DateTime.Now);

            SituacaoDoAtleta sa1 = new SituacaoDoAtleta(Situacao.Ativo,Status.Apto,DateTime.Now,15.0, a1);
            SituacaoDoAtleta sa2 = new SituacaoDoAtleta(Situacao.Desligado,Status.Inapto,DateTime.Now,15.0, a7);
            SituacaoDoAtleta sa3 = new SituacaoDoAtleta(Situacao.Ativo,Status.Apto,DateTime.Now,15.0, a4);
            SituacaoDoAtleta sa4 = new SituacaoDoAtleta(Situacao.Ativo,Status.Apto,DateTime.Now,15.0, a6);
            SituacaoDoAtleta sa5 = new SituacaoDoAtleta(Situacao.Ativo,Status.Apto,DateTime.Now,15.0, a8);
            SituacaoDoAtleta sa6 = new SituacaoDoAtleta(Situacao.Suspenso,Status.Inapto,DateTime.Now,0.0, a9);

            //Gravar no banco
            _context.Atleta.AddRange(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10);
            _context.SituacaoDoAtleta.AddRange(sa1,sa2,sa3,sa4,sa5,sa6);

            _context.SaveChanges();

        }
    }
}

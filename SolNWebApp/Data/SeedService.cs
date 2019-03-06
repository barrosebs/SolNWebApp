using SolNWebApp.Models;
using SolNWebApp.Models.Enum;
using System;
using System.Linq;

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

            Atleta a1 = new Atleta("Eduardo Barros","Neno", Posicao.Goleiro, new DateTime(1977,02,27),"71993521182");
            Atleta a2 = new Atleta("Mário Mendes", "Sebastian", Posicao.Jogador, new DateTime(1981,05,28), "71991967256");
            Atleta a3 = new Atleta("Galdino","Kal" , Posicao.Jogador, new DateTime(1974,10,30), "71987761487");
            Atleta a4 = new Atleta("Marcos","Nato", Posicao.Goleiro, new DateTime(1985,04,20), "71991148155");
            Atleta a5 = new Atleta("Marcelo Porcino","Negão", Posicao.Jogador, new DateTime(1978,11,12), "71987749095");
            Atleta a6 = new Atleta("Gineto","Sr.", Posicao.Jogador, new DateTime(1955,10,19), "71987143882");
            Atleta a7 = new Atleta("Edson Dias","Marezia", Posicao.Jogador, new DateTime(1967,10,02), "7188105420");
            Atleta a8 = new Atleta("Luis Pinto","Bola no Mato", Posicao.Jogador, new DateTime(1979,11,21), "71986086623");
            Atleta a9 = new Atleta("Wanderley Dantas","Pirinho", Posicao.Jogador, new DateTime(1982,11,04), "71986254733");
            Atleta a10 = new Atleta("Valdenor Dantas","Denor", Posicao.Jogador, new DateTime(1970,05,17), "71985223815");

            SituacaoDoAtleta sa1 = new SituacaoDoAtleta(Situacao.Ativo,Status.Apto,DateTime.Now,15.0,a1);
            SituacaoDoAtleta sa2 = new SituacaoDoAtleta(Situacao.Desligado,Status.Inapto,DateTime.Now,15.0, a7);
            SituacaoDoAtleta sa3 = new SituacaoDoAtleta(Situacao.Ativo,Status.Apto,DateTime.Now,15.0, a4);
            SituacaoDoAtleta sa4 = new SituacaoDoAtleta(Situacao.Ativo,Status.Apto,DateTime.Now,15.0, a6);
            SituacaoDoAtleta sa5 = new SituacaoDoAtleta(Situacao.Ativo,Status.Apto,DateTime.Now,15.0, a8);
            SituacaoDoAtleta sa6 = new SituacaoDoAtleta(Situacao.Suspenso,Status.Inapto,DateTime.Now,0.0, a9);

            ControleLancamento cl1 = new ControleLancamento("Mensalidade", DateTime.Now);
            ControleLancamento cl2 = new ControleLancamento("Confraternização", DateTime.Now);
            ControleLancamento cl3 = new ControleLancamento("Manutenção de Patrimônio", DateTime.Now);
            ControleLancamento cl4 = new ControleLancamento("Medicamentos", DateTime.Now);
            ControleLancamento cl5 = new ControleLancamento("Material de Uso-Contínuo", DateTime.Now);
            ControleLancamento cl6 = new ControleLancamento("Convidado", DateTime.Now);
            ControleLancamento cl7 = new ControleLancamento("Cartões", DateTime.Now);
            ControleLancamento cl8 = new ControleLancamento("Reuniões", DateTime.Now);

            Lancamento l1 = new Lancamento(a1, new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month - 1, 1), cl1, "Pagamento atrasado", StatusLancamento.Crédito, 15.00);
            Lancamento l2 = new Lancamento(a1, new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month - 2, 1), cl1, "Pagamento atrasado", StatusLancamento.Crédito, 15.00);
            Lancamento l3 = new Lancamento(a1, new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month, 1), cl1, "Pagamento atrasado", StatusLancamento.Crédito, 15.00);
            Lancamento l4 = new Lancamento(a2, new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month, 1), cl1, "Pagamento atrasado", StatusLancamento.Crédito, 15.00);
            Lancamento l5 = new Lancamento(a2, new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month, 1), cl1, "Pagamento atrasado", StatusLancamento.Crédito, 15.00);
            Lancamento l6 = new Lancamento(a7, new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month - 2, 1), cl1, "Pagamento atrasado", StatusLancamento.Crédito, 15.00);
            Lancamento l7 = new Lancamento(a7, new DateTime(DateTime.Now.Year - 1, 8, 1), cl1, "Pagamento atrasado", StatusLancamento.Crédito, 15.00);
            Lancamento l8 = new Lancamento(a7, new DateTime(DateTime.Now.Year - 1, 9, 1), cl1, "Pagamento atrasado", StatusLancamento.Crédito, 15.00);
            Lancamento l9 = new Lancamento(a5, new DateTime(DateTime.Now.Year,11, 1), cl1, "Pagamento", StatusLancamento.Crédito, 15.00);
            Lancamento l10 = new Lancamento(a5, new DateTime(DateTime.Now.Year, 12, 1), cl1, "Pagamento atrasado", StatusLancamento.Crédito, 15.00);
            Lancamento l11 = new Lancamento(a6, new DateTime(DateTime.Now.Year, 8, 1), cl1, "Pagamento", StatusLancamento.Crédito, 15.00);

            //Gravar no banco
            _context.Atleta.AddRange(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10);
            _context.SituacaoDoAtleta.AddRange(sa1, sa2, sa3, sa4, sa5, sa6);
            _context.ControleLancamento.AddRange(cl1, cl2, cl3, cl4, cl5, cl6, cl7, cl8);
            _context.Lancamento.AddRange(l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11);
            _context.SaveChanges();

        }
    }
}

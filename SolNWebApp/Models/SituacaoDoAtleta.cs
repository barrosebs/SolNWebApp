using SolNWebApp.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolNWebApp.Models
{
    public class SituacaoDoAtleta
    {
        public int Id { get; set; }
        public Situacao Situacao { get; set; }
        public Status Status { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public Atleta Atleta { get; set; }

        public SituacaoDoAtleta()
        {

        }

        public SituacaoDoAtleta(Situacao situacao, Status status, DateTime data, double valor, Atleta atleta)
        {
           
            Situacao = situacao;
            Status = status;
            Data = data;
            Valor = valor;
            Atleta = atleta;
        }

        public double TotalSituacao(DateTime inicial, DateTime final)
        {
            return Atleta.Situacao.Where(a => a.Data >= inicial && a.Data <= final).Sum(a => a.Valor);
        }
    }
}

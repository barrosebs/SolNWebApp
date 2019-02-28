using SolNWebApp.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SolNWebApp.Models
{
    public class SituacaoDoAtleta
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Situação")]
        public Situacao Situacao { get; set; }
        public Status Status { get; set; }

        [Display(Name = "Data de Cadastro")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Valor { get; set; }
        public int AtletaId { get; set; }
        public Atleta Atleta { get; set; }

        public SituacaoDoAtleta()
        {

        }

        public SituacaoDoAtleta(Situacao situacao, Status status, DateTime? data, double valor, Atleta atleta)
        {
            Situacao = situacao;
            Status = status;
            Data = DateTime.Now;
            Valor = valor;
            Atleta = atleta;
        }

        public double TotalSituacao(DateTime inicial, DateTime final)
        {
            return Atleta.Situacao.Where(a => a.Data >= inicial && a.Data <= final).Sum(a => a.Valor);
        }
        
    }
}

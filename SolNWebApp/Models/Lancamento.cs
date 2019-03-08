using SolNWebApp.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace SolNWebApp.Models
{
    public class Lancamento
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório!")]
        [DataType(DataType.Date)]
        public DateTime Vencimento { get; set; }

        public string Detalhes { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [Required(ErrorMessage = "Campo {0} é obrigatório!")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório!")]
        public StatusLancamento Status { get; set; }

        [Display(Name = "Data de Cadastro")]
        [DataType(DataType.DateTime)]
        public DateTime Data { get; set; } = DateTime.Now;

        public int AtletaId { get; set; }
        public Atleta Atleta { get; set; }

        [Display(Name = "Controle")]
        public int ControleLancamentoId { get; set; }
        [Display(Name = "Controle")]
        public ControleLancamento ControleLancamento { get; set; }

        public Lancamento()
        {

        }

        public Lancamento(Atleta atleta, DateTime vencimento, ControleLancamento controleLancamento, string detalhes,
            StatusLancamento status, double valor)
        {
            
            Vencimento = vencimento;
            Detalhes = detalhes;
            Valor = valor;
            Status = status;
            Atleta = atleta;
            ControleLancamento = controleLancamento;
            Data = DateTime.Now;
        }

        public double TotalLancamentoAtleta(DateTime inicial, DateTime final)
        {
            return Atleta.Lancamento.Where(x => x.Data >= inicial && x.Data <= final).Sum(x => x.Valor);
        }

    }
}

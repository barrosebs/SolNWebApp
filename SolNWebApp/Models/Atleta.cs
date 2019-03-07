using SolNWebApp.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Globalization;

namespace SolNWebApp.Models
{
    public class Atleta
    {
        public int Id { get; set; }

        [Display(Name = "Nome do Atleta")]
        [Required(ErrorMessage ="{0} é obrigatório!")]
        [StringLength(60, MinimumLength = 3, ErrorMessage ="O {0} tamanho do nome deve ter entre {2} e {1} caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Nome Social")]
        public string NomeSocial { get; set; }

        [Display(Name = "Posição")]
        [Required(ErrorMessage = "Campo {0} é obrigatório!")]
        public Posicao Posicao { get; set; }

        [Display(Name = "Membro da Comissão")]
        public bool MembroComissao { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório!")]
        [DisplayFormat(DataFormatString ="{0:#######-####}")]
        public string Telefone { get; set; }

        [Display(Name = "Data de Cadastro")]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public ICollection<SituacaoDoAtleta> Situacao { get; set; } = new List<SituacaoDoAtleta>();

        public ICollection<Lancamento> Lancamento { get; set; } = new List<Lancamento>();

        public Atleta()
        {

        }

        public Atleta(string nome, string nomeSocial, Posicao posicao, bool membroComissao, DateTime dataNascimento, string telefone)
        {
            
            Nome = nome;
            NomeSocial = nomeSocial;
            Posicao = posicao;
            MembroComissao = membroComissao;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            DataCadastro = DateTime.Now;
        }


        #region Add & Remove obj
        public void AddSituacao(SituacaoDoAtleta situacao)
        {
            Situacao.Add(situacao);
        }

        public void RemoveSituacao(SituacaoDoAtleta situacao)
        {
            Situacao.Remove(situacao);
        }

        public void AddLancamento(Lancamento lancamento)
        {
            Lancamento.Add(lancamento);
        }

        public void RemoveLancamento(Lancamento lancamento)
        {
            Lancamento.Remove(lancamento);
        }

        #endregion


        public int TotalAtleta(DateTime inicial, DateTime final)
        {
            return Situacao.Where(a => a.Data >= inicial && a.Data <= final).Count(a => Convert.ToBoolean(this.Id));
        }


        public string ConvertToBirthDay(DateTime birthDay)
        {
                        
            TimeSpan duration = DateTime.Now.Subtract(birthDay.Date);

            if (duration.TotalHours < 24.0)
            {
                return duration.TotalHours.ToString("F2", CultureInfo.InvariantCulture) + " horas";
            }
            else
            {
                return duration.TotalDays.ToString("F2", CultureInfo.InvariantCulture) + " Dias";
            }
        }

        /// <summary>
        /// Change the day of the week to pt-BR
        /// </summary>
        /// <param name="data"></param>
        /// <returns>week to pt-BR</returns>
        public string MudarIdiomaDeData(DateTime data)
        {
            string mothDate = data.DayOfWeek.ToString();
            string mothString = "";
            switch (mothDate)
            {
                case "Monday": 
                     mothString = "Segunda-feira";
                    break;
                case "Tuesday":
                    mothString = "Terça-feira";
                    break;
                case "Wednesday":
                    mothString = "Quarta-feira";
                    break;
                case "Thursday":
                    mothString = "Quinta-feira";
                    break;
                case "Friday":
                    mothString = "Sexta-feira";
                    break;
                case "Saturday":
                    mothString = "Sábado";
                    break;
                case "Sunday":
                    mothString = "Domingo";
                    break;

                default:
                    mothString = "Dia inválido";
                    break;
                    
            }
            return mothString;
        }

    }
}

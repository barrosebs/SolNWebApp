using System.Web;
using SolNWebApp.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório!")]
        [DisplayFormat(DataFormatString ="{0:#######-####}")]
        public string Telefone { get; set; }

        
        [DataType(DataType.DateTime)]
        public DateTime DataCadastro { get; set; }
        public ICollection<SituacaoDoAtleta> Situacao { get; set; } = new List<SituacaoDoAtleta>();


       public Atleta()
        {

        }

        public Atleta(string nome, string nomeSocial, Posicao posicao, DateTime dataNascimento, string telefone, DateTime dataCadastro)
        {
            
            Nome = nome;
            NomeSocial = nomeSocial;
            Posicao = posicao;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            DataCadastro = dataCadastro;
        }

        public void AddSituacao(SituacaoDoAtleta situacao)
        {
            Situacao.Add(situacao);
        }

        public void RemoveSituacao(SituacaoDoAtleta situacao)
        {
            Situacao.Remove(situacao);
        }

    }
}

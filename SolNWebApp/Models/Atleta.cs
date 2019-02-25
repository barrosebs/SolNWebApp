using SolNWebApp.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolNWebApp.Models
{
    public class Atleta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeSocial { get; set; }
        public Posicao Posicao { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
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

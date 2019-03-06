using System;
using System.ComponentModel.DataAnnotations;

namespace SolNWebApp.Models
{
    public class ControleLancamento
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Controle")]
        public string Controle { get; set; }

        public DateTime Data { get; set; } = DateTime.Now;



        public ControleLancamento()
        {

        }

        public ControleLancamento(string controle, DateTime data)
        {
            Controle = controle;
        }
    }
}

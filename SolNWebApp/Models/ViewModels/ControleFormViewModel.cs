using System.Collections.Generic;

namespace SolNWebApp.Models.ViewModels
{
    public class ControleFormViewModel
    {
        public Lancamento Lancamento { get; set; }
        public ICollection<ControleLancamento> ControleLancamentoes { get; set; }
    }
}

using System.Collections.Generic;

namespace SolNWebApp.Models.ViewModels
{
    public class AtletaFormViewModel
    {
        public SituacaoDoAtleta Situacao { get; set; }
        public ICollection<Atleta> Atletas { get; set; }

    }
}

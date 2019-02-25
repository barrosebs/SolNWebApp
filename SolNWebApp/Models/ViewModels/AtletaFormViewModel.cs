using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolNWebApp.Models.ViewModels
{
    public class AtletaFormViewModel
    {
        public SituacaoDoAtleta Situacao { get; set; }
        public ICollection<Atleta> Atletas { get; set; }

    }
}

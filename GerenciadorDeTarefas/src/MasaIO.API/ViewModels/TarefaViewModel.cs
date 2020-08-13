using MasaIO.business.Enum;
using System;

namespace MasaIO.API.ViewModels
{
    public class TarefaViewModel
    {
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public TarefaEstados Estado { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataUltimaAlteracao { get; set; }

        public Guid EquipeId { get; set; }

        /* Relation EF */
        public EquipeViewModel Equipe { get; set; }
    }
}

using MasaIO.business.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasaIO.business.Model
{
    public class Tarefa : Entity
    {
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public TarefaEstados Estado { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataUltimaAlteracao { get; set; }

        public Guid EquipeId { get; set; }

        /* Relation EF */
        public Equipe Equipe { get; set; }
    }
}

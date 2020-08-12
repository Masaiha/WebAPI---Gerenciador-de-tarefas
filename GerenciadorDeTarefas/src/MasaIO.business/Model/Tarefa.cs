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

        public DateTime DataCriacao { get; set; }

        public TarefaEstados Estado { get; set; }

        public DateTime DataUltimaAlteracao { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace MasaIO.business.Model
{
    public class Equipe : Entity
    {
        public string Nome { get; set; }

        public DateTime DataCadastro { get; set; }

        public string escudo { get; set; }

        public IEnumerable<Tarefa> Tarefas { get; set; }
    }
}

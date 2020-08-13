using System;
using System.Collections.Generic;

namespace MasaIO.API.ViewModels
{
    public class EquipeViewModel
    {
        public string Nome { get; set; }

        public DateTime DataCadastro { get; set; }

        public string escudo { get; set; }

        public IEnumerable<TarefaViewModel> Tarefas { get; set; }
    }
}

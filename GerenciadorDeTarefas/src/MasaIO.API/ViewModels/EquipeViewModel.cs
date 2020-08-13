using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MasaIO.API.ViewModels
{
    public class EquipeViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        public DateTime DataCadastro { get; set; }

        public string escudo { get; set; }

        public IEnumerable<TarefaViewModel> Tarefas { get; set; }
    }
}

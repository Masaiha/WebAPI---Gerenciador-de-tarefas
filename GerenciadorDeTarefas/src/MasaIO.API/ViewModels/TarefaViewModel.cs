﻿using MasaIO.business.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace MasaIO.API.ViewModels
{
    public class TarefaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Estado { get; set; }

        //public DateTime DataCadastro { get; set; }

        public DateTime DataUltimaAlteracao { get; set; }

        public Guid EquipeId { get; set; }


        [ScaffoldColumn(false)]
        public string EquipeNome { get; set; }
    }
}

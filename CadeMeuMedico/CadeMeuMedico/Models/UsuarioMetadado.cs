﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuMedico.Models
{
    [MetadataType(typeof (UsuarioMetadado))]
    public partial class Usuario
    {
    }
    public class UsuarioMetadado
    {
        [Required(ErrorMessage = "Obrigatório informar o nome.")]
        [StringLength(80, ErrorMessage = "O Nome deve possuir no máximo 80 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Login.")]
        [StringLength(30, ErrorMessage = "O Login deve possuir no máximo 30 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a Senha.")]
        [StringLength(100, ErrorMessage = "A Senha deve possuir no máximo 100 caracteres")]
        [MinLength(6, ErrorMessage = "A Senha deve possuir no mínimo 6 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Email.")]
        [StringLength(100, ErrorMessage = "O Email deve possuir no máximo 100 caracteres")]
        public string Email { get; set; }

    }
}

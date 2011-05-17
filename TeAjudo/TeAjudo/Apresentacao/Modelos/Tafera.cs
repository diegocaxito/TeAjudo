using System;
using System.ComponentModel.DataAnnotations;

namespace TeAjudo.Apresentacao.Modelos
{
    public class Tafera
    {
        [Required(ErrorMessage = "Título é campo obrigatório.")]
        [StringLength(255, ErrorMessage = "Título deve ter no máximo 255 caracteres.")]
        public string Titulo { get; set; }
        public string Descricao { get; set; }
    }
}
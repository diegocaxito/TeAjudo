using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TeAjudo.Models.Principal.Modelos;

namespace TeAjudo.Apresentacao.Modelos
{
    public class Tafera
    {
        [Required(ErrorMessage = "Assunto é campo obrigatório.")]
        [StringLength(255, ErrorMessage = "Assunto deve ter no máximo 255 caracteres.")]
        public string Assunto { get; set; }
        public string Descricao { get; set; }
        public string Solicitante { get; set; }
        public SelectList Origem { get; set; }
        public SelectListItem OrigemSelecionada { get; set; }
    }
}
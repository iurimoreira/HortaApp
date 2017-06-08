using System.ComponentModel.DataAnnotations;

namespace HortaApp.Web.Models.ViewModels
{
    public class PostagemViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public int PostagemId { get; set; }

        [Display(Name = "UsuarioId")]
        public string Usuarioid { get; set; }

        [Required]
        [Display(Name = "Conteúdo")]
        public string Conteudo { get; set; }

        [Display(Name = "Adicionar imagem")]
        public string FotoPostagem { get; set; }
    }
}
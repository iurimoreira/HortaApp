using System.ComponentModel.DataAnnotations;

namespace HortaApp.Web.Models.ViewModels
{
    public class ImagemViewModel
    {
        [Key]
        public int ImagemId { get; set; }

        public string UsuarioId { get; set; }

        public string EmailUsuario { get; set; }

        public string UrlImagem { get; set; }
    }
}
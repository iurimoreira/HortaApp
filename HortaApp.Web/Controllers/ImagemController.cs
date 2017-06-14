using HortaApp.Web.Models.ViewModels;
using HortaApp.Web.Services;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HortaApp.Web.Controllers
{
    public class ImagemController : Controller
    {
        private HttpClient _client;

        public ImagemController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:63632/");
            _client.DefaultRequestHeaders.Accept.Clear();

            var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.DefaultRequestHeaders.Accept.Add(mediaType);
        }

        ImageService imageService = new ImageService();

        // GET: Imagem
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            return View();
        }

        //[HttpPost]
        public async void Upload(string imagemUrl)
        {
            //var imageUrl = await imageService.UploadImageAsync(photo);

            ImagemViewModel imagem = new ImagemViewModel();

            imagem.UsuarioId = Session["idUsuario"].ToString();
            imagem.EmailUsuario = Session["EmailUsuario"].ToString();
            imagem.UrlImagem = imagemUrl;

            var response = await _client.PostAsJsonAsync("api/Imagem", imagem);

            //return RedirectToAction("Index", "Home");
        }
    }
}
using System;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HortaApp.Web.Models.ViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web;
using HortaApp.Web.Services;

namespace HortaApp.Web.Controllers
{
    public class PostagemController : Controller
    {
        private HttpClient _client;
        ImageService imageService = new ImageService();

        public PostagemController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:63632/");
            _client.DefaultRequestHeaders.Accept.Clear();

            var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.DefaultRequestHeaders.Accept.Add(mediaType);
        }

        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            var response = await _client.GetAsync("api/Postagem");
            if (response.IsSuccessStatusCode)
            {
                var JsonString = await response.Content.ReadAsStringAsync();
                ViewBag.Timeline = JsonConvert.DeserializeObject<List<PostagemViewModel>>(JsonString);

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PostagemViewModel model, HttpPostedFileBase imagem)
        {
            model.Usuarioid = Session["idUsuario"].ToString();

            var uriparameter = "api/PerfilUsuario/PerfilExiste?id=" + model.Usuarioid;
            var responsePerfil = await _client.GetAsync(uriparameter);
            var JsonString = await responsePerfil.Content.ReadAsStringAsync();
            var perfilUsuario = JsonConvert.DeserializeObject<List<PerfilViewModel>>(JsonString);

            model.AutorPostagem = perfilUsuario[0].NomeUsuario;
            model.FotoAutorPostagem = perfilUsuario[0].FotoPerfil;

            //Verifica se o usuário adicionou uma imagem a postagem ou não
            if (imagem == null)
            {
                model.FotoPostagem = "Sem imagem";
            }
            else
            { 
                var imagemUrl = await imageService.UploadImageAsync(imagem);

                //Salva a imagem como Blob
                ImagemController imagemController = new ImagemController();
                imagemController.ControllerContext = new ControllerContext(this.Request.RequestContext, imagemController);
                imagemController.Upload(imagemUrl);

                model.FotoPostagem = imagemUrl.ToString();
            }

            if (ModelState.IsValid)
            {
                var response = await _client.PostAsJsonAsync("api/Postagem", model);
                return RedirectToAction("Index", "Postagem");
            }
            else
            {
                return View();
            }
        }

        [AllowAnonymous]
        public async Task<List<PostagemViewModel>> PegarPostagens(string id)
        {
            List<PostagemViewModel> listaPostagens = new List<PostagemViewModel>();
            var response = await _client.GetAsync("api/Postagem?id="+id);
            if (response.IsSuccessStatusCode)
            {
                var JsonString = await response.Content.ReadAsStringAsync();
                listaPostagens = JsonConvert.DeserializeObject<List<PostagemViewModel>>(JsonString);

                return listaPostagens;
            }
            else
            {
                return listaPostagens;
            }
        }
    }
}

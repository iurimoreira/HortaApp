using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HortaApp.Domain;
using HortaApp.Web.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HortaApp.Web.Models.ViewModels;

namespace HortaApp.Web.Controllers
{
    public class PostagemController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private HttpClient _client;

        public PostagemController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:63632/");
            _client.DefaultRequestHeaders.Accept.Clear();

            var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.DefaultRequestHeaders.Accept.Add(mediaType);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PostagemViewModel model)
        {
            model.Usuarioid = Session["idUsuario"].ToString();
            if (ModelState.IsValid)
            {
                var response = await _client.PostAsJsonAsync("api/Postagem", model);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
    }
}

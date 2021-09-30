using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationBlog.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace WebApplicationBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.articulo = ReadAll();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public List<Articles> ReadAll()
        {
            Article noticias = new Article();
            string apiUrl = Environment.GetEnvironmentVariable("urllocal");// "https://raw.githubusercontent.com/aspsnippets/test/master/Customers.json";
            List<Articles> articulos = new List<Articles>();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                //   var r = response.
                string strjson = response.Content.ReadAsStringAsync().Result;
                JObject json = JObject.Parse(strjson);
                var r = JObject.Parse(strjson);

                foreach (var item in r.Root.Children().ToList()[0].ToList()[0].ToList())
                {
                    Articles articulo = new Articles();
                    articulo.title = ((Newtonsoft.Json.Linq.JValue)item["titulo"]).Value.ToString();
                    articulo.content = ((Newtonsoft.Json.Linq.JValue)item["contenido"]).Value.ToString();
                    articulo.description = ((Newtonsoft.Json.Linq.JValue)item["descripcion"]).Value.ToString();
                    if (((Newtonsoft.Json.Linq.JValue)item["imagen"]).Value != null)
                    {
                        articulo.image = ((Newtonsoft.Json.Linq.JValue)item["imagen"]).Value.ToString();

                    }
                    if (((Newtonsoft.Json.Linq.JValue)item["url"]).Value != null)
                    {
                        articulo.url = ((Newtonsoft.Json.Linq.JValue)item["url"]).Value.ToString();

                    }
                    articulos.Add(articulo);


                }


            }
            return articulos;

        }
    }
}

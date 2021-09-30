using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationBlog.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace WebApplicationBlog.Controllers
{
    public class BlogController : Controller
    {
        // GET: BlogController
        public ActionResult Index()
        {
            ViewBag.articulo = ReadAll();
            return View();
        }

        // GET: BlogController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public List<Articles> ReadAll()
        {
            Article noticias = new Article();
            string apiUrl = Environment.GetEnvironmentVariable("url");// "https://raw.githubusercontent.com/aspsnippets/test/master/Customers.json";
            List<Articles> articulos = new List<Articles>();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;
            if (response.IsSuccessStatusCode)
            {
             //   var r = response.
                string strjson = response.Content.ReadAsStringAsync().Result;
                JObject json = JObject.Parse(strjson);
                var r = JObject.Parse(strjson);

                foreach (var item in r.Last.Children().ToList()[0].ToList())
                {
                    Articles articulo = new Articles();
                    articulo.title = ((Newtonsoft.Json.Linq.JValue)item["title"]).Value.ToString();
                    articulo.content = ((Newtonsoft.Json.Linq.JValue)item["content"]).Value.ToString();
                    articulo.description = ((Newtonsoft.Json.Linq.JValue)item["description"]).Value.ToString();
                    articulo.image = ((Newtonsoft.Json.Linq.JValue)item["image"]).Value.ToString();
                    articulo.url = ((Newtonsoft.Json.Linq.JValue)item["url"]).Value.ToString();
                    articulos.Add(articulo);
                }
             
              
            }
            return articulos;
   
        }

        // GET: BlogController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BlogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BlogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

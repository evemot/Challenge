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
using Newtonsoft.Json.Serialization;
using System.IO;
namespace WebApplicationBlog.Controllers
{
    public class RegNuevoController : Controller
    {
        // GET: RegNuevoController
     
        public ActionResult Index()
        {
             return View();
        }
     
        //GET: RegNuevoController/Create
        [HttpPost]
        public ActionResult Index(Noticia art)
        {
            //Articles articles = new Articles();
           

            if (ModelState.IsValid)
            {
                createNewReg(art);
               // RedirectToAction("Index", "Blog");
            }

            return View();
        }


        public async Task<IActionResult> createNewReg(Noticia article)
        {

           

            string apiUrl = Environment.GetEnvironmentVariable("urllocal");
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(article), System.Text.Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(apiUrl, content))
                {
                   
                    var apiResponse = response;
                   // await Response.WriteAsync("<script>window.alert('Registro guardado!')</script>");
                    


                }

            }
           // RedirectToPage("../");

            return View();

        }
    }


         
    
}

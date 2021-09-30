using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChallengeApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class NoticiaController : Controller
    {


        [HttpGet]
        public async Task<String> Get()
        {
            var noticias = await Listar();
            return noticias;

        }

        private async Task<string> Listar()
        {

            string token = Environment.GetEnvironmentVariable("Token");// "92b4ecbb70611f9f99de91016c78d0f3";
            string url = Environment.GetEnvironmentVariable("url") + token;
            HttpClient client = new HttpClient();
            var res = await client.GetAsync(url);

            string blog = "";
            if (res.IsSuccessStatusCode)
            {
                var content = await res.Content.ReadAsStringAsync();
                blog = content;


            }
            return blog;
        }
    }

}

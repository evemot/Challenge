using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace WebApplicationBlog.Models
{
    public class Noticia 
    {

        public object data { get; set; }

        public string Mensaje { get; set; }

        
        public string Titulo { get; set; }

        [JsonRequired]
        public string Descripcion { get; set; }

        [JsonRequired]
        public string Contenido { get; set; }
        [JsonRequired]
       
        public string url { get; set; }

        public bool existoso { get; set; }

        public int id { get; set; }

        public byte estado { get; set; }
       
        public string imagen { get; set; }



       

    }
}

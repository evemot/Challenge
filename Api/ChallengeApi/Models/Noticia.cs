using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ChallengeApi.Models
{
    public class Noticia
    {

        public object data { get; set; }

        public string Mensaje { get; set; }


        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public string Contenido { get; set; }

        public string url { get; set; }

        public bool existoso { get; set; }

        public int id { get; set; }

        public byte estado { get; set; }

        public string imagen { get; set; }
        public string usuario { get; set; }
       
        public string fecha { get; set; }

    }
}

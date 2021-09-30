using System;
using System.Collections.Generic;

#nullable disable

namespace ChallengeApi.Models
{
    public partial class Noticium
    {
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Contenido { get; set; }
        public string Url { get; set; }
        public string Usuariocrea { get; set; }
        public DateTime? Fechacrea { get; set; }
        public string Usuariomodifica { get; set; }
        public DateTime? Fechamodifica { get; set; }
        public string IdSecundario { get; set; }
        public string imagen { get; set; }
        public Boolean estado { get; set; }
    }
}

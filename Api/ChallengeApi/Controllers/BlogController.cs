using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChallengeApi.Models;
namespace ChallengeApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    public class BlogController : Controller
    {
            [HttpGet]
            public IActionResult Get()
            {
                Noticia noticia = new Noticia();
                try { 
                    using (BlogContext db = new BlogContext())
                    {
                        var lst = db.Noticia.ToList();
                        noticia.data = lst;
                    noticia.existoso = true;
                    }
                }catch (Exception ex)
                {
                    noticia.Mensaje = ex.Message;
                noticia.existoso = false;
                }
                return Ok(noticia) ;

            }
        [HttpPost]
        public IActionResult Add( Noticia info)
        {
            Noticia noticia = new Noticia();
            try
            {
                using (BlogContext db = new BlogContext())
                {
                    Noticium notician = new Noticium();
                    notician.Titulo = info.Titulo;
                    notician.Descripcion = info.Descripcion;
                    notician.Contenido = info.Contenido;
                    notician.Url = info.url;
                    notician.estado = true;
                    notician.imagen = info.imagen;
                    notician.Usuariocrea = "userWeb";
                    notician.Fechacrea = DateTime.Today;
                    db.Noticia.Add(notician);
                    db.SaveChanges();
                    info.existoso = true;
                    noticia.id = info.id;
                    
                }
                
            }
            catch (Exception ex)
            {
                noticia.Mensaje = ex.Message;
                info.existoso = false;
            }
            return Ok(noticia);

        }

        [HttpPut]
        public IActionResult Edit(Noticia info, string tipoUpdate="Edit" )
        {
            Noticia noticia = new Noticia();
            try
            {
                using (BlogContext db = new BlogContext())
                {
                    Noticium notician = db.Noticia.Find(info.id);
                    if (tipoUpdate=="Edit")
                    { 
                        notician.Titulo = info.Titulo;
                        notician.Descripcion = info.Descripcion;
                        notician.Contenido = info.Contenido;
                        notician.Url = info.url;
                        notician.imagen = info.imagen;
                        notician.Usuariomodifica = info.usuario;
                        notician.Fechamodifica = DateTime.Today;
                    }
                    else
                    {
                        notician.estado = false;
                    }
                    db.Entry(notician).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
             //       db.Noticia.Add(notician);
                    db.SaveChanges();
                    info.existoso = true;
                }
            }
            catch (Exception ex)
            {
                noticia.Mensaje = ex.Message;
                info.existoso = false;
            }
            return Ok(noticia);

        }

      


    }

}

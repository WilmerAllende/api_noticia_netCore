using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ws_wa_noticias.Models;

namespace ws_wa_noticias.Services
{
    public class NoticiaService
    {
        private readonly NoticiaDBContext _noticiaDBContext;
        public NoticiaService(NoticiaDBContext noticiaDBContext)
        {
            _noticiaDBContext = noticiaDBContext;
        }

        public bool AgregarNoticia(Noticia _noticia)
        {
            try
            {
                _noticiaDBContext.Noticia.Add(_noticia);
                _noticiaDBContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
        public List<Noticia> Obtener()
        {
            var resultado = _noticiaDBContext.Noticia.Include(x => x.Autor).ToList();
            return resultado;
        }

        public bool EditarNoticia(Noticia _noticia)
        {
            try
            {
                var noticiaBD = _noticiaDBContext.Noticia.Where(busqueda => busqueda.NoticiaID == _noticia.NoticiaID).FirstOrDefault();
                noticiaBD.Titulo = _noticia.Titulo;
                noticiaBD.Descripcion = _noticia.Descripcion;
                noticiaBD.Contenido = _noticia.Contenido;
                noticiaBD.AutorID = _noticia.AutorID;
                _noticiaDBContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                
                return false;
            }

        }

        public bool EliminarNoticia(int id)
        {
            try
            {
                var noticiaBD = _noticiaDBContext.Noticia.Where(busqueda => busqueda.NoticiaID == id).FirstOrDefault();           
                _noticiaDBContext.Noticia.Remove(noticiaBD);
                _noticiaDBContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public List<NoticiaFiltro> BuscarNoticiaTitulo(string titulo)
        {
            try
            {
                /* 
                 SI quiere ejecutar un store  sin que devuelvas datos
                 string sql = "pa_buscar_noticia @titulo='{0}'";
                sql = string.Format(sql, titulo);
                _noticiaDBContext.Database.ExecuteSqlCommand(sql);

                 */
                string sql = "pa_buscar_noticia @titulo='{0}'";
                sql = string.Format(sql, titulo);
                List<NoticiaFiltro> lista = _noticiaDBContext.notiicaFiltro.FromSql(sql).ToList();
                return lista;
            }
            catch(Exception ex)
            {
                return new List<NoticiaFiltro>();
            }
        }

    }
}

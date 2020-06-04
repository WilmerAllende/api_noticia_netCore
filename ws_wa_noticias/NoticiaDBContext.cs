using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ws_wa_noticias.Models;

namespace ws_wa_noticias
{
    public class NoticiaDBContext : DbContext
    {
        public NoticiaDBContext(DbContextOptions opciones) : base(opciones)
        {
        }

        public DbSet<Noticia> Noticia { get; set; }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<NoticiaFiltro> notiicaFiltro { get; set; }

        protected override void OnModelCreating(ModelBuilder modelCreador)
        {
            new Noticia.Mapeo(modelCreador.Entity<Noticia>());
            new Autor.Mapeo(modelCreador.Entity<Autor>());
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ws_wa_noticias.Models
{
    public class Noticia
    {
        public int NoticiaID { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Contenido { get; set; }
        public DateTime Fecha { get; set; }
        public int AutorID { get; set; }
        public Autor Autor { get; set; }

        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<Noticia> mapeoNoticia)
            {
                mapeoNoticia.HasKey(x => x.NoticiaID); // primare key
                mapeoNoticia.Property(x => x.Titulo).HasColumnName("Titulo"); // para especiificar nombre de columna en base de datos
                mapeoNoticia.Property(x => x.Descripcion).HasColumnName("Descripcion");
                mapeoNoticia.ToTable("Noticia"); // Nombre de la tabla en la base de datos
                mapeoNoticia.HasOne(x => x.Autor); // Cada noticia tiene un autor
            }    
        }
    }
    
}

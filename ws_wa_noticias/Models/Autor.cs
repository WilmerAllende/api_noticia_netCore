using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ws_wa_noticias.Models
{
    public class Autor
    {
        public int AutorID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<Autor> mapeoAutor)
            {
                mapeoAutor.HasKey(x => x.AutorID); // primare key
                mapeoAutor.Property(x => x.Nombre).HasColumnName("Nombre"); // para especiificar nombre de columna en base de datos
                mapeoAutor.Property(x => x.Apellido).HasColumnName("Apellido");
                mapeoAutor.ToTable("Autor"); // Nombre de la tabla en la base de datos
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliculas.Models
{
    public class Pelicula
    {
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }

        public string Genero { get; set; }

        public int Año { get; set; }

        public string Imagen { get; set; }

        public Pelicula()
        {
            Titulo = "";
            Sinopsis = "";
            Genero = "";
        }
    }
}

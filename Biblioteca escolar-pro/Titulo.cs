using Biblioteca_escolar_pro.Biblioteca_escolar_pro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_escolar_pro
{
    public class Titulo
    {
        public string Isbn { get; }
        public string Nombre { get; }
        public int PrestamosHistoricos { get; set; }
        public List<Ejemplar> Ejemplares { get; }

        public Titulo(string isbn, string nombre, int cantidadEjemplares)
        {
            Isbn = isbn;
            Nombre = nombre;
            PrestamosHistoricos = 0;
            Ejemplares = new List<Ejemplar>();

            for (int i = 1; i <= cantidadEjemplares; i++)
            {
                Ejemplares.Add(new Ejemplar(i));
            }
        }
    }
}


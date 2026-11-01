using Biblioteca_escolar_pro.Biblioteca_escolar_pro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_escolar_pro
{
    namespace Biblioteca_escolar_pro
    {
        public class Titulo
        {
            public string Isbn { get; }
            public string Nombre { get; }
            public int PrestamosHistoricos { get; private set; }
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

            public int Disponibles
            {
                get
                {
                    int disponibles = 0;
                    foreach (Ejemplar e in Ejemplares)
                    {
                        if (!e.Prestado)
                            disponibles++;
                    }
                    return disponibles;
                }
            }

        
            public bool RegistrarPrestamo()
            {
                foreach (Ejemplar e in Ejemplares)
                {
                    if (!e.Prestado)
                    {
                        e.Prestado = true;
                        PrestamosHistoricos++;
                        return true;
                    }
                }
                return false;
            }
        }
    }
}

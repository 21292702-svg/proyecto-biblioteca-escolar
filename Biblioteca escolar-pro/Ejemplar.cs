using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_escolar_pro
{
    namespace Biblioteca_escolar_pro
    {
        public class Ejemplar
        {
            public int Numero { get; }
            public bool Prestado { get; set; }

            public Ejemplar(int numero)
            {
                Numero = numero;
                Prestado = false;
            }
        }
    }
}

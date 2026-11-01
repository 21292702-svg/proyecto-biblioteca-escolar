using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca_escolar_pro;
namespace Biblioteca_escolar_pro
{

    using System;
    using System.Collections.Generic;

    namespace Biblioteca_escolar_pro
    {
        public class Biblioteca
        {
            public List<Titulo> Catalogo { get; } = new List<Titulo>();

            public void CargarDatosDePrueba()
            {
                Catalogo.Add(new Titulo("978-0000000001", "Cien años de soledad", 5));
                Catalogo.Add(new Titulo("978-0000000002", "El principito", 1));
                Catalogo.Add(new Titulo("978-0000000003", "Don Quijote de la Mancha", 3));
                Catalogo.Add(new Titulo("978-0000000004", "Rayuela", 2));
                Catalogo.Add(new Titulo("978-0000000005", "Fahrenheit 451", 4));
                Catalogo.Add(new Titulo("978-0000000006", "La metamorfosis", 1));
                Catalogo.Add(new Titulo("978-0000000007", "Pedro Páramo", 5));
                Catalogo.Add(new Titulo("978-0000000008", "El túnel", 2));
            }

            public bool VerificarSinCeldasVacias()
            {
                foreach (Titulo t in Catalogo)
                {
                    if (t.Ejemplares == null || t.Ejemplares.Count == 0)
                        return false;

                    foreach (Ejemplar e in t.Ejemplares)
                    {
                        if (e == null)
                            return false;
                    }
                }
                return true;
            }
        }
    }
}


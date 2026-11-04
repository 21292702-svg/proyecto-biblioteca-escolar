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

            private List<Titulo> _indiceIsbn;

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

                _indiceIsbn = null;
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


            public void OrdenarPorPrestamosInsercion()
            {
                for (int i = 1; i < Catalogo.Count; i++)
                {
                    Titulo actual = Catalogo[i];
                    int j = i - 1;

                    while (j >= 0 && DebeIrAntes(actual, Catalogo[j]))
                    {
                        Catalogo[j + 1] = Catalogo[j];
                        j--;
                    }

                    Catalogo[j + 1] = actual;
                }
            }

            private static bool DebeIrAntes(Titulo a, Titulo b)
            {
                if (a.PrestamosHistoricos != b.PrestamosHistoricos)
                    return a.PrestamosHistoricos > b.PrestamosHistoricos;

                return string.Compare(a.Nombre, b.Nombre, StringComparison.CurrentCulture) < 0;
            }

            public List<Titulo> ObtenerCopiaOrdenadaPorIsbn()
            {
                List<Titulo> copia = new List<Titulo>(Catalogo);

                for (int i = 1; i < copia.Count; i++)
                {
                    Titulo actual = copia[i];
                    int j = i - 1;

                    while (j >= 0 && string.CompareOrdinal(copia[j].Isbn, actual.Isbn) > 0)
                    {
                        copia[j + 1] = copia[j];
                        j--;
                    }

                    copia[j + 1] = actual;
                }

                return copia;
            }

            public Titulo BuscarPorIsbn(string isbn, out int comparaciones)
            {
                if (_indiceIsbn == null)
                    _indiceIsbn = ObtenerCopiaOrdenadaPorIsbn();

                comparaciones = 0;
                int izquierda = 0;
                int derecha = _indiceIsbn.Count - 1;

                while (izquierda <= derecha)
                {
                    int medio = (izquierda + derecha) / 2;
                    comparaciones++;

                    int cmp = string.CompareOrdinal(_indiceIsbn[medio].Isbn, isbn);

                    if (cmp == 0)
                        return _indiceIsbn[medio];

                    if (cmp < 0)
                        izquierda = medio + 1;
                    else
                        derecha = medio - 1;
                }

                return null;
            }

     
            public Titulo BuscarPorTitulo(string nombre)
            {
                foreach (Titulo t in Catalogo)
                {
                    if (string.Equals(t.Nombre, nombre, StringComparison.OrdinalIgnoreCase))
                        return t;
                }

                return null;
            }

            
            public bool RegistrarPrestamoPorIsbn(string isbn, out int comparaciones)
            {
                Titulo t = BuscarPorIsbn(isbn, out comparaciones);

                if (t == null)
                    return false;

                return t.RegistrarPrestamo();
            }
        }
    }
}

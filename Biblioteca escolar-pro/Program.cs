using Biblioteca_escolar_pro;
using Biblioteca_escolar_pro.Biblioteca_escolar_pro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Biblioteca_escolar_pro
{
    class Program
    {
        static void Main(string[] args)
        {
            Biblioteca biblioteca = new Biblioteca();
            biblioteca.CargarDatosDePrueba();

            Console.WriteLine("=== CATÁLOGO ANTES DE LOS PRÉSTAMOS ===");
            MostrarCatalogo(biblioteca);

            Console.WriteLine();
            Console.WriteLine("=== PRÉSTAMOS ===");
            MostrarPrestamo(biblioteca, "978-0000000001");
            MostrarPrestamo(biblioteca, "978-0000000001");
            MostrarPrestamo(biblioteca, "978-0000000002");
            MostrarPrestamo(biblioteca, "978-0000000002");
            MostrarPrestamo(biblioteca, "978-0000000099");

            Console.WriteLine();
            Console.WriteLine("=== CATÁLOGO DESPUÉS DE LOS PRÉSTAMOS (orden original) ===");
            MostrarCatalogo(biblioteca);

            biblioteca.OrdenarPorPrestamosInsercion();

            Console.WriteLine();
            Console.WriteLine("=== CATÁLOGO ORDENADO POR PRÉSTAMOS ===");
            MostrarCatalogo(biblioteca);

            Console.WriteLine();
            Console.WriteLine("=== BÚSQUEDAS POR ISBN (binaria) ===");
            MostrarBusquedaIsbn(biblioteca, "978-0000000005");
            MostrarBusquedaIsbn(biblioteca, "978-0000000099");

            Console.WriteLine();
            Console.WriteLine("=== BÚSQUEDAS POR TÍTULO (secuencial) ===");
            MostrarBusquedaTitulo(biblioteca, "rayuela");
            MostrarBusquedaTitulo(biblioteca, "Ulises");

            Console.ReadKey();
        }

        static void MostrarCatalogo(Biblioteca biblioteca)
        {
            foreach (Titulo t in biblioteca.Catalogo)
            {
                Console.WriteLine($"{t.Isbn} | {t.Nombre} | ejemplares: {t.Ejemplares.Count} | disponibles: {t.Disponibles} | préstamos: {t.PrestamosHistoricos}");
            }
        }

        static void MostrarPrestamo(Biblioteca biblioteca, string isbn)
        {
            int comparaciones;
            bool ok = biblioteca.RegistrarPrestamoPorIsbn(isbn, out comparaciones);
            Console.WriteLine($"Préstamo ISBN {isbn}: {ok} (comparaciones: {comparaciones})");
        }

        static void MostrarBusquedaIsbn(Biblioteca biblioteca, string isbn)
        {
            int comparaciones;
            Titulo t = biblioteca.BuscarPorIsbn(isbn, out comparaciones);

            if (t == null)
                Console.WriteLine($"ISBN {isbn}: no encontrado (comparaciones: {comparaciones})");
            else
                Console.WriteLine($"ISBN {isbn}: {t.Nombre}, disponibles: {t.Disponibles} de {t.Ejemplares.Count} (comparaciones: {comparaciones})");
        }

        static void MostrarBusquedaTitulo(Biblioteca biblioteca, string nombre)
        {
            Titulo t = biblioteca.BuscarPorTitulo(nombre);

            if (t == null)
                Console.WriteLine($"Título \"{nombre}\": no encontrado");
            else
                Console.WriteLine($"Título \"{nombre}\": encontrado, ISBN {t.Isbn}, disponibles: {t.Disponibles} de {t.Ejemplares.Count}");
        }
    }
}
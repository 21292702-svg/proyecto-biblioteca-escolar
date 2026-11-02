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
            Console.WriteLine("=== PRÉSTAMO 1: Cien años de soledad ===");
            Console.WriteLine($"Resultado: {biblioteca.Catalogo[0].RegistrarPrestamo()}");

            Console.WriteLine();
            Console.WriteLine("=== PRÉSTAMO 2: Cien años de soledad ===");
            Console.WriteLine($"Resultado: {biblioteca.Catalogo[0].RegistrarPrestamo()}");

            Console.WriteLine();
            Console.WriteLine("=== PRÉSTAMO 3: El principito ===");
            Console.WriteLine($"Resultado: {biblioteca.Catalogo[1].RegistrarPrestamo()}");

            Console.WriteLine();
            Console.WriteLine("=== INTENTO SIN DISPONIBILIDAD: El principito ===");
            Console.WriteLine($"Resultado: {biblioteca.Catalogo[1].RegistrarPrestamo()}");

            Console.WriteLine();
            Console.WriteLine("=== PRUEBA DE ESTABILIDAD: préstamos a Pedro Páramo y El túnel ===");
            Console.WriteLine($"Resultado: {biblioteca.Catalogo[6].RegistrarPrestamo()}");
            Console.WriteLine($"Resultado: {biblioteca.Catalogo[7].RegistrarPrestamo()}");

            Console.WriteLine();
            Console.WriteLine("=== CATÁLOGO ANTES DEL ORDENAMIENTO ===");
            MostrarCatalogo(biblioteca);

            biblioteca.OrdenarPorPrestamosInsercion();

            Console.WriteLine();
            Console.WriteLine("=== CATÁLOGO DESPUÉS DEL ORDENAMIENTO ===");
            MostrarCatalogo(biblioteca);

            Console.WriteLine();
            Console.WriteLine("=== BÚSQUEDA BINARIA POR ISBN ===");
            MostrarBusquedaIsbn(biblioteca, "978-0000000005");
            MostrarBusquedaIsbn(biblioteca, "978-0000000099");

            Console.WriteLine();
            Console.WriteLine("=== BÚSQUEDA SECUENCIAL POR TÍTULO ===");
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
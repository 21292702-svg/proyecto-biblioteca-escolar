using Biblioteca_escolar_pro;
using Biblioteca_escolar_pro.Biblioteca_escolar_pro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Biblioteca_escolar_pro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Biblioteca biblioteca = new Biblioteca();
            biblioteca.CargarDatosDePrueba();

            Console.WriteLine($"Títulos cargados: {biblioteca.Catalogo.Count}");
            Console.WriteLine($"Sin celdas vacías: {biblioteca.VerificarSinCeldasVacias()}");
            Console.WriteLine();

            foreach (Titulo t in biblioteca.Catalogo)
            {
                Console.WriteLine($"{t.Isbn} | {t.Nombre} | ejemplares: {t.Ejemplares.Count} | préstamos: {t.PrestamosHistoricos}");
            }
        }
    }
}
        

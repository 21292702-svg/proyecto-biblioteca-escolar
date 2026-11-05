\# Proyecto Biblioteca Escolar


Sistema en C# para gestionar un catálogo de libros con distinta cantidad de ejemplares. Permite registrar préstamos, consultar disponibilidad, ordenar el catálogo por préstamos históricos y buscar libros por ISBN o por título.

--Integrantes--

Nava Solís Carlos Damian

21292702uagro.mx


Objetivo

Representar títulos con distinto número de ejemplares sin celdas vacías, ordenar el catálogo por préstamos con ordenamiento por inserción (estable, con orden alfabético en empates) y localizar libros por ISBN con búsqueda binaria propia.

 Funcionalidades
- Carga de ocho títulos de prueba con sus ejemplares.
- Cálculo de ejemplares disponibles por título.
- Registro de préstamos por ISBN, que reduce la disponibilidad y aumenta el contador histórico.
- Ordenamiento manual del catálogo por préstamos (de mayor a menor).
- Búsqueda binaria propia por ISBN, con conteo de comparaciones.
- Búsqueda secuencial por título, sin distinguir mayúsculas.
- Medición de comparaciones frente a `Array.BinarySearch`, usado como verificación.

Estructura de carpetas
- `Biblioteca escolar-pro/`: solución y código fuente en C#
  - `Ejemplar.cs`: ejemplar individual y su estado
  - `Titulo.cs`: título con su ISBN, nombre, ejemplares y préstamos
  - `Biblioteca.cs`: catálogo, ordenamiento y búsquedas
  - `Program.cs`: pruebas y salida por consola
- `docs/`: documentación del proyecto
  - `diseno-preliminar.md`: comparación de estructuras
  - `prueba-escritorio.md`: catálogo antes y después de los préstamos
  - `tabla-comparaciones.md`: comparaciones de la búsqueda binaria
  - `informe.md`: informe final
  - `anexo-catalogo.md`: salida completa del catálogo ordenado
- `README.md`: este archivo
- `.gitignore`: archivos excluidos del control de versiones

 Compilación y ejecución
1. Clonar el repositorio: `git clone https://github.com/21292702-svg/proyecto-biblioteca-escolar.git`
2. Abrir `Biblioteca escolar-pro/Biblioteca escolar-pro.slnx` en Visual Studio.
3. Compilar con Ctrl+Shift+B (o Compilar > Recompilar solución).
4. Ejecutar con F5.

El proyecto usa C#, por lo que `Program.cs` usa `static void Main`.

## Versión
La entrega final corresponde a la etiqueta `v1.0`.
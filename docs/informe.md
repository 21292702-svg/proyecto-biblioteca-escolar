\# Informe final: biblioteca escolar con ejemplares irregulares



\*\*Integrantes:\*\* Nombre Apellido (correo), Nombre Apellido (correo)



\## 1. Introducción



La biblioteca escolar presta libros que no tienen la misma cantidad de ejemplares. El bibliotecario necesita consultar disponibilidad, ordenar el catálogo por préstamos históricos y localizar un libro por su ISBN. Este proyecto implementa esas tres funciones en C# con estructuras y algoritmos escritos a mano.



\## 2. Objetivos



\- Elegir una estructura para títulos con distinto número de ejemplares.

\- Implementar el ordenamiento por inserción, preservando el orden alfabético en los empates.

\- Aplicar búsqueda binaria propia sobre una copia ordenada por ISBN.



\## 3. Decisión de diseño



Se compararon tres opciones (ver `docs/diseno-preliminar.md`): arreglo escalonado, `List<int\[]>` y `List<Titulo>`. Se eligió `List<Titulo>`, con una clase `Titulo` que contiene su ISBN, nombre, contador de préstamos y una `List<Ejemplar>`. Cada título tiene exactamente tantos ejemplares como indica su cantidad, así que no hay celdas vacías, y el código describe cada dato por su nombre.



\## 4. Implementación



\- \*\*Ejemplar\*\*: número de ejemplar y estado prestado o no.

\- \*\*Titulo\*\*: calcula los ejemplares disponibles (`Disponibles`) y registra préstamos (`RegistrarPrestamo`). El contador `PrestamosHistoricos` solo puede modificarse desde ese método.

\- \*\*Biblioteca\*\*: carga los ocho títulos de prueba, ordena el catálogo, construye la copia ordenada por ISBN y realiza las búsquedas.



\## 5. Ordenamiento por inserción



El catálogo se ordena de mayor a menor número de préstamos. Si dos títulos empatan, el orden es alfabético por nombre. El algoritmo mueve un título hacia atrás solo mientras deba ir estrictamente antes que el anterior, por lo que los títulos con igual clave conservan su orden relativo. Esto hace que el ordenamiento sea estable. La prueba del Día 4 lo verificó con "El túnel" y "Pedro Páramo", que tenían un préstamo cada uno: "El túnel" quedó antes que "Pedro Páramo".



No se usaron `Array.Sort` ni `List<T>.Sort`.



\## 6. Búsquedas



\- \*\*Por ISBN (binaria)\*\*: la búsqueda trabaja sobre una copia del catálogo ordenada por ISBN, que se construye con el mismo ordenamiento por inserción. Cada iteración compara con el elemento del medio y descarta la mitad que no puede contener el ISBN. Si el rango queda vacío, el libro no existe.

\- \*\*Por título (secuencial)\*\*: recorre el catálogo y compara los nombres sin distinguir mayúsculas y minúsculas.



Ambas búsquedas devuelven `null` cuando el libro no existe. Los préstamos por ISBN usan la búsqueda binaria, y el objeto encontrado es el mismo que aparece en el catálogo principal.

7\. Pruebas



\- \*\*Préstamos (Día 3)\*\*: tres préstamos simulados. Dos sobre "Cien años de soledad" y uno sobre "El principito". Después, un cuarto intento sobre "El principito" devuelve `False`.

\- \*\*Prueba de escritorio (Día 6)\*\*: catálogo antes y después de los préstamos, y el catálogo ordenado. Se documenta en `docs/prueba-escritorio.md`.

\- \*\*Búsquedas (Días 5 y 6)\*\*: un ISBN existente y uno inexistente por la búsqueda binaria; un título existente y uno inexistente por la búsqueda secuencial.



8\. Medición de comparaciones



Para cinco consultas se contaron las comparaciones de la búsqueda binaria propia y de `Array.BinarySearch`, este último con un comparador que suma cada llamada. Los resultados están en `docs/tabla-comparaciones.md` y coinciden en las cinco consultas. Con ocho títulos, la búsqueda necesita como máximo cuatro comparaciones, que es lo que se observó.



9\. Respuestas a las preguntas guía



Las respuestas completas están en `docs/tabla-comparaciones.md`. En resumen:



\- Si cada título tuviera cinco ejemplares, la búsqueda por ISBN no cambiaría, porque depende del número de títulos. Sí aumentaría el trabajo de disponibilidad y préstamo, porque habría que recorrer más ejemplares por título.

\- El ordenamiento por inserción preserva el orden alfabético entre empates porque es estable.

\- La búsqueda binaria exige ordenar por ISBN porque descarta mitades según el orden de la clave. Los préstamos cambian con cada operación y se repiten entre títulos, así que no sirven como clave de búsqueda.

\- El historial de commits muestra la evolución del diseño: un commit por día, con el paso de la estructura inicial a la integración final.



10\. Limitaciones y mejoras posibles



\- El catálogo se carga con datos fijos de prueba. Una versión completa leería los datos desde un archivo o una base de datos.

\- La copia ordenada por ISBN debe reconstruirse si cambian los títulos. Hoy se invalida en `CargarDatosDePrueba`.

\- La búsqueda por título es secuencial. Con muchos libros, un índice por nombre sería más eficiente.

\- No hay interfaz gráfica; toda la interacción es por consola.



Anexo: la salida completa del catálogo ordenado está en `docs/anexo-catalogo.md`.


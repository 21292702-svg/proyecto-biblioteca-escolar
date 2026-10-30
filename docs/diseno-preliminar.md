\# Diseño preliminar: representación de títulos con distinto número de ejemplares



\## Opción 1: arreglo escalonado (int\[]\[])

\- Pros: cada título tiene un arreglo de tamaño exacto, sin celdas vacías; acceso rápido por índice; uso de memoria ajustado.

\- Contras: el tamaño de la estructura externa es fijo, así que agregar títulos requiere crear un arreglo nuevo; el código es menos legible al manipularlo.



\## Opción 2: List<int\[]>

\- Pros: cada fila tiene tamaño propio, sin celdas vacías; la lista externa crece sola; acceso por índice rápido.

\- Contras: los datos de un título son solo números, así que no guarda el nombre ni el ISBN; hay que recordar qué significa cada posición.



\## Opción 3: List<Título>

\- Pros: cada título es un objeto con nombre, ISBN, lista de ejemplares y contador de préstamos; el código es claro y fácil de mantener; permite ordenar y buscar por cualquier campo.

\- Contras: mayor uso de memoria por los objetos; requiere diseñar la clase antes de empezar.



\## Decisión

Se elige List<Título>, porque el enunciado requiere ordenar por préstamos y buscar por ISBN, y un objeto por título hace esas operaciones directas y legibles.


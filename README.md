# Sistema de Biblioteca Universitaria

## Desafío Práctico Final

### Estudiantes

* José Javier Aguilar Amaya — Carné: AA261221
* Manuel de Jesús Mejía — Carné: MR260122

---

# Descripción del Proyecto

Sistema de Biblioteca Universitaria desarrollado en C# utilizando programación estructurada.

El sistema permite:

* Gestión de libros
* Gestión de usuarios
* Gestión de préstamos
* Registro de devoluciones
* Persistencia de datos mediante archivos `.csv` y `.txt`
* Validaciones de datos
* Reportes básicos

El proyecto cumple con los requerimientos solicitados:

* Uso de structs
* Uso de arreglos
* Menús interactivos
* switch-case
* do-while
* validaciones
* manejo de excepciones
* archivos de texto
* separación modular del sistema

---

# Tecnologías Utilizadas

* C#
* .NET 10.0
* Visual Studio 2022

---

# Estructura del Proyecto

```text
DesafioFinal_AA261221_MR260122/

├── SistemaManual/
│   ├── Data/
│   │   ├── libros.csv
│   │   ├── usuarios.txt
│   │   └── prestamos.txt
│   │
│   ├── Structs/
│   ├── Modulos/
│   ├── Utilidades/
│   │
│   ├── DatosGlobales.cs
│   └── Program.cs
│
├── SistemaIA/
│
└── README.md
```

---

# Instrucciones para Clonar y Ejecutar el Proyecto

## 1. Clonar repositorio

```bash
git clone https://github.com/joseaguilar769/DesafioFinal_AA261221_MR260122.git
```

---

## 2. Abrir solución

Abrir el archivo:

```text
DesafioFinal_AA261221_MR260122.slnx
```

en Visual Studio 2022.

---

## 3. Ejecutar el proyecto

Seleccionar:

```text
SistemaManual
```

como proyecto de inicio.

Luego ejecutar con:

```text
F5
```

o:

```text
Ctrl + F5
```

---

# Datos Registrados en el Sistema

## Libros registrados

| Código   | Título                   | Autor            | Cantidad |
| -------- | ------------------------ | ---------------- | -------- |
| LIB00001 | Arquitectura Limpia      | Robert C. Martin | 5        |
| LIB00002 | Introduccion a algoritmos| Thomas Cormen    | 3        |
| LIB00003 | Bases de Datos           | Elmasri          | 7        |
| LIB00004 | Redes de Computadoras    | Tanenbaum        | 5        |

---

## Usuarios registrados

| Carné    | Nombre           |
| -------- | ---------------- |
| 20240001 | Manuel Mejia     |
| 20240002 | Daniela Martínez |
| 20240003 | Kevin Ramírez    |
| 20240004 | Andrea López     |

---

# Datos de Prueba para el Docente

## Usuario disponible para registrar

```text
Carné: 20240005
Nombre Completo: Carlos Hernández
Carrera: Ingeniería Industrial
Correo: carlos.hernandez@correo.com
Teléfono: 77889966
```

---

## Libros disponibles para registrar

### Libro 1

```text
Código: LIB00005
Título: Inteligencia Artificial Moderna
Autor: Stuart Russell
Editorial: Pearson
Año: 2021
Categoría: Inteligencia Artificial
Cantidad: 6
```

### Libro 2

```text
Código: LIB00006
Título: Programación en C#
Autor: Microsoft Press
Editorial: McGraw Hill
Año: 2020
Categoría: Programación
Cantidad: 8
```

---

# Secuencia de Pruebas Recomendadas

## 1. Gestión de Libros

### Registrar Libro

Ruta:

```text
1 → 1
```

Ingresar datos de prueba de libros.

---

### Buscar Libro

Ruta:

```text
1 → 2
```

Buscar:

```text
LIB00001
```

---

### Listar Libros

Ruta:

```text
1 → 3
```

---

### Eliminar Libro

Ruta:

```text
1 → 4
```

Código:

```text
LIB00006
```

---

# 2. Gestión de Usuarios

## Registrar Usuario

Ruta:

```text
2 → 1
```

Ingresar usuario de prueba.

---

## Buscar Usuario por Carné

Ruta:

```text
2 → 2 → 1
```

Buscar:

```text
20240001
```

---

## Buscar Usuario por Nombre

Ruta:

```text
2 → 2 → 2
```

Buscar:

```text
Daniela
```

---

## Listar Usuarios

Ruta:

```text
2 → 3
```

---

# 3. Gestión de Préstamos

## Registrar Préstamo

Ruta:

```text
3 → 1
```

Datos:

```text
Carné: 20240001
Código Libro: LIB00001
```

---

## Historial Usuario

Ruta:

```text
3 → 3
```

Buscar:

```text
20240001
```

---

## Registrar Devolución

Ruta:

```text
3 → 2
```

Datos:

```text
Carné: 20240001
Código Libro: LIB00001
```

---

# Persistencia de Datos

El sistema almacena automáticamente la información en:

```text
SistemaManual/Data
```

Archivos utilizados:

* libros.csv
* usuarios.txt
* prestamos.txt

Los datos se cargan automáticamente al iniciar el sistema y se guardan al salir.

---

# Validaciones Implementadas

El sistema valida:

* Código de libro
* Carné de usuario
* Correos electrónicos
* Año de publicación
* Cantidad de libros
* Entradas numéricas
* Campos vacíos

---

# Video Demostrativo

Colocar aquí el enlace del video:

```text
PEGAR ENLACE DEL VIDEO AQUÍ
```

---

# Observaciones

* El sistema tiene límites definidos por arreglos:

  * 10 libros
  * 5 usuarios
  * 10 préstamos

* Los datos son persistentes mediante archivos.

* El sistema fue desarrollado con fines académicos.

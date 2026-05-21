using SistemaManual.Utilidades;
using System;

namespace SistemaManual.Modulos
{
    public static class Libros
    {
        public static void MenuLibros()
        {
            int opcion;

            do
            {
                Menus.MostrarMenuLibros();

                try
                {
                    opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            RegistrarLibro();
                            break;

                        case 2:
                            BuscarLibro();
                            break;

                        case 3:
                            ListarLibros();
                            break;

                        case 4:
                            EliminarLibro();
                            break;

                        case 5:
                            Console.WriteLine("Regresando...");
                            break;

                        default:
                            Console.WriteLine("Opción inválida");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Debe ingresar un número.");
                    opcion = 0;
                }

                Console.WriteLine("\nPresione una tecla...");
                Console.ReadKey();

            } while (opcion != 5);
        }

        public static void RegistrarLibro()
        {
            Console.Clear();

            if (DatosGlobales.totalLibros >= 10)
            {
                Console.WriteLine("No hay espacio para más libros.");
                return;
            }

            Structs.Libro nuevoLibro = new Structs.Libro();

            Console.Write("Código: ");
            nuevoLibro.Codigo = Console.ReadLine();

            if (!Validaciones.ValidarCodigoLibro(nuevoLibro.Codigo))
            {
                Console.WriteLine("Código inválido.");
                return;
            }

            Console.Write("Título: ");
            nuevoLibro.Titulo = Console.ReadLine();

            if (!Validaciones.ValidarTexto(nuevoLibro.Titulo))
            {
                Console.WriteLine("Título obligatorio.");
                return;
            }

            Console.Write("Autor: ");
            nuevoLibro.Autor = Console.ReadLine();

            Console.Write("Editorial: ");
            nuevoLibro.Editorial = Console.ReadLine();

            try
            {
                Console.Write("Año: ");
                nuevoLibro.Anio = Convert.ToInt32(Console.ReadLine());

                if (!Validaciones.ValidarAnio(nuevoLibro.Anio))
                {
                    Console.WriteLine("Año inválido.");
                    return;
                }
            }
            catch
            {
                Console.WriteLine("Error en año.");
                return;
            }

            Console.Write("Categoría: ");
            nuevoLibro.Categoria = Console.ReadLine();

            try
            {
                Console.Write("Cantidad: ");
                nuevoLibro.Cantidad = Convert.ToInt32(Console.ReadLine());

                if (!Validaciones.ValidarCantidad(nuevoLibro.Cantidad))
                {
                    Console.WriteLine("Cantidad inválida.");
                    return;
                }
            }
            catch
            {
                Console.WriteLine("Cantidad incorrecta.");
                return;
            }

            DatosGlobales.libros[DatosGlobales.totalLibros] = nuevoLibro;
            DatosGlobales.totalLibros++;

            Console.WriteLine("Libro registrado correctamente.");
        }

        public static void BuscarLibro()
        {
            Console.Clear();

            Console.Write("Ingrese código del libro: ");
            string codigo = Console.ReadLine();

            bool encontrado = false;

            for (int i = 0; i < DatosGlobales.totalLibros; i++)
            {
                if (DatosGlobales.libros[i].Codigo == codigo)
                {
                    Console.WriteLine("\nLibro encontrado:");
                    Console.WriteLine($"Código: {DatosGlobales.libros[i].Codigo}");
                    Console.WriteLine($"Título: {DatosGlobales.libros[i].Titulo}");
                    Console.WriteLine($"Autor: {DatosGlobales.libros[i].Autor}");
                    Console.WriteLine($"Cantidad: {DatosGlobales.libros[i].Cantidad}");

                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Libro no encontrado.");
            }
        }

        public static void ListarLibros()
        {
            Console.Clear();

            if (DatosGlobales.totalLibros == 0)
            {
                Console.WriteLine("No hay libros registrados.");
                return;
            }

            Console.WriteLine("===== LISTADO DE LIBROS =====");

            for (int i = 0; i < DatosGlobales.totalLibros; i++)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine($"Código: {DatosGlobales.libros[i].Codigo}");
                Console.WriteLine($"Título: {DatosGlobales.libros[i].Titulo}");
                Console.WriteLine($"Autor: {DatosGlobales.libros[i].Autor}");
                Console.WriteLine($"Cantidad: {DatosGlobales.libros[i].Cantidad}");
            }
        }

        public static void EliminarLibro()
        {
            Console.Clear();

            Console.Write("Ingrese código del libro a eliminar: ");
            string codigo = Console.ReadLine();

            bool eliminado = false;

            for (int i = 0; i < DatosGlobales.totalLibros; i++)
            {
                if (DatosGlobales.libros[i].Codigo == codigo)
                {
                    for (int j = i; j < DatosGlobales.totalLibros - 1; j++)
                    {
                        DatosGlobales.libros[j] = DatosGlobales.libros[j + 1];
                    }

                    DatosGlobales.totalLibros--;

                    eliminado = true;

                    Console.WriteLine("Libro eliminado.");
                    break;
                }
            }

            if (!eliminado)
            {
                Console.WriteLine("Libro no encontrado.");
            }
        }
    }
}
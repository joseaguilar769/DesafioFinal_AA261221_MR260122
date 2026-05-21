using SistemaManual.Utilidades;
using System;

namespace SistemaManual.Modulos
{
    public static class Prestamos
    {
        public static void MenuPrestamos()
        {
            int opcion;

            do
            {
                Menus.MostrarMenuPrestamos();

                try
                {
                    opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            RegistrarPrestamo();
                            break;

                        case 2:
                            RegistrarDevolucion();
                            break;

                        case 3:
                            HistorialUsuario();
                            break;

                        case 4:
                            ActualizarEstado();
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
                    Console.WriteLine("Error: debe ingresar un número.");
                    opcion = 0;
                }

                Console.WriteLine("\nPresione una tecla...");
                Console.ReadKey();

            } while (opcion != 5);
        }

        // -------------------------
        // REGISTRAR PRÉSTAMO
        // -------------------------
        public static void RegistrarPrestamo()
        {
            Console.Clear();

            if (DatosGlobales.totalPrestamos >= 10)
            {
                Console.WriteLine("No hay espacio para más préstamos.");
                return;
            }

            Console.Write("Carné del usuario: ");
            string carne = Console.ReadLine();

            Console.Write("Código del libro: ");
            string codigo = Console.ReadLine();

            int indexLibro = -1;
            int indexUsuario = -1;

            // Buscar libro
            for (int i = 0; i < DatosGlobales.totalLibros; i++)
            {
                if (DatosGlobales.libros[i].Codigo == codigo)
                {
                    indexLibro = i;
                    break;
                }
            }

            // Buscar usuario
            for (int i = 0; i < DatosGlobales.totalUsuarios; i++)
            {
                if (DatosGlobales.usuarios[i].Carne == carne)
                {
                    indexUsuario = i;
                    break;
                }
            }

            if (indexLibro == -1 || indexUsuario == -1)
            {
                Console.WriteLine("Usuario o libro no encontrado.");
                return;
            }

            if (DatosGlobales.libros[indexLibro].Cantidad <= 0)
            {
                Console.WriteLine("No hay libros disponibles.");
                return;
            }

            Structs.Prestamo p = new Structs.Prestamo();

            p.CarneUsuario = carne;
            p.CodigoLibro = codigo;
            p.FechaPrestamo = DateTime.Now.ToString("dd/MM/yyyy");
            p.FechaDevolucion = "Pendiente";
            p.Estado = "Activo";

            DatosGlobales.prestamos[DatosGlobales.totalPrestamos] = p;
            DatosGlobales.totalPrestamos++;

            DatosGlobales.libros[indexLibro].Cantidad--;

            Console.WriteLine("Préstamo registrado correctamente.");
        }

        // -------------------------
        // DEVOLUCIÓN
        // -------------------------
        public static void RegistrarDevolucion()
        {
            Console.Clear();

            Console.Write("Ingrese carné: ");
            string carne = Console.ReadLine();

            Console.Write("Ingrese código libro: ");
            string codigo = Console.ReadLine();

            bool encontrado = false;

            for (int i = 0; i < DatosGlobales.totalPrestamos; i++)
            {
                if (DatosGlobales.prestamos[i].CarneUsuario == carne &&
                    DatosGlobales.prestamos[i].CodigoLibro == codigo &&
                    DatosGlobales.prestamos[i].Estado == "Activo")
                {
                    DatosGlobales.prestamos[i].Estado = "Devuelto";
                    DatosGlobales.prestamos[i].FechaDevolucion = DateTime.Now.ToString("dd/MM/yyyy");

                    // devolver inventario
                    for (int j = 0; j < DatosGlobales.totalLibros; j++)
                    {
                        if (DatosGlobales.libros[j].Codigo == codigo)
                        {
                            DatosGlobales.libros[j].Cantidad++;
                            break;
                        }
                    }

                    Console.WriteLine("Devolución registrada correctamente.");
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Préstamo no encontrado.");
            }
        }

        // -------------------------
        // HISTORIAL
        // -------------------------
        public static void HistorialUsuario()
        {
            Console.Clear();

            Console.Write("Ingrese carné: ");
            string carne = Console.ReadLine();

            bool encontrado = false;

            for (int i = 0; i < DatosGlobales.totalPrestamos; i++)
            {
                if (DatosGlobales.prestamos[i].CarneUsuario == carne)
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine($"Libro: {DatosGlobales.prestamos[i].CodigoLibro}");
                    Console.WriteLine($"Fecha: {DatosGlobales.prestamos[i].FechaPrestamo}");
                    Console.WriteLine($"Estado: {DatosGlobales.prestamos[i].Estado}");
                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("No hay préstamos para este usuario.");
            }
        }

        // -------------------------
        // ACTUALIZAR ESTADO (extra académico)
        // -------------------------
        public static void ActualizarEstado()
        {
            Console.Clear();

            Console.WriteLine("Función administrativa en desarrollo...");
        }
    }
}
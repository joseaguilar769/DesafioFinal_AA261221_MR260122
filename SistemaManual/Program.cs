using SistemaManual.Utilidades;
using SistemaManual.Modulos;

namespace SistemaManual
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Menus.MostrarMenuPrincipal();

                try
                {
                    opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            Libros.MenuLibros();
                            break;

                        case 2:
                            Usuarios.MenuUsuarios();
                            break;

                        case 3:
                            Prestamos.MenuPrestamos();
                            break;

                        case 4:
                            Console.WriteLine("Saliendo del sistema...");
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

                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();

            } while (opcion != 4);
        }
    }
}
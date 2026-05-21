using SistemaManual.Utilidades;
using System;

namespace SistemaManual.Modulos
{
    public static class Usuarios
    {
        public static void MenuUsuarios()
        {
            int opcion;

            do
            {
                Menus.MostrarMenuUsuarios();

                try
                {
                    opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            RegistrarUsuario();
                            break;

                        case 2:
                            BuscarUsuario();
                            break;

                        case 3:
                            ListarUsuarios();
                            break;

                        case 4:
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

            } while (opcion != 4);
        }

        public static void RegistrarUsuario()
        {
            Console.Clear();

            if (DatosGlobales.totalUsuarios >= 5)
            {
                Console.WriteLine("No hay espacio para más usuarios.");
                return;
            }

            Structs.Usuario nuevoUsuario = new Structs.Usuario();

            Console.Write("Carné: ");
            nuevoUsuario.Carne = Console.ReadLine();

            if (!Validaciones.ValidarCarne(nuevoUsuario.Carne))
            {
                Console.WriteLine("Carné inválido.");
                return;
            }

            Console.Write("Nombre Completo: ");
            nuevoUsuario.NombreCompleto = Console.ReadLine();

            if (!Validaciones.ValidarTexto(nuevoUsuario.NombreCompleto))
            {
                Console.WriteLine("Nombre obligatorio.");
                return;
            }

            Console.Write("Carrera: ");
            nuevoUsuario.Carrera = Console.ReadLine();

            Console.Write("Correo: ");
            nuevoUsuario.Correo = Console.ReadLine();

            if (!Validaciones.ValidarCorreo(nuevoUsuario.Correo))
            {
                Console.WriteLine("Correo inválido.");
                return;
            }

            Console.Write("Teléfono: ");
            nuevoUsuario.Telefono = Console.ReadLine();

            nuevoUsuario.Estado = "Activo";

            DatosGlobales.usuarios[DatosGlobales.totalUsuarios] = nuevoUsuario;
            DatosGlobales.totalUsuarios++;

            Console.WriteLine("Usuario registrado correctamente.");
        }

        public static void BuscarUsuario()
        {
            Console.Clear();

            Console.WriteLine("1. Buscar por Carné");
            Console.WriteLine("2. Buscar por Nombre");
            Console.Write("Seleccione opción: ");

            int opcion = Convert.ToInt32(Console.ReadLine());

            bool encontrado = false;

            switch (opcion)
            {
                case 1:

                    Console.Write("Ingrese carné: ");
                    string carne = Console.ReadLine();

                    int i = 0;

                    while (i < DatosGlobales.totalUsuarios)
                    {
                        if (DatosGlobales.usuarios[i].Carne == carne)
                        {
                            MostrarUsuario(i);
                            encontrado = true;
                            break;
                        }

                        i++;
                    }

                    break;

                case 2:

                    Console.Write("Ingrese nombre: ");
                    string nombre = Console.ReadLine().ToLower();

                    for (int j = 0; j < DatosGlobales.totalUsuarios; j++)
                    {
                        if (DatosGlobales.usuarios[j].NombreCompleto.ToLower().Contains(nombre))
                        {
                            MostrarUsuario(j);
                            encontrado = true;
                        }
                    }

                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

            if (!encontrado)
            {
                Console.WriteLine("Usuario no encontrado.");
            }
        }

        public static void MostrarUsuario(int indice)
        {
            Console.WriteLine("\n===== USUARIO =====");
            Console.WriteLine($"Carné: {DatosGlobales.usuarios[indice].Carne}");
            Console.WriteLine($"Nombre: {DatosGlobales.usuarios[indice].NombreCompleto}");
            Console.WriteLine($"Carrera: {DatosGlobales.usuarios[indice].Carrera}");
            Console.WriteLine($"Correo: {DatosGlobales.usuarios[indice].Correo}");
            Console.WriteLine($"Estado: {DatosGlobales.usuarios[indice].Estado}");
        }

        public static void ListarUsuarios()
        {
            Console.Clear();

            if (DatosGlobales.totalUsuarios == 0)
            {
                Console.WriteLine("No hay usuarios registrados.");
                return;
            }

            Console.WriteLine("===== LISTADO USUARIOS =====");

            for (int i = 0; i < DatosGlobales.totalUsuarios; i++)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine($"Carné: {DatosGlobales.usuarios[i].Carne}");
                Console.WriteLine($"Nombre: {DatosGlobales.usuarios[i].NombreCompleto}");
                Console.WriteLine($"Carrera: {DatosGlobales.usuarios[i].Carrera}");
                Console.WriteLine($"Correo: {DatosGlobales.usuarios[i].Correo}");
            }
        }
    }
}
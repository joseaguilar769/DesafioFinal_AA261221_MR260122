using System;

namespace SistemaManual.Utilidades
{
    public static class Menus
    {
        public static void MostrarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine("=======================================");
            Console.WriteLine(" SISTEMA DE BIBLIOTECA UNIVERSITARIA");
            Console.WriteLine("=======================================");
            Console.WriteLine("1. Gestión de Libros");
            Console.WriteLine("2. Gestión de Usuarios");
            Console.WriteLine("3. Gestión de Préstamos");
            Console.WriteLine("4. Salir");
            Console.WriteLine("=======================================");
            Console.Write("Seleccione una opción: ");
        }

        public static void MostrarMenuLibros()
        {
            Console.Clear();

            Console.WriteLine("========== GESTIÓN LIBROS ==========");
            Console.WriteLine("1. Registrar Libro");
            Console.WriteLine("2. Buscar Libro");
            Console.WriteLine("3. Listar Libros");
            Console.WriteLine("4. Eliminar Libro");
            Console.WriteLine("5. Regresar");
            Console.WriteLine("====================================");
            Console.Write("Seleccione una opción: ");
        }

        public static void MostrarMenuUsuarios()
        {
            Console.Clear();

            Console.WriteLine("========= GESTIÓN USUARIOS =========");
            Console.WriteLine("1. Registrar Usuario");
            Console.WriteLine("2. Buscar Usuario");
            Console.WriteLine("3. Listar Usuarios");
            Console.WriteLine("4. Regresar");
            Console.WriteLine("====================================");
            Console.Write("Seleccione una opción: ");
        }

        public static void MostrarMenuPrestamos()
        {
            Console.Clear();

            Console.WriteLine("======== GESTIÓN PRÉSTAMOS =========");
            Console.WriteLine("1. Registrar Préstamo");
            Console.WriteLine("2. Registrar Devolución");
            Console.WriteLine("3. Historial Usuario");
            Console.WriteLine("4. Actualizar Estado");
            Console.WriteLine("5. Regresar");
            Console.WriteLine("====================================");
            Console.Write("Seleccione una opción: ");
        }
    }
}

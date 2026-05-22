using SistemaManual.Structs;
using System;
using System.IO;

namespace SistemaManual.Utilidades
{
    public static class Archivos
    {
        private static string rutaLibros = "Data/libros.csv";
        private static string rutaUsuarios = "Data/usuarios.txt";
        private static string rutaPrestamos = "Data/prestamos.txt";

        // -------------------------
        // CARGAR DATOS
        // -------------------------
        public static void CargarDatos()
        {
            CargarLibros();
            CargarUsuarios();
            CargarPrestamos();
        }

        // -------------------------
        // GUARDAR DATOS
        // -------------------------
        public static void GuardarDatos()
        {
            GuardarLibros();
            GuardarUsuarios();
            GuardarPrestamos();
        }

        // -------------------------
        // LIBROS CSV
        // -------------------------
        public static void GuardarLibros()
        {
            using (StreamWriter sw = new StreamWriter(rutaLibros))
            {
                for (int i = 0; i < DatosGlobales.totalLibros; i++)
                {
                    Libro l = DatosGlobales.libros[i];

                    sw.WriteLine($"{l.Codigo},{l.Titulo},{l.Autor},{l.Editorial},{l.Anio},{l.Categoria},{l.Cantidad}");
                }
            }
        }

        public static void CargarLibros()
        {
            if (!File.Exists(rutaLibros)) return;

            string[] lineas = File.ReadAllLines(rutaLibros);

            foreach (string linea in lineas)
            {
                string[] datos = linea.Split(',');

                Libro l = new Libro();

                l.Codigo = datos[0];
                l.Titulo = datos[1];
                l.Autor = datos[2];
                l.Editorial = datos[3];
                l.Anio = int.Parse(datos[4]);
                l.Categoria = datos[5];
                l.Cantidad = int.Parse(datos[6]);

                DatosGlobales.libros[DatosGlobales.totalLibros++] = l;
            }
        }

        // -------------------------
        // USUARIOS TXT
        // -------------------------
        public static void GuardarUsuarios()
        {
            using (StreamWriter sw = new StreamWriter(rutaUsuarios))
            {
                for (int i = 0; i < DatosGlobales.totalUsuarios; i++)
                {
                    Usuario u = DatosGlobales.usuarios[i];

                    sw.WriteLine($"{u.Carne}|{u.NombreCompleto}|{u.Carrera}|{u.Correo}|{u.Telefono}|{u.Estado}");
                }
            }
        }

        public static void CargarUsuarios()
        {
            if (!File.Exists(rutaUsuarios)) return;

            string[] lineas = File.ReadAllLines(rutaUsuarios);

            foreach (string linea in lineas)
            {
                string[] d = linea.Split('|');

                Usuario u = new Usuario();

                u.Carne = d[0];
                u.NombreCompleto = d[1];
                u.Carrera = d[2];
                u.Correo = d[3];
                u.Telefono = d[4];
                u.Estado = d[5];

                DatosGlobales.usuarios[DatosGlobales.totalUsuarios++] = u;
            }
        }

        // -------------------------
        // PRÉSTAMOS TXT
        // -------------------------
        public static void GuardarPrestamos()
        {
            using (StreamWriter sw = new StreamWriter(rutaPrestamos))
            {
                for (int i = 0; i < DatosGlobales.totalPrestamos; i++)
                {
                    Prestamo p = DatosGlobales.prestamos[i];

                    sw.WriteLine($"{p.CarneUsuario}|{p.CodigoLibro}|{p.FechaPrestamo}|{p.FechaDevolucion}|{p.Estado}");
                }
            }
        }

        public static void CargarPrestamos()
        {
            if (!File.Exists(rutaPrestamos)) return;

            string[] lineas = File.ReadAllLines(rutaPrestamos);

            foreach (string linea in lineas)
            {
                string[] d = linea.Split('|');

                Prestamo p = new Prestamo();

                p.CarneUsuario = d[0];
                p.CodigoLibro = d[1];
                p.FechaPrestamo = d[2];
                p.FechaDevolucion = d[3];
                p.Estado = d[4];

                DatosGlobales.prestamos[DatosGlobales.totalPrestamos++] = p;
            }
        }

        // -------------------------
        // MATRIZ OBLIGATORIA (REPORTE)
        // -------------------------
        public static void ReportePrestamosPorMes()
        {
            int[,] matriz = new int[12, 2];

            for (int i = 0; i < DatosGlobales.totalPrestamos; i++)
            {
                Prestamo p = DatosGlobales.prestamos[i];

                string mesTexto = p.FechaPrestamo.Split('/')[1];
                int mes = int.Parse(mesTexto) - 1;

                matriz[mes, 0]++; // préstamos activos + total
            }

            Console.WriteLine("=== REPORTE POR MES ===");

            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine($"Mes {i + 1}: {matriz[i, 0]} préstamos");
            }
        }
    }
}

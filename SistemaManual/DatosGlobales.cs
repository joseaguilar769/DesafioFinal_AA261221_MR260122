using SistemaManual.Structs;

namespace SistemaManual
{
    public static class DatosGlobales
    {
        public static Libro[] libros = new Libro[10];
        public static Usuario[] usuarios = new Usuario[5];
        public static Prestamo[] prestamos = new Prestamo[10];

        public static int totalLibros = 0;
        public static int totalUsuarios = 0;
        public static int totalPrestamos = 0;
    }
}
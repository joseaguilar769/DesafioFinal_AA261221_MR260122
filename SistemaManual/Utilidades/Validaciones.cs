using System;

namespace SistemaManual.Utilidades
{
    public static class Validaciones
    {
        public static bool ValidarCodigoLibro(string codigo)
        {
            return !string.IsNullOrWhiteSpace(codigo)
                && codigo.Length == 8;
        }

        public static bool ValidarTexto(string texto)
        {
            return !string.IsNullOrWhiteSpace(texto);
        }

        public static bool ValidarAnio(int anio)
        {
            return anio >= 1900 && anio <= DateTime.Now.Year;
        }

        public static bool ValidarCantidad(int cantidad)
        {
            return cantidad >= 0;
        }
    }
}

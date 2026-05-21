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

        public static bool ValidarCarne(string carne)
        {
            if (string.IsNullOrWhiteSpace(carne))
            {
                return false;
            }

            if (carne.Length != 8)
            {
                return false;
            }

            foreach (char c in carne)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ValidarCorreo(string correo)
        {
            if (string.IsNullOrWhiteSpace(correo))
            {
                return false;
            }

            int posicionArroba = correo.IndexOf('@');
            int posicionPunto = correo.LastIndexOf('.');

            return posicionArroba > 0 && posicionPunto > posicionArroba;
        }
    }
}

using System;

// ============================================================
//   SISTEMA DE BIBLIOTECA - Aplicación de Consola en C#
//   Archivo único: Program.cs
// ============================================================

// ──────────────────────────────────────────────────────────
// STRUCTS
// ──────────────────────────────────────────────────────────

struct Libro
{
    public int Id;
    public string Titulo;
    public string Autor;
    public string ISBN;
    public int AnyoPublicacion;
    public bool Disponible;
}

struct Usuario
{
    public int Id;
    public string Nombre;
    public string Apellido;
    public string Email;
    public string Telefono;
    public bool Activo;
}

struct Prestamo
{
    public int Id;
    public int LibroId;
    public int UsuarioId;
    public DateTime FechaPrestamo;
    public DateTime FechaDevolucionEsperada;
    public DateTime FechaDevolucionReal;
    public bool Devuelto;
}

// ──────────────────────────────────────────────────────────
// PROGRAMA PRINCIPAL
// ──────────────────────────────────────────────────────────

class Program
{
    // Arreglos de datos y contadores
    static Libro[] libros = new Libro[100];
    static Usuario[] usuarios = new Usuario[100];
    static Prestamo[] prestamos = new Prestamo[200];

    static int totalLibros = 0;
    static int totalUsuarios = 0;
    static int totalPrestamos = 0;

    // Contadores de IDs auto-incrementales
    static int nextLibroId = 1;
    static int nextUsuarioId = 1;
    static int nextPrestamoId = 1;

    // ──────────────────────────────────────────────────────
    // PUNTO DE ENTRADA
    // ──────────────────────────────────────────────────────
    static void Main(string[] args)
    {
        CargarDatosEjemplo();
        bool salir = false;

        while (!salir)
        {
            MostrarMenuPrincipal();
            string opcion = Console.ReadLine()?.Trim() ?? "";

            switch (opcion)
            {
                case "1": MenuLibros(); break;
                case "2": MenuUsuarios(); break;
                case "3": MenuPrestamos(); break;
                case "4": MenuReportes(); break;
                case "5": salir = true; break;
                default:
                    MostrarError("Opción inválida. Intente de nuevo.");
                    break;
            }
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n¡Hasta luego! El sistema de biblioteca se ha cerrado.\n");
        Console.ResetColor();
    }

    // ──────────────────────────────────────────────────────
    // MENÚS
    // ──────────────────────────────────────────────────────

    static void MostrarMenuPrincipal()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔══════════════════════════════════════════╗");
        Console.WriteLine("║       SISTEMA DE GESTIÓN DE BIBLIOTECA   ║");
        Console.WriteLine("╚══════════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("  [1] 📚  Gestión de Libros");
        Console.WriteLine("  [2] 👤  Gestión de Usuarios");
        Console.WriteLine("  [3] 🔄  Gestión de Préstamos");
        Console.WriteLine("  [4] 📊  Reportes");
        Console.WriteLine("  [5] 🚪  Salir");
        Console.WriteLine();
        Console.Write("  Seleccione una opción: ");
    }

    static void MenuLibros()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║            GESTIÓN DE LIBROS             ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("  [1] Registrar nuevo libro");
            Console.WriteLine("  [2] Listar todos los libros");
            Console.WriteLine("  [3] Buscar libro por título");
            Console.WriteLine("  [4] Buscar libro por ID");
            Console.WriteLine("  [5] Editar libro");
            Console.WriteLine("  [6] Eliminar libro");
            Console.WriteLine("  [0] Volver al menú principal");
            Console.WriteLine();
            Console.Write("  Seleccione una opción: ");

            string op = Console.ReadLine()?.Trim() ?? "";
            switch (op)
            {
                case "1": RegistrarLibro(); break;
                case "2": ListarLibros(); break;
                case "3": BuscarLibroPorTitulo(); break;
                case "4": BuscarLibroPorId(); break;
                case "5": EditarLibro(); break;
                case "6": EliminarLibro(); break;
                case "0": volver = true; break;
                default: MostrarError("Opción inválida."); break;
            }
        }
    }

    static void MenuUsuarios()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║           GESTIÓN DE USUARIOS            ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("  [1] Registrar nuevo usuario");
            Console.WriteLine("  [2] Listar todos los usuarios");
            Console.WriteLine("  [3] Buscar usuario por nombre");
            Console.WriteLine("  [4] Buscar usuario por ID");
            Console.WriteLine("  [5] Editar usuario");
            Console.WriteLine("  [6] Desactivar usuario");
            Console.WriteLine("  [0] Volver al menú principal");
            Console.WriteLine();
            Console.Write("  Seleccione una opción: ");

            string op = Console.ReadLine()?.Trim() ?? "";
            switch (op)
            {
                case "1": RegistrarUsuario(); break;
                case "2": ListarUsuarios(); break;
                case "3": BuscarUsuarioPorNombre(); break;
                case "4": BuscarUsuarioPorId(); break;
                case "5": EditarUsuario(); break;
                case "6": DesactivarUsuario(); break;
                case "0": volver = true; break;
                default: MostrarError("Opción inválida."); break;
            }
        }
    }

    static void MenuPrestamos()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║          GESTIÓN DE PRÉSTAMOS            ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("  [1] Registrar nuevo préstamo");
            Console.WriteLine("  [2] Registrar devolución");
            Console.WriteLine("  [3] Listar todos los préstamos");
            Console.WriteLine("  [4] Ver préstamos activos");
            Console.WriteLine("  [5] Ver préstamos vencidos");
            Console.WriteLine("  [6] Historial por usuario");
            Console.WriteLine("  [0] Volver al menú principal");
            Console.WriteLine();
            Console.Write("  Seleccione una opción: ");

            string op = Console.ReadLine()?.Trim() ?? "";
            switch (op)
            {
                case "1": RegistrarPrestamo(); break;
                case "2": RegistrarDevolucion(); break;
                case "3": ListarPrestamos(); break;
                case "4": ListarPrestamosActivos(); break;
                case "5": ListarPrestamosVencidos(); break;
                case "6": HistorialPorUsuario(); break;
                case "0": volver = true; break;
                default: MostrarError("Opción inválida."); break;
            }
        }
    }

    static void MenuReportes()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║                REPORTES                  ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("  [1] Resumen general del sistema");
            Console.WriteLine("  [2] Libros disponibles");
            Console.WriteLine("  [3] Libros prestados actualmente");
            Console.WriteLine("  [0] Volver al menú principal");
            Console.WriteLine();
            Console.Write("  Seleccione una opción: ");

            string op = Console.ReadLine()?.Trim() ?? "";
            switch (op)
            {
                case "1": ResumenGeneral(); break;
                case "2": ReporteDisponibles(); break;
                case "3": ReportePrestados(); break;
                case "0": volver = true; break;
                default: MostrarError("Opción inválida."); break;
            }
        }
    }

    // ──────────────────────────────────────────────────────
    // OPERACIONES DE LIBROS
    // ──────────────────────────────────────────────────────

    static void RegistrarLibro()
    {
        Console.Clear();
        Encabezado("REGISTRAR NUEVO LIBRO");

        if (totalLibros >= libros.Length)
        {
            MostrarError("No hay espacio para más libros.");
            return;
        }

        Libro l = new Libro();
        l.Id = nextLibroId++;

        Console.Write("  Título          : ");
        l.Titulo = Console.ReadLine() ?? "";

        Console.Write("  Autor           : ");
        l.Autor = Console.ReadLine() ?? "";

        Console.Write("  ISBN            : ");
        l.ISBN = Console.ReadLine() ?? "";

        Console.Write("  Año publicación : ");
        int.TryParse(Console.ReadLine(), out l.AnyoPublicacion);

        l.Disponible = true;

        libros[totalLibros] = l;
        totalLibros++;

        MostrarExito($"Libro registrado con ID #{l.Id}.");
    }

    static void ListarLibros()
    {
        Console.Clear();
        Encabezado("LISTADO DE LIBROS");

        if (totalLibros == 0) { MostrarError("No hay libros registrados."); return; }

        Console.WriteLine($"  {"ID",-5} {"Título",-30} {"Autor",-20} {"Año",-6} {"Estado",-12}");
        Console.WriteLine(new string('─', 78));

        for (int i = 0; i < totalLibros; i++)
        {
            Libro l = libros[i];
            string estado = l.Disponible ? "Disponible" : "Prestado";
            ConsoleColor col = l.Disponible ? ConsoleColor.Green : ConsoleColor.Red;

            Console.Write($"  {l.Id,-5} {l.Titulo,-30} {l.Autor,-20} {l.AnyoPublicacion,-6} ");
            Console.ForegroundColor = col;
            Console.WriteLine(estado);
            Console.ResetColor();
        }

        Pausa();
    }

    static void BuscarLibroPorTitulo()
    {
        Console.Clear();
        Encabezado("BUSCAR LIBRO POR TÍTULO");
        Console.Write("  Ingrese texto a buscar: ");
        string texto = (Console.ReadLine() ?? "").ToLower();

        bool encontrado = false;
        for (int i = 0; i < totalLibros; i++)
        {
            if (libros[i].Titulo.ToLower().Contains(texto))
            {
                if (!encontrado) { Console.WriteLine(); encontrado = true; }
                MostrarDetalleLibro(libros[i]);
            }
        }

        if (!encontrado) MostrarError("No se encontraron libros con ese título.");
        Pausa();
    }

    static void BuscarLibroPorId()
    {
        Console.Clear();
        Encabezado("BUSCAR LIBRO POR ID");
        Console.Write("  Ingrese ID del libro: ");
        int.TryParse(Console.ReadLine(), out int id);

        int idx = EncontrarLibro(id);
        if (idx == -1) { MostrarError("Libro no encontrado."); Pausa(); return; }

        MostrarDetalleLibro(libros[idx]);
        Pausa();
    }

    static void EditarLibro()
    {
        Console.Clear();
        Encabezado("EDITAR LIBRO");
        Console.Write("  Ingrese ID del libro a editar: ");
        int.TryParse(Console.ReadLine(), out int id);

        int idx = EncontrarLibro(id);
        if (idx == -1) { MostrarError("Libro no encontrado."); Pausa(); return; }

        Libro l = libros[idx];
        Console.WriteLine($"\n  Libro actual: {l.Titulo} — {l.Autor}");
        Console.WriteLine("  (Deje en blanco para mantener el valor actual)\n");

        Console.Write($"  Nuevo título [{l.Titulo}]: ");
        string nuevoTitulo = Console.ReadLine() ?? "";
        if (nuevoTitulo != "") l.Titulo = nuevoTitulo;

        Console.Write($"  Nuevo autor [{l.Autor}]: ");
        string nuevoAutor = Console.ReadLine() ?? "";
        if (nuevoAutor != "") l.Autor = nuevoAutor;

        Console.Write($"  Nuevo ISBN [{l.ISBN}]: ");
        string nuevoISBN = Console.ReadLine() ?? "";
        if (nuevoISBN != "") l.ISBN = nuevoISBN;

        Console.Write($"  Nuevo año [{l.AnyoPublicacion}]: ");
        string anyoStr = Console.ReadLine() ?? "";
        if (anyoStr != "") int.TryParse(anyoStr, out l.AnyoPublicacion);

        libros[idx] = l;
        MostrarExito("Libro actualizado correctamente.");
    }

    static void EliminarLibro()
    {
        Console.Clear();
        Encabezado("ELIMINAR LIBRO");
        Console.Write("  Ingrese ID del libro a eliminar: ");
        int.TryParse(Console.ReadLine(), out int id);

        int idx = EncontrarLibro(id);
        if (idx == -1) { MostrarError("Libro no encontrado."); Pausa(); return; }

        if (!libros[idx].Disponible)
        {
            MostrarError("No se puede eliminar un libro que está prestado.");
            Pausa(); return;
        }

        Console.Write($"\n  ¿Eliminar \"{libros[idx].Titulo}\"? (s/n): ");
        if ((Console.ReadLine() ?? "").ToLower() != "s") { Console.WriteLine("  Cancelado."); Pausa(); return; }

        // Desplazar arreglo
        for (int i = idx; i < totalLibros - 1; i++)
            libros[i] = libros[i + 1];
        totalLibros--;

        MostrarExito("Libro eliminado correctamente.");
    }

    // ──────────────────────────────────────────────────────
    // OPERACIONES DE USUARIOS
    // ──────────────────────────────────────────────────────

    static void RegistrarUsuario()
    {
        Console.Clear();
        Encabezado("REGISTRAR NUEVO USUARIO");

        if (totalUsuarios >= usuarios.Length) { MostrarError("No hay espacio para más usuarios."); return; }

        Usuario u = new Usuario();
        u.Id = nextUsuarioId++;

        Console.Write("  Nombre    : ");
        u.Nombre = Console.ReadLine() ?? "";

        Console.Write("  Apellido  : ");
        u.Apellido = Console.ReadLine() ?? "";

        Console.Write("  Email     : ");
        u.Email = Console.ReadLine() ?? "";

        Console.Write("  Teléfono  : ");
        u.Telefono = Console.ReadLine() ?? "";

        u.Activo = true;

        usuarios[totalUsuarios] = u;
        totalUsuarios++;

        MostrarExito($"Usuario registrado con ID #{u.Id}.");
    }

    static void ListarUsuarios()
    {
        Console.Clear();
        Encabezado("LISTADO DE USUARIOS");

        if (totalUsuarios == 0) { MostrarError("No hay usuarios registrados."); return; }

        Console.WriteLine($"  {"ID",-5} {"Nombre",-20} {"Apellido",-20} {"Email",-25} {"Estado",-10}");
        Console.WriteLine(new string('─', 84));

        for (int i = 0; i < totalUsuarios; i++)
        {
            Usuario u = usuarios[i];
            string estado = u.Activo ? "Activo" : "Inactivo";
            ConsoleColor col = u.Activo ? ConsoleColor.Green : ConsoleColor.DarkGray;

            Console.Write($"  {u.Id,-5} {u.Nombre,-20} {u.Apellido,-20} {u.Email,-25} ");
            Console.ForegroundColor = col;
            Console.WriteLine(estado);
            Console.ResetColor();
        }

        Pausa();
    }

    static void BuscarUsuarioPorNombre()
    {
        Console.Clear();
        Encabezado("BUSCAR USUARIO POR NOMBRE");
        Console.Write("  Ingrese nombre o apellido: ");
        string texto = (Console.ReadLine() ?? "").ToLower();

        bool encontrado = false;
        for (int i = 0; i < totalUsuarios; i++)
        {
            Usuario u = usuarios[i];
            if (u.Nombre.ToLower().Contains(texto) || u.Apellido.ToLower().Contains(texto))
            {
                if (!encontrado) { Console.WriteLine(); encontrado = true; }
                MostrarDetalleUsuario(u);
            }
        }

        if (!encontrado) MostrarError("No se encontraron usuarios con ese nombre.");
        Pausa();
    }

    static void BuscarUsuarioPorId()
    {
        Console.Clear();
        Encabezado("BUSCAR USUARIO POR ID");
        Console.Write("  Ingrese ID del usuario: ");
        int.TryParse(Console.ReadLine(), out int id);

        int idx = EncontrarUsuario(id);
        if (idx == -1) { MostrarError("Usuario no encontrado."); Pausa(); return; }

        MostrarDetalleUsuario(usuarios[idx]);
        Pausa();
    }

    static void EditarUsuario()
    {
        Console.Clear();
        Encabezado("EDITAR USUARIO");
        Console.Write("  Ingrese ID del usuario a editar: ");
        int.TryParse(Console.ReadLine(), out int id);

        int idx = EncontrarUsuario(id);
        if (idx == -1) { MostrarError("Usuario no encontrado."); Pausa(); return; }

        Usuario u = usuarios[idx];
        Console.WriteLine($"\n  Usuario actual: {u.Nombre} {u.Apellido}");
        Console.WriteLine("  (Deje en blanco para mantener el valor actual)\n");

        Console.Write($"  Nuevo nombre [{u.Nombre}]: ");
        string v = Console.ReadLine() ?? "";
        if (v != "") u.Nombre = v;

        Console.Write($"  Nuevo apellido [{u.Apellido}]: ");
        v = Console.ReadLine() ?? "";
        if (v != "") u.Apellido = v;

        Console.Write($"  Nuevo email [{u.Email}]: ");
        v = Console.ReadLine() ?? "";
        if (v != "") u.Email = v;

        Console.Write($"  Nuevo teléfono [{u.Telefono}]: ");
        v = Console.ReadLine() ?? "";
        if (v != "") u.Telefono = v;

        usuarios[idx] = u;
        MostrarExito("Usuario actualizado correctamente.");
    }

    static void DesactivarUsuario()
    {
        Console.Clear();
        Encabezado("DESACTIVAR USUARIO");
        Console.Write("  Ingrese ID del usuario a desactivar: ");
        int.TryParse(Console.ReadLine(), out int id);

        int idx = EncontrarUsuario(id);
        if (idx == -1) { MostrarError("Usuario no encontrado."); Pausa(); return; }

        // Verificar préstamos activos
        for (int i = 0; i < totalPrestamos; i++)
        {
            if (prestamos[i].UsuarioId == id && !prestamos[i].Devuelto)
            {
                MostrarError("El usuario tiene préstamos activos y no puede desactivarse.");
                Pausa(); return;
            }
        }

        Console.Write($"\n  ¿Desactivar a {usuarios[idx].Nombre} {usuarios[idx].Apellido}? (s/n): ");
        if ((Console.ReadLine() ?? "").ToLower() != "s") { Console.WriteLine("  Cancelado."); Pausa(); return; }

        Usuario u = usuarios[idx];
        u.Activo = false;
        usuarios[idx] = u;

        MostrarExito("Usuario desactivado correctamente.");
    }

    // ──────────────────────────────────────────────────────
    // OPERACIONES DE PRÉSTAMOS
    // ──────────────────────────────────────────────────────

    static void RegistrarPrestamo()
    {
        Console.Clear();
        Encabezado("REGISTRAR NUEVO PRÉSTAMO");

        if (totalPrestamos >= prestamos.Length) { MostrarError("No hay espacio para más préstamos."); return; }

        // Seleccionar usuario
        Console.Write("  ID del usuario   : ");
        int.TryParse(Console.ReadLine(), out int usuarioId);
        int idxU = EncontrarUsuario(usuarioId);
        if (idxU == -1) { MostrarError("Usuario no encontrado."); Pausa(); return; }
        if (!usuarios[idxU].Activo) { MostrarError("El usuario está inactivo."); Pausa(); return; }

        // Seleccionar libro
        Console.Write("  ID del libro     : ");
        int.TryParse(Console.ReadLine(), out int libroId);
        int idxL = EncontrarLibro(libroId);
        if (idxL == -1) { MostrarError("Libro no encontrado."); Pausa(); return; }
        if (!libros[idxL].Disponible) { MostrarError("El libro no está disponible."); Pausa(); return; }

        // Días del préstamo
        Console.Write("  Días de préstamo [14]: ");
        string diasStr = Console.ReadLine() ?? "";
        int dias = diasStr == "" ? 14 : int.Parse(diasStr);

        // Crear préstamo
        Prestamo p = new Prestamo();
        p.Id = nextPrestamoId++;
        p.LibroId = libroId;
        p.UsuarioId = usuarioId;
        p.FechaPrestamo = DateTime.Now;
        p.FechaDevolucionEsperada = DateTime.Now.AddDays(dias);
        p.Devuelto = false;

        prestamos[totalPrestamos] = p;
        totalPrestamos++;

        // Marcar libro como no disponible
        Libro lb = libros[idxL];
        lb.Disponible = false;
        libros[idxL] = lb;

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"  ✔ Préstamo #{p.Id} registrado:");
        Console.WriteLine($"    Usuario  : {usuarios[idxU].Nombre} {usuarios[idxU].Apellido}");
        Console.WriteLine($"    Libro    : {libros[idxL].Titulo}");
        Console.WriteLine($"    Préstamo : {p.FechaPrestamo:dd/MM/yyyy}");
        Console.WriteLine($"    Devolver : {p.FechaDevolucionEsperada:dd/MM/yyyy}");
        Console.ResetColor();

        Pausa();
    }

    static void RegistrarDevolucion()
    {
        Console.Clear();
        Encabezado("REGISTRAR DEVOLUCIÓN");
        Console.Write("  ID del préstamo a cerrar: ");
        int.TryParse(Console.ReadLine(), out int prestamoId);

        int idxP = EncontrarPrestamo(prestamoId);
        if (idxP == -1) { MostrarError("Préstamo no encontrado."); Pausa(); return; }
        if (prestamos[idxP].Devuelto) { MostrarError("Este préstamo ya fue devuelto."); Pausa(); return; }

        Prestamo p = prestamos[idxP];
        p.FechaDevolucionReal = DateTime.Now;
        p.Devuelto = true;
        prestamos[idxP] = p;

        // Liberar el libro
        int idxL = EncontrarLibro(p.LibroId);
        if (idxL != -1)
        {
            Libro lb = libros[idxL];
            lb.Disponible = true;
            libros[idxL] = lb;
        }

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;

        bool tardio = p.FechaDevolucionReal > p.FechaDevolucionEsperada;
        if (tardio)
        {
            int diasRetraso = (p.FechaDevolucionReal - p.FechaDevolucionEsperada).Days;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  ⚠ Devolución registrada con {diasRetraso} día(s) de retraso.");
        }
        else
        {
            Console.WriteLine("  ✔ Devolución registrada correctamente. ¡A tiempo!");
        }

        Console.ResetColor();
        Pausa();
    }

    static void ListarPrestamos()
    {
        Console.Clear();
        Encabezado("TODOS LOS PRÉSTAMOS");

        if (totalPrestamos == 0) { MostrarError("No hay préstamos registrados."); Pausa(); return; }

        Console.WriteLine($"  {"ID",-5} {"LibroID",-8} {"UsuarioID",-10} {"Fecha Prést.",-14} {"F. Devolución",-14} {"Estado",-12}");
        Console.WriteLine(new string('─', 70));

        for (int i = 0; i < totalPrestamos; i++)
        {
            Prestamo p = prestamos[i];
            string estado = p.Devuelto ? "Devuelto" : (DateTime.Now > p.FechaDevolucionEsperada ? "VENCIDO" : "Activo");
            ConsoleColor col = p.Devuelto ? ConsoleColor.DarkGray : (DateTime.Now > p.FechaDevolucionEsperada ? ConsoleColor.Red : ConsoleColor.Green);

            Console.Write($"  {p.Id,-5} {p.LibroId,-8} {p.UsuarioId,-10} {p.FechaPrestamo:dd/MM/yyyy,-14} {p.FechaDevolucionEsperada:dd/MM/yyyy,-14} ");
            Console.ForegroundColor = col;
            Console.WriteLine(estado);
            Console.ResetColor();
        }

        Pausa();
    }

    static void ListarPrestamosActivos()
    {
        Console.Clear();
        Encabezado("PRÉSTAMOS ACTIVOS");

        bool hayActivos = false;
        for (int i = 0; i < totalPrestamos; i++)
        {
            if (!prestamos[i].Devuelto)
            {
                if (!hayActivos)
                {
                    Console.WriteLine($"  {"ID",-5} {"Libro",-30} {"Usuario",-25} {"Devolver",-12}");
                    Console.WriteLine(new string('─', 75));
                    hayActivos = true;
                }

                Prestamo p = prestamos[i];
                int idxL = EncontrarLibro(p.LibroId);
                int idxU = EncontrarUsuario(p.UsuarioId);
                string libro = idxL != -1 ? libros[idxL].Titulo : $"ID {p.LibroId}";
                string usuario = idxU != -1 ? $"{usuarios[idxU].Nombre} {usuarios[idxU].Apellido}" : $"ID {p.UsuarioId}";

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"  {p.Id,-5} {libro,-30} {usuario,-25} {p.FechaDevolucionEsperada:dd/MM/yyyy}");
                Console.ResetColor();
            }
        }

        if (!hayActivos) MostrarError("No hay préstamos activos.");
        Pausa();
    }

    static void ListarPrestamosVencidos()
    {
        Console.Clear();
        Encabezado("PRÉSTAMOS VENCIDOS");

        bool hayVencidos = false;
        for (int i = 0; i < totalPrestamos; i++)
        {
            Prestamo p = prestamos[i];
            if (!p.Devuelto && DateTime.Now > p.FechaDevolucionEsperada)
            {
                if (!hayVencidos)
                {
                    Console.WriteLine($"  {"ID",-5} {"Libro",-28} {"Usuario",-23} {"Venció",-12} {"Días",-6}");
                    Console.WriteLine(new string('─', 76));
                    hayVencidos = true;
                }

                int idxL = EncontrarLibro(p.LibroId);
                int idxU = EncontrarUsuario(p.UsuarioId);
                string libro = idxL != -1 ? libros[idxL].Titulo : $"ID {p.LibroId}";
                string usuario = idxU != -1 ? $"{usuarios[idxU].Nombre} {usuarios[idxU].Apellido}" : $"ID {p.UsuarioId}";
                int diasRetraso = (DateTime.Now - p.FechaDevolucionEsperada).Days;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"  {p.Id,-5} {libro,-28} {usuario,-23} {p.FechaDevolucionEsperada:dd/MM/yyyy,-12} {diasRetraso,-6}");
                Console.ResetColor();
            }
        }

        if (!hayVencidos) MostrarExito("No hay préstamos vencidos. ¡Todo al día!");
        Pausa();
    }

    static void HistorialPorUsuario()
    {
        Console.Clear();
        Encabezado("HISTORIAL POR USUARIO");
        Console.Write("  Ingrese ID del usuario: ");
        int.TryParse(Console.ReadLine(), out int usuarioId);

        int idxU = EncontrarUsuario(usuarioId);
        if (idxU == -1) { MostrarError("Usuario no encontrado."); Pausa(); return; }

        Console.WriteLine($"\n  Usuario: {usuarios[idxU].Nombre} {usuarios[idxU].Apellido}\n");
        Console.WriteLine($"  {"ID",-5} {"Libro",-30} {"Préstamo",-12} {"Devolución",-12} {"Estado",-10}");
        Console.WriteLine(new string('─', 73));

        bool hayRegistros = false;
        for (int i = 0; i < totalPrestamos; i++)
        {
            if (prestamos[i].UsuarioId == usuarioId)
            {
                hayRegistros = true;
                Prestamo p = prestamos[i];
                int idxL = EncontrarLibro(p.LibroId);
                string libro = idxL != -1 ? libros[idxL].Titulo : $"ID {p.LibroId}";
                string estado = p.Devuelto ? "Devuelto" : "Activo";
                string devolucion = p.Devuelto ? p.FechaDevolucionReal.ToString("dd/MM/yyyy") : p.FechaDevolucionEsperada.ToString("dd/MM/yyyy*");

                ConsoleColor col = p.Devuelto ? ConsoleColor.DarkGray : ConsoleColor.Green;
                Console.ForegroundColor = col;
                Console.WriteLine($"  {p.Id,-5} {libro,-30} {p.FechaPrestamo:dd/MM/yyyy,-12} {devolucion,-12} {estado,-10}");
                Console.ResetColor();
            }
        }

        if (!hayRegistros) MostrarError("Este usuario no tiene préstamos registrados.");
        else Console.WriteLine("\n  * Fecha de devolución esperada (aún activo)");

        Pausa();
    }

    // ──────────────────────────────────────────────────────
    // REPORTES
    // ──────────────────────────────────────────────────────

    static void ResumenGeneral()
    {
        Console.Clear();
        Encabezado("RESUMEN GENERAL DEL SISTEMA");

        int librosDisponibles = 0, librosPrestados = 0;
        for (int i = 0; i < totalLibros; i++)
            if (libros[i].Disponible) librosDisponibles++; else librosPrestados++;

        int usuariosActivos = 0;
        for (int i = 0; i < totalUsuarios; i++)
            if (usuarios[i].Activo) usuariosActivos++;

        int prestamosActivos = 0, prestamosVencidos = 0, prestamosDevueltos = 0;
        for (int i = 0; i < totalPrestamos; i++)
        {
            if (prestamos[i].Devuelto) prestamosDevueltos++;
            else if (DateTime.Now > prestamos[i].FechaDevolucionEsperada) prestamosVencidos++;
            else prestamosActivos++;
        }

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("  ── LIBROS ──────────────────────────────");
        Console.ResetColor();
        Console.WriteLine($"  Total registrados : {totalLibros}");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"  Disponibles       : {librosDisponibles}");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"  Prestados         : {librosPrestados}");
        Console.ResetColor();

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("  ── USUARIOS ────────────────────────────");
        Console.ResetColor();
        Console.WriteLine($"  Total registrados : {totalUsuarios}");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"  Activos           : {usuariosActivos}");
        Console.ResetColor();

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("  ── PRÉSTAMOS ───────────────────────────");
        Console.ResetColor();
        Console.WriteLine($"  Total histórico   : {totalPrestamos}");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"  Activos           : {prestamosActivos}");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"  Vencidos          : {prestamosVencidos}");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"  Devueltos         : {prestamosDevueltos}");
        Console.ResetColor();

        Pausa();
    }

    static void ReporteDisponibles()
    {
        Console.Clear();
        Encabezado("LIBROS DISPONIBLES");

        bool hay = false;
        for (int i = 0; i < totalLibros; i++)
        {
            if (libros[i].Disponible)
            {
                if (!hay) { Console.WriteLine(); hay = true; }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"  [{libros[i].Id}] {libros[i].Titulo} — {libros[i].Autor}");
                Console.ResetColor();
            }
        }

        if (!hay) MostrarError("No hay libros disponibles en este momento.");
        Pausa();
    }

    static void ReportePrestados()
    {
        Console.Clear();
        Encabezado("LIBROS PRESTADOS ACTUALMENTE");

        bool hay = false;
        for (int i = 0; i < totalPrestamos; i++)
        {
            if (!prestamos[i].Devuelto)
            {
                if (!hay)
                {
                    Console.WriteLine($"\n  {"Libro",-30} {"Usuario",-25} {"Devuelve",-12}");
                    Console.WriteLine(new string('─', 70));
                    hay = true;
                }

                Prestamo p = prestamos[i];
                int idxL = EncontrarLibro(p.LibroId);
                int idxU = EncontrarUsuario(p.UsuarioId);
                string libro = idxL != -1 ? libros[idxL].Titulo : $"ID {p.LibroId}";
                string usuario = idxU != -1 ? $"{usuarios[idxU].Nombre} {usuarios[idxU].Apellido}" : $"ID {p.UsuarioId}";

                bool vencido = DateTime.Now > p.FechaDevolucionEsperada;
                Console.ForegroundColor = vencido ? ConsoleColor.Red : ConsoleColor.White;
                Console.WriteLine($"  {libro,-30} {usuario,-25} {p.FechaDevolucionEsperada:dd/MM/yyyy}");
                Console.ResetColor();
            }
        }

        if (!hay) MostrarExito("No hay libros prestados en este momento.");
        Pausa();
    }

    // ──────────────────────────────────────────────────────
    // HELPERS DE BÚSQUEDA
    // ──────────────────────────────────────────────────────

    static int EncontrarLibro(int id)
    {
        for (int i = 0; i < totalLibros; i++)
            if (libros[i].Id == id) return i;
        return -1;
    }

    static int EncontrarUsuario(int id)
    {
        for (int i = 0; i < totalUsuarios; i++)
            if (usuarios[i].Id == id) return i;
        return -1;
    }

    static int EncontrarPrestamo(int id)
    {
        for (int i = 0; i < totalPrestamos; i++)
            if (prestamos[i].Id == id) return i;
        return -1;
    }

    // ──────────────────────────────────────────────────────
    // HELPERS DE VISUALIZACIÓN
    // ──────────────────────────────────────────────────────

    static void MostrarDetalleLibro(Libro l)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"  ┌─ Libro #{l.Id}");
        Console.ResetColor();
        Console.WriteLine($"  │  Título    : {l.Titulo}");
        Console.WriteLine($"  │  Autor     : {l.Autor}");
        Console.WriteLine($"  │  ISBN      : {l.ISBN}");
        Console.WriteLine($"  │  Año       : {l.AnyoPublicacion}");
        Console.Write($"  └  Estado    : ");
        Console.ForegroundColor = l.Disponible ? ConsoleColor.Green : ConsoleColor.Red;
        Console.WriteLine(l.Disponible ? "Disponible" : "Prestado");
        Console.ResetColor();
        Console.WriteLine();
    }

    static void MostrarDetalleUsuario(Usuario u)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"  ┌─ Usuario #{u.Id}");
        Console.ResetColor();
        Console.WriteLine($"  │  Nombre    : {u.Nombre} {u.Apellido}");
        Console.WriteLine($"  │  Email     : {u.Email}");
        Console.WriteLine($"  │  Teléfono  : {u.Telefono}");
        Console.Write($"  └  Estado    : ");
        Console.ForegroundColor = u.Activo ? ConsoleColor.Green : ConsoleColor.DarkGray;
        Console.WriteLine(u.Activo ? "Activo" : "Inactivo");
        Console.ResetColor();
        Console.WriteLine();
    }

    static void Encabezado(string titulo)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"\n  ══ {titulo} ══\n");
        Console.ResetColor();
    }

    static void MostrarError(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n  ✖ {msg}");
        Console.ResetColor();
        Pausa();
    }

    static void MostrarExito(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n  ✔ {msg}");
        Console.ResetColor();
        Pausa();
    }

    static void Pausa()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\n  Presione cualquier tecla para continuar...");
        Console.ResetColor();
        Console.ReadKey(true);
    }

    // ──────────────────────────────────────────────────────
    // DATOS DE EJEMPLO
    // ──────────────────────────────────────────────────────

    static void CargarDatosEjemplo()
    {
        // Libros
        libros[0] = new Libro { Id = nextLibroId++, Titulo = "Cien años de soledad", Autor = "Gabriel García Márquez", ISBN = "978-0-06-088328-7", AnyoPublicacion = 1967, Disponible = true };
        libros[1] = new Libro { Id = nextLibroId++, Titulo = "El principito", Autor = "Antoine de Saint-Exupéry", ISBN = "978-84-261-3274-3", AnyoPublicacion = 1943, Disponible = true };
        libros[2] = new Libro { Id = nextLibroId++, Titulo = "Don Quijote de la Mancha", Autor = "Miguel de Cervantes", ISBN = "978-84-376-0494-7", AnyoPublicacion = 1605, Disponible = true };
        libros[3] = new Libro { Id = nextLibroId++, Titulo = "1984", Autor = "George Orwell", ISBN = "978-0-45-228285-3", AnyoPublicacion = 1949, Disponible = false };
        libros[4] = new Libro { Id = nextLibroId++, Titulo = "Fahrenheit 451", Autor = "Ray Bradbury", ISBN = "978-1-45-162862-5", AnyoPublicacion = 1953, Disponible = true };
        totalLibros = 5;

        // Usuarios
        usuarios[0] = new Usuario { Id = nextUsuarioId++, Nombre = "María", Apellido = "López", Email = "maria@email.com", Telefono = "555-1001", Activo = true };
        usuarios[1] = new Usuario { Id = nextUsuarioId++, Nombre = "Carlos", Apellido = "Ramírez", Email = "carlos@email.com", Telefono = "555-1002", Activo = true };
        usuarios[2] = new Usuario { Id = nextUsuarioId++, Nombre = "Ana", Apellido = "González", Email = "ana@email.com", Telefono = "555-1003", Activo = true };
        totalUsuarios = 3;

        // Préstamo de ejemplo (libro ID 4 — "1984" ya marcado como no disponible)
        prestamos[0] = new Prestamo
        {
            Id = nextPrestamoId++,
            LibroId = 4,
            UsuarioId = 1,
            FechaPrestamo = DateTime.Now.AddDays(-5),
            FechaDevolucionEsperada = DateTime.Now.AddDays(9),
            Devuelto = false
        };
        totalPrestamos = 1;
    }
}
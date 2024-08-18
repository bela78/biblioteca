using Biblioteca_tecoc;
using Biblioteca_tecoc.Models;

public class Program
{
    private static void Main(string[] args)
    {
        var biblioteca = new Biblioteca();

        // Crear libros
        var libro1 = new Libro("1", "Cien años de soledad", "Gabriel García Márquez", "Novela", "disponible");
        var libro2 = new Libro("2", "Don Quijote de la Mancha", "Miguel de Cervantes", "Novela", "disponible");
        biblioteca.AgregarLibro(libro1);
        biblioteca.AgregarLibro(libro2);

        // Crear usuarios
        var usuario1 = new Usuario("1", "Juan Pérez", "Calle Falsa 123");
        biblioteca.AgregarUsuario(usuario1);

        // Menú de interacción
        while (true)
        {
            Console.WriteLine("Menú:");
            Console.WriteLine("1. Agregar Libro");
            Console.WriteLine("2. Eliminar Libro");
            Console.WriteLine("3. Actualizar Libro");
            Console.WriteLine("4. Mostrar Libros");
            Console.WriteLine("5. Buscar Libro");
            Console.WriteLine("6. Agregar Usuario");
            Console.WriteLine("7. Actualizar Usuario");
            Console.WriteLine("8. Mostrar Usuarios");
            Console.WriteLine("9. Registrar Préstamo");
            Console.WriteLine("10. Devolver Libro");
            Console.WriteLine("11. Mostrar Préstamos");
            Console.WriteLine("12. Mostrar Libros Vencidos");
            Console.WriteLine("13. Salir");
            Console.Write("Seleccione una opción: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese ID del libro: ");
                    var idLibro = Console.ReadLine();
                    Console.Write("Ingrese Título: ");
                    var titulo = Console.ReadLine();
                    Console.Write("Ingrese Autor: ");
                    var autor = Console.ReadLine();
                    Console.Write("Ingrese Género: ");
                    var genero = Console.ReadLine();
                    Console.Write("Ingrese Estado (disponible, prestado, reservado): ");
                    var estado = Console.ReadLine();
                    var nuevoLibro = new Libro(idLibro, titulo, autor, genero, estado);
                    biblioteca.AgregarLibro(nuevoLibro);
                    break;

                case "2":
                    Console.Write("Ingrese ID del libro a eliminar: ");
                    var eliminarIdLibro = Console.ReadLine();
                    biblioteca.EliminarLibro(eliminarIdLibro);
                    break;

                case "3":
                    Console.Write("Ingrese ID del libro a actualizar: ");
                    var actualizarIdLibro = Console.ReadLine();
                    Console.Write("Ingrese nuevo Título: ");
                    var nuevoTitulo = Console.ReadLine();
                    Console.Write("Ingrese nuevo Autor: ");
                    var nuevoAutor = Console.ReadLine();
                    Console.Write("Ingrese nuevo Género: ");
                    var nuevoGenero = Console.ReadLine();
                    Console.Write("Ingrese nuevo Estado: ");
                    var nuevoEstado = Console.ReadLine();
                    biblioteca.ActualizarLibro(actualizarIdLibro, nuevoTitulo, nuevoAutor, nuevoGenero, nuevoEstado);
                    break;

                case "4":
                    biblioteca.MostrarLibros();
                    break;

                case "5":
                    Console.Write("Ingrese criterio de búsqueda (Título, Autor, Género): ");
                    var criterio = Console.ReadLine();
                    var librosEncontrados = biblioteca.ConsultarLibros(criterio);
                    foreach (var libro in librosEncontrados)
                    {
                        Console.WriteLine(libro);
                    }
                    break;

                case "6":
                    Console.Write("Ingrese ID del usuario: ");
                    var idUsuario = Console.ReadLine();
                    Console.Write("Ingrese Nombre: ");
                    var nombre = Console.ReadLine();
                    Console.Write("Ingrese Dirección: ");
                    var direccion = Console.ReadLine();
                    var nuevoUsuario = new Usuario(idUsuario, nombre, direccion);
                    biblioteca.AgregarUsuario(nuevoUsuario);
                    break;

                case "7":
                    Console.Write("Ingrese ID del usuario a actualizar: ");
                    var actualizarIdUsuario = Console.ReadLine();
                    Console.Write("Ingrese nuevo Nombre: ");
                    var nuevoNombre = Console.ReadLine();
                    Console.Write("Ingrese nueva Dirección: ");
                    var nuevaDireccion = Console.ReadLine();
                    biblioteca.ActualizarUsuario(actualizarIdUsuario, nuevoNombre, nuevaDireccion);
                    break;

                case "8":
                    biblioteca.MostrarUsuarios();
                    break;

                case "9":
                    Console.Write("Ingrese ID del libro: ");
                    var prestamoIdLibro = Console.ReadLine();
                    Console.Write("Ingrese ID del usuario: ");
                    var prestamoIdUsuario = Console.ReadLine();
                    Console.Write("Ingrese Fecha de Préstamo (yyyy-MM-dd): ");
                    var fechaPrestamo = DateTime.Parse(Console.ReadLine());
                    Console.Write("Ingrese Fecha de Vencimiento (yyyy-MM-dd): ");
                    var fechaVencimiento = DateTime.Parse(Console.ReadLine());
                    biblioteca.RegistrarPrestamo(prestamoIdLibro, prestamoIdUsuario, fechaPrestamo, fechaVencimiento);
                    break;

                case "10":
                    Console.Write("Ingrese ID del libro: ");
                    var devolverIdLibro = Console.ReadLine();
                    Console.Write("Ingrese ID del usuario: ");
                    var devolverIdUsuario = Console.ReadLine();
                    biblioteca.DevolverLibro(devolverIdLibro, devolverIdUsuario);
                    break;

                case "11":
                    biblioteca.MostrarPrestamos();
                    break;

                case "12":
                    biblioteca.MostrarLibrosVencidos();
                    break;

                case "13":
                    return;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}

    

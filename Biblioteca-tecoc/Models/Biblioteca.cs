using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_tecoc.Models
{
    public class Biblioteca
    {
        private readonly List<Libro> libros;
        private readonly List<Usuario> usuarios;
        private readonly List<Prestamo> prestamos;

        public Biblioteca()
        {
            libros = new List<Libro>();
            usuarios = new List<Usuario>();
            prestamos = new List<Prestamo>();
        }

        // Gestión de Libros
        public void AgregarLibro(Libro libro)
        {
            libros.Add(libro);
        }

        public void EliminarLibro(string id)
        {
            var libro = libros.SingleOrDefault(l => l.Id == id);
            if (libro != null)
            {
                libros.Remove(libro);
            }
        }

        public void ActualizarLibro(string id, string nuevoTitulo, string nuevoAutor, string nuevoGenero, string nuevoEstado)
        {
            var libro = libros.SingleOrDefault(l => l.Id == id);
            if (libro != null)
            {
                libro.Titulo = nuevoTitulo;
                libro.Autor = nuevoAutor;
                libro.Genero = nuevoGenero;
                libro.Estado = nuevoEstado;
            }
        }

        public IEnumerable<Libro> ConsultarLibros(string criterio)
        {
            return libros.Where(l => l.Titulo.Contains(criterio, StringComparison.OrdinalIgnoreCase) ||
                                     l.Autor.Contains(criterio, StringComparison.OrdinalIgnoreCase) ||
                                     l.Genero.Contains(criterio, StringComparison.OrdinalIgnoreCase));
        }

        public void MostrarLibros()
        {
            Console.WriteLine("Lista de Libros:");
            foreach (var libro in libros)
            {
                Console.WriteLine(libro);
            }
        }

        // Gestión de Préstamos
        public void RegistrarPrestamo(string libroId, string usuarioId, DateTime fechaPrestamo, DateTime fechaVencimiento)
        {
            var libro = libros.SingleOrDefault(l => l.Id == libroId);
            var usuario = usuarios.SingleOrDefault(u => u.Id == usuarioId);

            if (libro != null && usuario != null && libro.Estado == "disponible")
            {
                var prestamo = new Prestamo(libro, usuario, fechaPrestamo, fechaVencimiento);
                prestamos.Add(prestamo);
                libro.ActualizarEstado("prestado");
                usuario.AgregarPrestamo(prestamo);
            }
        }

        public void DevolverLibro(string libroId, string usuarioId)
        {
            var prestamo = prestamos.SingleOrDefault(p => p.Libro.Id == libroId && p.Usuario.Id == usuarioId);
            if (prestamo != null)
            {
                prestamo.DevolverLibro();
                prestamos.Remove(prestamo);
            }
        }

        public void MostrarPrestamos()
        {
            Console.WriteLine("Lista de Préstamos:");
            foreach (var prestamo in prestamos)
            {
                Console.WriteLine(prestamo);
            }
        }

        // Gestión de Usuarios
        public void AgregarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        public void ActualizarUsuario(string id, string nuevoNombre, string nuevaDireccion)
        {
            var usuario = usuarios.SingleOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                usuario.Nombre = nuevoNombre;
                usuario.Direccion = nuevaDireccion;
            }
        }

        public void MostrarUsuarios()
        {
            Console.WriteLine("Lista de Usuarios:");
            foreach (var usuario in usuarios)
            {
                Console.WriteLine(usuario);
            }
        }

        // Reportes y Consultas
        public IEnumerable<Prestamo> LibrosVencidos()
        {
            return prestamos.Where(p => p.FechaVencimiento < DateTime.Now);
        }

        public void MostrarLibrosVencidos()
        {
            Console.WriteLine("Lista de Libros Vencidos:");
            foreach (var prestamo in LibrosVencidos())
            {
                Console.WriteLine(prestamo);
            }
        }
    }
}

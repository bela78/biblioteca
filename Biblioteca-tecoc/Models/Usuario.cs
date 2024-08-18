using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_tecoc.Models
{
    public class Usuario
    {
        public string Id { get; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public List<Prestamo> HistorialPrestamos { get; }

        public Usuario(string id, string nombre, string direccion)
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
            HistorialPrestamos = new List<Prestamo>();
        }

        public void AgregarPrestamo(Prestamo prestamo)
        {
            HistorialPrestamos.Add(prestamo);
        }

        public void QuitarPrestamo(Prestamo prestamo)
        {
            HistorialPrestamos.Remove(prestamo);
        }

        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {Nombre}, Dirección: {Direccion}";
        }
    }
}

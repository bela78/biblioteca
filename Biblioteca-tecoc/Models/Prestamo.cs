using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_tecoc.Models
{
    public class Prestamo
    {
        public Libro Libro { get; }
        public Usuario Usuario { get; }
        public DateTime FechaPrestamo { get; }
        public DateTime FechaVencimiento { get; }

        public Prestamo(Libro libro, Usuario usuario, DateTime fechaPrestamo, DateTime fechaVencimiento)
        {
            Libro = libro;
            Usuario = usuario;
            FechaPrestamo = fechaPrestamo;
            FechaVencimiento = fechaVencimiento;
        }

        public void DevolverLibro()
        {
            Libro.ActualizarEstado("disponible");
            Usuario.QuitarPrestamo(this);
        }

        public override string ToString()
        {
            return $"Libro: {Libro.Titulo}, Usuario: {Usuario.Nombre}, Fecha de Préstamo: {FechaPrestamo.ToShortDateString()}, Fecha de Vencimiento: {FechaVencimiento.ToShortDateString()}";
        }
    }
}

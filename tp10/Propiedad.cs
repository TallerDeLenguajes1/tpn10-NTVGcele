using System;
using System.Collections.Generic;
using System.Text;

namespace tp10
{
    public enum TipoDePropiedad
    {
        Departamento = 0,
        Casa = 1,
        duplex = 2,
        Penthhouse = 3,
        Terreno = 4,

    }
    public enum TipoDeOperacion
    {
        venta = 0,
        alquiler = 1,
    }
    public class Propiedad
    {
        private int id;
        private float tamanio;

        private TipoDePropiedad tpropiedad;
        private TipoDeOperacion operacion;

        private int cantidadDeBaños;
        private int cantidadDeHabitaciones;
        private string domicilio;
        private int precio;
        private bool estado; // activo/inactivo
        public Random rnd = new Random();
        public Propiedad()
        {
        }
        public Propiedad(TipoDePropiedad propiedad, int id, string domicilio)
        {
            Tpropiedad = propiedad;
            Operacion = (TipoDeOperacion)rnd.Next(0, 2);
            Id = id;
            Tamanio = rnd.Next(0, 100);
            CantidadDeBaños = rnd.Next(0, 5);
            CantidadDeHabitaciones = rnd.Next(0, 10);
            Domicilio = domicilio;
            Precio = ValorDelImueble(precio);
            Estado = Convert.ToBoolean(rnd.Next(0, 1));
        }

        internal TipoDePropiedad Tpropiedad { get => tpropiedad; set => tpropiedad = value; }
        internal TipoDeOperacion Operacion { get => operacion; set => operacion = value; }
        public int Id { get => id; set => id = value; }
        public float Tamanio { get => tamanio; set => tamanio = value; }
        public int CantidadDeBaños { get => cantidadDeBaños; set => cantidadDeBaños = value; }
        public int CantidadDeHabitaciones { get => cantidadDeHabitaciones; set => cantidadDeHabitaciones = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }
        public int Precio { get => precio; set => precio = value; }
        public bool Estado { get => estado; set => estado = value; }
  

        public int ValorDelImueble(int _precio)
        {
            if (TipoDeOperacion.venta == Operacion)
            {
                _precio += Convert.ToInt32(_precio * 0.21) + Convert.ToInt32(_precio * 0.1) + 10000;
            }
            else
            {
                _precio += Convert.ToInt32(_precio * 0.02) + Convert.ToInt32(_precio * 0.05);
            }
            return _precio;
        }
    }
}

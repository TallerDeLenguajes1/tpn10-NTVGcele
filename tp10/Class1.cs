using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace tp10
{
    public static class Helpers
    {
        public static void CrearArchivo(string archivo)
        {
            using (FileStream NuevArchivo = new FileStream(archivo, FileMode.OpenOrCreate))
            {
                 NuevArchivo.Close();
            }

        }
        public static void EscribirArchivo(string archivo, string texto)
        {
            using (StreamWriter escribirArchivo = new StreamWriter(archivo))
            {
                escribirArchivo.Write(texto);
                escribirArchivo.Close();    
            }

        }
        public static List<Propiedad> LeerArchivo1(string archivo)
        {
            string linea = "";
            int i = 0;
            Propiedad Imueble;
            List<Propiedad> ListaDePropiedad = new List<Propiedad>();
            StreamReader file = new StreamReader(archivo);
            
            while ((linea = file.ReadLine()) != null)
            {
                string[] Lineas = linea.Split(";");
                int caso = 1;
                switch (Lineas[1])
                {
                    case "Departamento":  caso = 0;break;
                    case "Casa":  caso = 1; break;
                    case "duplex":  caso = 2; break;
                    case "Penthhouse":  caso = 3; break;
                    case "Terreno":  caso = 4; break;
                }
                Imueble = new Propiedad((TipoDePropiedad)caso, i, Lineas[0]);
                ListaDePropiedad.Add(Imueble);
            }
            return ListaDePropiedad;
        }

        public static void AgregraAlArchivo(Propiedad Agregar, string archivo)
        {
            string texto = "\n";
            texto += Agregar.Id + ";";
            texto += Agregar.Tamanio + ";";
            texto += Agregar.Tpropiedad + ";";
            texto += Agregar.Operacion + ";";

            texto += Agregar.CantidadDeBaños + ";";
            texto += Agregar.CantidadDeHabitaciones + ";";
            texto += Agregar.Domicilio + ";";
            texto += Agregar.Precio + ";";
            texto += Agregar.Estado + ";";
            texto = texto + Environment.NewLine;
            File.AppendAllText(archivo, texto);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace tp10
{
    class Program
    {
        static void Main(string[] args)
        {
      
            string direct = @"C:\taller1_2020(C#)\tpn10-NTVGcele\archivo1.csv";
            Helpers.CrearArchivo(direct);
            string texto = "Domicilio; Tipo De Propiedad;" + Environment.NewLine + "Avellaneda 374; casa;" + Environment.NewLine + "sarmiento 40; casa";
            Helpers.EscribirArchivo(direct, texto);

            //Leo archivo 1 que contiene solo dimicilio y tipo de propiedad

            List<Propiedad> ListaPropiedad = Helpers.LeerArchivo1(direct);

            // Creo un archivo nuevo y guardo todas las propiedades

            string NuevoDirect = @"C:\taller1_2020(C#)\tpn10-NTVGcele\ArchivoDePropiedades.csv";
            Helpers.CrearArchivo(NuevoDirect);
            foreach(Propiedad agregar in ListaPropiedad)
            {
                Helpers.AgregraAlArchivo(agregar, NuevoDirect);
            }

        }
    }
}

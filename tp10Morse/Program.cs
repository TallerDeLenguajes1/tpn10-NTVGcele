using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace tp10Morse
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\taller1_2020(C#)\tpn10-NTVGcele";
            SoporteParaConfiguracion.CrearArchivoDeConfiguracion(path);

            Console.Write("Ingrese un texto para convertirno en audio morse: ");

            string texto = Convert.ToString(Console.ReadLine());
            ConversorDeMorse.ConvertirAudio(texto);
        }
    }
}

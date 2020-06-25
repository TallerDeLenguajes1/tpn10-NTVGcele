using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
namespace tp10Morse
{
    public static class SoporteParaConfiguracion
    {
        public static void CrearArchivoDeConfiguracion(string Directorio)
        {
            string nuevoArchivo = Directorio + @"\AudioMorse.mp3";
            if (!File.Exists(nuevoArchivo))
            {
                File.Create(nuevoArchivo);
            }
        }
    }
    public static class ConversorDeMorse
    {
        public static string TextoAMorse(string palabra)
        {
            string aux = "";
            for (int i = 0; i < palabra.Length; i++)
            {
                switch (palabra[i])
                {
                    case 'a':
                    case 'A': aux = aux + ".- "; break;
                    case 'b':
                    case 'B': aux = aux + "-... "; break;
                    case 'c':
                    case 'C': aux = aux + "-.-. "; break;
                    case 'd':
                    case 'D': aux = aux + "-.. "; break;
                    case 'e':
                    case 'E': aux = aux + ". "; break;
                    case 'f':
                    case 'F': aux = aux + "..-. "; break;
                    case 'g':
                    case 'G': aux = aux + "--. "; break;
                    case 'h':
                    case 'H': aux = aux + ".... "; break;
                    case 'i':
                    case 'I': aux = aux + ".. "; break;
                    case 'j':
                    case 'J': aux = aux + ".--- "; break;
                    case 'k':
                    case 'K': aux = aux + "-.- "; break;
                    case 'l':
                    case 'L': aux = aux + ".-.. "; break;
                    case 'm':
                    case 'M': aux = aux + "-- "; break;
                    case 'n':
                    case 'N': aux = aux + "-. "; break;
                    case 'o':
                    case 'O': aux = aux + "--- "; break;
                    case 'p':
                    case 'P': aux = aux + ".--. "; break;
                    case 'q':
                    case 'Q': aux = aux + "--.- "; break;
                    case 'r':
                    case 'R': aux = aux + ".-. "; break;
                    case 's':
                    case 'S': aux = aux + "... "; break;
                    case 't':
                    case 'T': aux = aux + "- "; break;
                    case 'u':
                    case 'U': aux = aux + "..- "; break;
                    case 'v':
                    case 'V': aux = aux + "...- "; break;
                    case 'w':
                    case 'W': aux = aux + ".-- "; break;
                    case 'x':
                    case 'X': aux = aux + "-..- "; break;
                    case 'y':
                    case 'Y': aux = aux + "-.-- "; break;
                    case 'z':
                    case 'Z': aux = aux + "--.. "; break;
                    case '1': aux = aux + ".---- "; break;
                    case '2': aux = aux + "..--- "; break;
                    case '3': aux = aux + "...-- "; break;
                    case '4': aux = aux + "....- "; break;
                    case '5': aux = aux + "..... "; break;
                    case '6': aux = aux + "-.... "; break;
                    case '7': aux = aux + "--... "; break;
                    case '8': aux = aux + "---.. "; break;
                    case '9': aux = aux + "----. "; break;
                    case '0': aux = aux + "----- "; break;
                    case ' ': aux = aux + " "; break;
                }

            }
            return aux;
        }
        
        public static byte[] bytePuntoyRaya(string raya_puntoMp3)
        {
            BinaryReader mp3 = new BinaryReader(File.Open(raya_puntoMp3, FileMode.Open));
            byte[] buffer = mp3.ReadBytes(0);
            mp3.Close();
            return buffer;
        }
        public static void ConvertirAudio(string texto)
        {
            string textoMorse = TextoAMorse(texto);
            string rayamp3 = @"C:\taller1_2020(C#)\tpn10-NTVGcele\raya.mp3";
            string puntomp3 = @"C:\taller1_2020(C#)\tpn10-NTVGcele\punto.mp3";

            FileStream Punto = new FileStream(puntomp3, FileMode.Open);
            FileStream Raya = new FileStream(rayamp3, FileMode.Open);

            byte [] punto = LectorCompletoDeBinario(Punto);
            byte [] raya = LectorCompletoDeBinario(Raya);
           

            string path = @"C:\taller1_2020(C#)\tpn10-NTVGcele\AudioMorse.mp3";
            FileStream Audiomorse= new FileStream(path, FileMode.Open);
            byte[] mp3 = LectorCompletoDeBinario(Audiomorse);

            foreach (char letra in textoMorse)
            {
                if (letra == '.')
                {
                    //Array.Copy(punto, 0, mp3, mp3.Length, punto.Length);
                    Audiomorse.Write(punto, 0, punto.Length);
                }
                else
                {
                    if(letra == '-')
                    {
                         //Array.Copy(raya, 0, mp3, mp3.Length, raya.Length);
                        Audiomorse.Write(raya, 0, raya.Length);

                    }
                }
            }
            Raya.Close();
            Punto.Close();
            Audiomorse.Close();
        }

    public static Byte[] LectorCompletoDeBinario(Stream archivo)
    {
        byte[] buffer = new byte[3276];
        using (MemoryStream cont = new MemoryStream()) // creando un memory stream 
        {
            while (true)
            {
                int read = archivo.Read(buffer, 0, buffer.Length); // lee desde la última posición hasta el tamaño del buffer
                if (read <= 0)
                    return cont.ToArray(); // convierte el stream en array 
                cont.Write(buffer, 0, read); // graba en el stream 
            }
        }
    }
    }


}

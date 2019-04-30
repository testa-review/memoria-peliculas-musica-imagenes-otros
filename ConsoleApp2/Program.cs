using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Debug.WriteLine("hola");
            //Console.ReadKey(true);
            String cadena = "my.song.mp3 11b\ngreatSong.flac 1000b\nnot3.txt 5b\nvideo.mp4 200b\ngame.exe 100b\nmov!e.mkv 10000b";

            solution(cadena);

        }

        public static String solution(string sss)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            String lista = ""; // donde irá el resultado
            var dicc = new Dictionary<string, int>(); // donde se guradaran los tamaños

            //sss = sss.Replace(" ", "");
            String[] separada = sss.Split('\n'); // variable para trabajar
            dicc.Add("music", 0);
            dicc.Add("image", 0);
            dicc.Add("video", 0);
            dicc.Add("other", 0);


            /* TIPOS
            music: ".mp3", ".aac", ".flac", 
            image: ".jpg", ".bmp", ".gif", 
            video: ".mp4", ".avi", ".mkv", 
            oher: irreconocibles
           */
            
            foreach (var item in separada)
            {

                for (int k = item.Length - 1; k >= 0; k--)
                {
                    List<string> temp = new List<string>();

                    if (item[k] == '.') {
                        String corte = item.Substring(k,item.Length-k); // quitar punto "." y recortar el tamaño
                        corte = corte.Replace("b", "");
                        //Debug.WriteLine(corte);

                        String[] xyz = corte.Split(' ');

                        for (int i = 0; i < xyz.Length-1; i++)
                        {
                            // pares son los tipos
                            // impares son los tamaños en b
                            
                            if (i % 2 == 0) {
                                //Debug.WriteLine(xyz[i]);
                                if      (xyz[i] == ".mp3" || xyz[i] == ".aac" || xyz[i] == ".flac") dicc["music"] = dicc["music"] + Int32.Parse(xyz[i + 1]);
                                else if (xyz[i] == ".jpg" || xyz[i] == ".bmp" || xyz[i] == ".gif") dicc["image"] = dicc["image"] + Int32.Parse(xyz[i + 1]);
                                else if (xyz[i] == ".mp4" || xyz[i] == ".avi" || xyz[i] == ".mkv") dicc["video"] = dicc["video"] + Int32.Parse(xyz[i + 1]);
                                else dicc["other"] = dicc["other"] + Int32.Parse(xyz[i + 1]);
                            }
                            
                        }

                        break; // romper ejeceucion de for para que no siga buscando mas puntos
                    }                    
                    
                }

            }

            foreach (var item in dicc)
            {
                Debug.WriteLine(item);
            }


            return lista;
        }


    }
}
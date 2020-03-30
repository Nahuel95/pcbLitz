using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitzGrafica
{
    class Traductor
    {
        private static String startCommand = "G54";

        public static List<Arista> CalcularAristas(List<Coordenada> lista, int numCanales){
            List<Arista> ret = new List<Arista>();
            for (int i = 0; i < lista.Count() - 1; i++){
                Arista aux = new Arista(lista[i], lista[i + 1], numCanales);
                ret.Add(aux);
            }
            for (int i = 0; i < ret.Count() - 1; i++){
                double[] offset = Arista.CalcularOffsets(Arista.anguloEntreAristas(ret[i], ret[i + 1]), ret[i].getNumCanales(), ret[i].getAncho());
                ret[i].setOffsetFinal(offset);
                for (int j = 0; j < offset.Length; j++){
                    offset[j] = -offset[j];
                }
                ret[i + 1].setOffsetInicio(offset);
            }
                return ret;
        }


        public static double leerHerramienta(String path) {
            String[] lines = File.ReadAllLines(path);
            int start = 0;
            while (!lines[start].Contains(startCommand)) {
                start++;
            }
            char[] toolBreak = { '4', '*' };
            string[] partes = lines[start].Split(toolBreak);
            string tool = partes[1];
            int i = -1; ;
            do
            {
                i++;
            } while (!lines[i].Contains("AD" + tool));

            char[] sizeBreak = { ',', '*' };
            partes = lines[i].Split(sizeBreak);
            double size = double.Parse(partes[1].Replace('.',','));
            Console.WriteLine("ANCHO" + partes[1]);
            return size;
        }


        public static List<Coordenada> GerberACoordenadas(String path)
        {
            String[] lines = File.ReadAllLines(path);
            List<Coordenada> ret = new List<Coordenada>();

            int j = 0;
            while (!lines[j].Contains(startCommand)) {
                j++;
            }

            for (int i = j; i <= lines.Length - 1; i++) {
                if (lines[i].Contains("D01") || lines[i].Contains("D02")){
                    Console.WriteLine(i + "- " + lines[i]);
                    ret.Add(RenglonACoordenada(lines[i]));
                }
            }
            return ret;
        }

        private static Coordenada RenglonACoordenada(String renglon) {
            char[] breaks = { 'X', 'Y', 'D' };
            String[] parts = renglon.Split(breaks);

            double x = Double.Parse(parts[1]);
            double y = Double.Parse(parts[2]);
            //Ver errores de precision
            return new Coordenada(x, y);

        }
    }
}

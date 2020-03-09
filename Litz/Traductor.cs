using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litz
{
    class Traductor
    {
        private static String startCommand = "G54";

        public static List<Arista> calcularAristas(List<Coordenada> lista){
           
        }

        private double calcularLongitudArista(Coordenada a, Coordenada b){
            return Math.Sqrt(Math.Pow(b.getX() - a.getX(), 2) + Math.Pow(b.getY() - a.getY(), 2));
        }
        private List<int> calcularAngulos(List<Coordenada> coords){
            
        }

        private List<Coordenada> GerberACoordenadas(String path)
        {
            String[] lines = File.ReadAllLines(path);
            List<Coordenada> ret = new List<Coordenada>();

            for (int i = 0; i <= lines.Length; i++) {
                if (lines[i].Contains("D01") || lines[i].Contains("D02")){
                    ret.Add(RenglonACoordenada(lines[i]));
                }
            }
            return ret;
        }

        private  Coordenada RenglonACoordenada(String renglon) {
            char[] breaks = { 'X', 'Y', 'D' };
            String[] parts = renglon.Split(breaks);

            double x = Double.Parse(parts[1]);
            double y = Double.Parse(parts[2]);

            return new Coordenada(x, y);

        }
    }
}

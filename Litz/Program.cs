using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Litz
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("C:","Gerber_TopLayer.gtl");
            double size = Traductor.leerHerramienta(path);
            List<Coordenada> coords = Traductor.GerberACoordenadas(path);
            List<Arista> aristas = Traductor.CalcularAristas(coords, 5);

            foreach (Arista a in aristas) {
                a.setAncho(size);
            }

            for(int i = 0; i < aristas.Count - 1; i++) {
                int angulo = Arista.anguloEntreAristas(aristas[i], aristas[i + 1]);
                aristas[i].setOffsetFinal(Arista.CalcularOffsets(angulo, aristas[i].getNumCanales(), aristas[i].getAncho()));
                aristas[i+1].setOffsetInicio(Arista.CalcularOffsets(-angulo, aristas[i+1].getNumCanales(), aristas[i+1].getAncho()));
            }

            foreach (Arista a in aristas)
            {
                Console.WriteLine(a.ToString());
            }

            Console.ReadKey();
        }
    }
}

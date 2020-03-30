using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LitzGrafica
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void TransposeButton_Click(object sender, EventArgs e)
        {
            string path = Path.Combine("C:","Gerber_TopLayer.gtl");
            double size = Traductor.leerHerramienta(path);
            List<Coordenada> coords = Traductor.GerberACoordenadas(path);
            List<Arista> aristas = Traductor.CalcularAristas(coords, 5);

            foreach (Arista a in aristas)
            {
                a.setAncho(size);
            }

            for (int i = 0; i < aristas.Count - 1; i++)
            {
                int angulo = Arista.anguloEntreAristas(aristas[i], aristas[i + 1]);
                aristas[i].setOffsetFinal(Arista.CalcularOffsets(angulo, aristas[i].getNumCanales(), aristas[i].getAncho()));
                aristas[i + 1].setOffsetInicio(Arista.CalcularOffsets(-angulo, aristas[i + 1].getNumCanales(), aristas[i + 1].getAncho()));
            }
            List<List<Coordenada>[][]> pcb = new List<List<Coordenada>[][]>();
            foreach (Arista a in aristas)
            {
                //Console.WriteLine(a.ToString());
                List<Coordenada>[][] listCoord = TransposeMatrix.createList(a);
                pcb.Add(listCoord);
            }
            foreach (List<Coordenada>[][] i in pcb)
            {
                foreach (List<Coordenada>[] j in i)
                {
                    foreach (List<Coordenada> k in j)
                    {
                        foreach (Coordenada m in k)
                        {
                            Console.WriteLine(m.ToString());
                        }
                        Console.WriteLine("---");
                    }
                    Console.WriteLine("-------------");
                }
                Console.WriteLine("***************************");
            }
        }
    }
}

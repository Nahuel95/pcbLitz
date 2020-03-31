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

        private void chart1_Click(object sender, EventArgs e)
        {
            CambiarEscala cambiar = new CambiarEscala(sender);
            if (cambiar.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void TransposeButton_Click(object sender, EventArgs e)
        {

            OpenFileDialog file = new OpenFileDialog();
            string path = "D:\\Christian\\Desktop\\Comun_Top.GTL";
            //if (file.ShowDialog() == DialogResult.OK)
            //{
            //    path = file.FileName;
            //}

            //string path = Path.Combine("C:","Gerber_TopLayer.gtl");
            double size = Traductor.leerHerramienta(path);
            List<Coordenada> coords = Traductor.GerberACoordenadas(path);
            List<Arista> aristas = Traductor.CalcularAristas(coords, 5);

            foreach (Arista a in aristas)
            {
                a.setAncho(size*1000);
                //a.setAncho(10);
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
            Random rnd = new Random();
            int seriesIndex = 0;

            FileStream fs = new FileStream("asd", FileMode.CreateNew);
            
            foreach (List<Coordenada>[][] i in pcb)
            {
                foreach (List<Coordenada>[] j in i)
                {
                    foreach (List<Coordenada> k in j)
                    {
                        chart1.Series.Add(seriesIndex.ToString());
                        chart1.Series[seriesIndex].MarkerColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                        chart1.Series[seriesIndex].BorderWidth = 10;
                        chart1.Series[seriesIndex].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;


                        for (int m = 0; m < k.Count; m++)
                        {
                            if (true)
                            {
                                int mostrar = 15;
                                if (seriesIndex < mostrar)
                                {
                                    chart1.Series[seriesIndex].Points.AddXY(k[m].getX(), k[m].getY());
                                    Console.WriteLine(k[m].ToString());
                                    k[m].OrdenGerber(fs);
                                }
                            }else
                            {
                                chart1.Series[seriesIndex].Points.AddXY(k[m].getX(), k[m].getY());
                                Console.WriteLine(k[m].ToString());
                            }
                        }

                        seriesIndex++;
                    }

                }
                Console.WriteLine("-------------");
            }
            Console.WriteLine("***************************");
        }
        
    }
}


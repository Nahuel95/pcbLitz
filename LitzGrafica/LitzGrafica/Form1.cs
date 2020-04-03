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
            string path = "C:\\Gerber_TopLayer.GTL";
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

            foreach (Arista a in aristas) {
                double offsetInicialMayor = Math.Max(a.getOffsetInicio()[0], a.getOffsetInicio()[a.getNumCanales() - 1]);
                double offsetFinalMayor = Math.Max(a.getOffsetFinal()[0], a.getOffsetFinal()[a.getNumCanales() - 1]);
                double[] inic = a.getOffsetInicio();
                double[] fin = a.getOffsetFinal();

                a.setInicio(Arista.moverPuntoConAngulo(a.getInicio(), a.getAngulo(), offsetInicialMayor));
                a.setFinal(Arista.moverPuntoConAngulo(a.getFinal(),Arista.anguloContrario(a.getAngulo()),offsetFinalMayor));
                a.setLongitud((a.getLongitud() - offsetInicialMayor) - offsetFinalMayor);

                for (int i = 0; i < a.getNumCanales(); i++) {
                    inic[i] -= offsetInicialMayor;
                    fin[i] += offsetFinalMayor;
                }

                a.setOffsetInicio(inic);
                a.setOffsetFinal(fin);
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

            FileStream fsTop = new FileStream(Path.GetDirectoryName(path)+"\\LitzResult\\"+Path.GetFileNameWithoutExtension(path)+"_litz.gtl", FileMode.CreateNew);
            System.IO.StreamWriter swTop = new StreamWriter(fsTop);
            FileStream fsBot = new FileStream(Path.GetDirectoryName(path) + "\\LitzResult\\" + Path.GetFileNameWithoutExtension(path) + "_litz.gbl", FileMode.CreateNew);
            System.IO.StreamWriter swBot = new StreamWriter(fsTop);

            int capa = 0;
            foreach (List<Coordenada>[][] i in pcb)
            {
                foreach (List<Coordenada>[] j in i)
                {
                    StreamWriter actual;
                    if(capa == 0)
                    {
                        actual = swTop;
                    }
                    else
                    {
                        actual = swBot;
                    }

                    actual.WriteLine("G04 Layer: TopLayer *\nG04 LitzPCB por CBuzzio y NFilippa, {0}-{1} *\nG04 Scale: 100 percent, Rotated: No, Reflected: No *G04 Dimensiones en micrometros *G04 leading zeros omitted, absolute positions, 3 integer and 3 decimal *\n% FSLAX33Y33 *%\n% MOMM *%\nG90 *\nG71D02 *", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());
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
                                    k[m].OrdenGerber(actual);
                                }
                            }else
                            {
                                chart1.Series[seriesIndex].Points.AddXY(k[m].getX(), k[m].getY());
                                Console.WriteLine(k[m].ToString());
                                k[m].OrdenGerber(actual);
                            }
                        }

                        seriesIndex++;
                    }
                    capa = 1;
                }
            }

            swTop.Close();
            swBot.Close();
            fsTop.Close();
            fsBot.Close();
        }
        
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Litz
{
    public partial class Form1 : Form
    {
        
        
                public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            int n = 5;
            Coordenada inicio = new Coordenada(0.0, 0.0);
            Coordenada final = new Coordenada(0.0, 30.0);
            double width = 2.0;
            Arista a = new Arista(inicio, final, 5, width, 1, new double[] { 0, 0, 0, 0, 0 }, new double[] { 0, 0, 0, 0, 0 });
            Console.WriteLine("{0};{1}", a.longitud, Math.Atan2(final.y - inicio.y, final.x - inicio.x));

            List<Coordenada>[][] salida = TransposeMatrix.createList(a);
            
            Random rnd = new Random();
            //for(int i = 0; i < n; i++)
            //{
            //    chart1.Series.Add(i.ToString());
            //}
            //foreach (List<Coordenada>[] i in salida)
            //{
            //    int seriesIndex = 0;

            //    foreach (List<Coordenada> j in i)
            //    {
            //        chart1.Series[seriesIndex].MarkerColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            //        chart1.Series[seriesIndex].BorderWidth = 2;
            //        chart1.Series[seriesIndex].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;


            //        for (int k = 0; k < j.Count; k++)
            //        {
            //            if (seriesIndex == 0)
            //            {
            //                chart1.Series[seriesIndex].Points.AddXY(j[k].x, j[k].y);
            //                Console.WriteLine(j[k].ToString());
            //            }
            //        }
            //        seriesIndex++;
            //    }
            //}
            int seriesIndex = 0;
            for(int m = 0; m < salida.Length/2; m++)
            {
                List<Coordenada>[] i = salida[m];
                for(int p = 0; p < i.Length; p++)
                {
                    i[p].AddRange(salida[m + 1][p]);
                    i[p].Sort(new CoordCompare());
                }
                
                foreach (List<Coordenada> j in i)
                {
                    chart1.Series.Add(seriesIndex.ToString());
                    chart1.Series[seriesIndex].MarkerColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                    chart1.Series[seriesIndex].BorderWidth = (int)(width*10/5.0);
                    chart1.Series[seriesIndex].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;


                    for (int k = 0; k < j.Count; k++)
                    {
                        //int mostrar = 2;
                        //if (seriesIndex == mostrar || seriesIndex == mostrar+5)
                        //{
                            chart1.Series[seriesIndex].Points.AddXY(j[k].x, j[k].y);
                            Console.WriteLine(j[k].ToString());
                        //}
                    }

                    seriesIndex++;
                }

            }

            //foreach (Coordenada i in salida[0][0])
            //{
            //    Console.WriteLine(i.ToString());
            //    chart1.Series[0].Points.AddXY(i.x, i.y);
            //    chart1.Series[0].MarkerColor = colores[rnd.Next(0,4)];
            //    chart1.Series[0].BorderWidth = 2;
            //    chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            //}
            //foreach (Coordenada i in salida[1][0])
            //{
            //    Console.WriteLine(i.ToString());
            //    chart1.Series[1].Points.AddXY(i.x, i.y);
            //    chart1.Series[1].MarkerColor = colores[rnd.Next(0, 4)];
            //    chart1.Series[1].BorderWidth = 2;
            //    chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            //}

        }
    }
}

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
            Coordenada inicio = new Coordenada(10.0, 3.0);
            Coordenada final = new Coordenada(20.0, 3.0);
            List<Coordenada>[][] salida = TransposeMatrix.createList(new Arista(inicio,final,5,1.0,1,new double[] { 0, 0, 0, 0, 0 },new double[] { -0.2, -0.1, 0, 0.1, 0.2 }));
            Color[] colores = new Color[n];
            colores[0] = Color.Blue;
            colores[1] = Color.Red;
            colores[2] = Color.Black;
            colores[3] = Color.Green;
            colores[4] = Color.YellowGreen;
            
            Random rnd = new Random();
            for(int i = 0; i < n; i++)
            {
                chart1.Series.Add(i.ToString());
            }

            foreach (List<Coordenada>[] i in salida)
            {
                int seriesIndex = 0;

                foreach (List<Coordenada> j in i)
                {
                    chart1.Series[seriesIndex].MarkerColor = colores[rnd.Next(0, 4)];
                    chart1.Series[seriesIndex].BorderWidth = 2;
                    chart1.Series[seriesIndex].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;


                    for (int k = 0; k < j.Count; k++)
                    {
                        chart1.Series[seriesIndex].Points.AddXY(j[k].x, j[k].y);
                    }
                    seriesIndex++;
                }
            }

            //foreach(Coordenada i in salida[0][0])
            //{
            //    Console.WriteLine(i.ToString());
            //    chart1.Series[0].Points.AddXY(i.x, i.y);
            //}

        }
    }
}

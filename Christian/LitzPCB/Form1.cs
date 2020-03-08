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
            List<Coordenada>[][] salida = TransposeMatrix.create(n);
            Color[] colores = new Color[n];
            colores[0] = Color.Blue;
            colores[1] = Color.Red;
            colores[2] = Color.Black;
            colores[3] = Color.Green;
            colores[4] = Color.YellowGreen;
            
            double stepLength = 1;
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
                    chart1.Series[seriesIndex].MarkerColor = colores[rnd.Next(0,4)];
                    chart1.Series[seriesIndex].BorderWidth = 2;
                    chart1.Series[seriesIndex].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                    

                    for (int k = 0; k < j.Count; k++)
                    {
                        j[k] = new Coordenada(j[k].x, j[k].y * stepLength) + new Coordenada(10, 3);
                        chart1.Series[seriesIndex].Points.AddXY(j[k].x, j[k].y);
                        Console.WriteLine(j[k].ToString());
                    }
                    seriesIndex++;
                }
            }
            
        }
    }
}

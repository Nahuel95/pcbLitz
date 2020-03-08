using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LitzPCB
{
    public partial class Form1 : Form
    {

        public class Point
        {
            public Point(double a, double b)
            {
                x = a;
                y = b;
            }

            public static Point operator +(Point a, Point b)
            {
                return new Point(a.x + b.x, a.y + b.y);
            }
            public static Point operator -(Point a, Point b)
            {
                return new Point(a.x - b.x, a.y - b.y);
            }

            public override string ToString()
            {
                return ("(" + this.x.ToString() + " ; " + this.y.ToString() + ")");
            }
            public double x;
            public double y;

        }
        public class Arista
        {
            public Point Inicio;
            public Point Final;
            public double[] offsetInicio;
            public double[] offsetFinal;
            public double largo;
            public int nTrans;
            public int nStrands;
            public int angulo;
        }
        public List<Point>[][] transposeMatrix(int n)
        {
            List<Point>[][] salida = new List<Point>[2][];
            salida[0] = new List<Point>[n];
            salida[1] = new List<Point>[n];

            for (int i = 0; i < n; i++)
            {
                salida[0][i] = new List<Point>();
                salida[1][i] = new List<Point>();
                int via = 2 * i % n;
                int step = 2 * i / n < 1 ? 1 : -1;
                int layer = 2 * i / n;
                int y = 0;
                for (int j = 0; j < 4 * n + 2; j++)
                {

                    salida[layer][i].Add(new Point(via, y));
                    if (j % 2 != 0)
                    {
                        if (via == 4 && step == 1)
                        {
                            step = -1;
                            //salida[layer][i].Add(new Point(via, j++));
                            layer = 1;
                        }
                        else if (via == 0 && step == -1)
                        {
                            step = 1;
                            //salida[layer][i].Add(new Point(via, j++));
                            layer = 0;
                        }
                        else
                        {
                            //via += layer==0?1:-1;

                            via += step;
                            y++;
                        }
                    }
                    else
                    {
                        y++;
                    }

                }
            }

            return salida;
        }
        public List<Point>[][] transposeList(Arista a)
        {
            List<Point>[][] salida = transposeMatrix(a.nStrands);
            double stepLength = a.largo / (double)a.nTrans;
            foreach (List<Point>[] i in salida)
            {
                foreach (List<Point> j in i)
                {
                    for (int k = 0; k < j.Count; k++)
                    {
                        j[k] = new Point(0, j[k].y * stepLength) + a.Inicio;
                    }
                }
            }

            return salida;
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            int n = 5;
            List<Point>[][] salida = transposeMatrix(n);
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
            foreach (List<Point>[] i in salida)
            {
                int seriesIndex = 0;
                
                foreach (List<Point> j in i)
                {
                    chart1.Series[seriesIndex].MarkerColor = colores[rnd.Next(0,4)];
                    chart1.Series[seriesIndex].BorderWidth = 2;
                    chart1.Series[seriesIndex].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Funnel;


                    for (int k = 0; k < j.Count; k++)
                    {
                        j[k] = new Point(j[k].x, j[k].y * stepLength) + new Point(10, 3);
                        chart1.Series[seriesIndex].Points.AddXY(j[k].x, j[k].y);
                        Console.WriteLine(j[k].ToString());
                    }
                    seriesIndex++;
                }
            }
            
        }
    }
}

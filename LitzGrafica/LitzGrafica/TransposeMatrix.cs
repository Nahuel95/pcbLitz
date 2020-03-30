using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitzGrafica
{
    public static class TransposeMatrix
    {
        public static List<Coordenada>[][] create(int n)
        {
            List<Coordenada>[][] salida = new List<Coordenada>[2][];
            salida[0] = new List<Coordenada>[n];
            salida[1] = new List<Coordenada>[n];

            for (int i = 0; i < n; i++)
            {
                salida[0][i] = new List<Coordenada>();
                salida[1][i] = new List<Coordenada>();
                int via = 2 * i % n;
                int step = 2 * i / n < 1 ? 1 : -1;

                // layer: top=0 bottom=1
                int layer = 2 * i / n;
                int y = 0;
                
                for (int j = 0; j < 4 * n + 2; j++)
                {

                    salida[layer][i].Add(new Coordenada(via, y));
                    if (j % 2 != 0)
                    {
                        if (via == n-1 && layer == 0)
                        {
                            step = -1;
                            //salida[layer][i].Add(new Coordenada(via, j++));
                            layer = 1;
                        }
                        else if (via == 0 && step == -1)
                        {
                            step = 1;
                            //salida[layer][i].Add(new Coordenada(via, j++));
                            layer = 0;

                            
                        }
                        else
                        {
                            //via += layer==0?1:-1;

                            via += step;
                            y+=2;
                        }
                    }
                    else
                    {
                        if((via == n - 1 && j!= 4 * n) || (via == 0 && y != 0)) {
                            y += 5;
                        }
                        else
                        {
                            y += 4;
                        }
                    }

                }
            }

            return salida;
        }

        static List<Coordenada>[][] deepCopyOfTremendouslyIntrincatedArray(List<Coordenada>[][] target)
        {
            List<Coordenada>[][] salida = new List<Coordenada>[target.Length][];
            for(int i = 0; i < salida.Length; i++)
            {
                salida[i] = new List<Coordenada>[target[0].Length];
                for(int j = 0; j < salida[i].Length; j++)
                {
                    salida[i][j] = new List<Coordenada>();
                    foreach(Coordenada m in target[i][j])
                    {
                        salida[i][j].Add(new Coordenada(m.getX(), m.getY()));
                    }
                }
            }

            return salida;
            
        }

        static List<Coordenada>[][] multiplicarList(List<Coordenada>[][] a, int nVeces, int nCanales)
        {

            List<Coordenada>[][] salida = deepCopyOfTremendouslyIntrincatedArray(a);



            foreach (List<Coordenada>[] i in salida)
            {
                for (int j = 0; j < i.Length; j++)
                {
                    List<Coordenada> temp = new List<Coordenada>();
                    for (int index = 1; index < nVeces; index++)
                    {
                        foreach (Coordenada coord in i[j])
                        {
                            temp.Add(new Coordenada(coord.getX(), coord.getY() + 4 * nCanales * (index)-2));
                        }
                    }
                    //for (int l = 0; l < temp.Count; l++)
                    //{
                    //    Console.WriteLine(index);
                    //    temp[l].y +=  4*nCanales* (index);
                    //}
                    i[j].AddRange(temp);
                    temp.Clear();
                }
            }
            
            //foreach (List<Coordenada>[] i in salida)
            //{
            //    foreach (List<Coordenada> j in i)
            //    {
            //        int y = 0;
            //        for (int k = 0; k < j.Count; k++)
            //        {
            //            j[k].y = y;
            //            y++;
            //        }
            //    }
            //}
            return salida;
        }

        public static List<Coordenada>[][] createList(Arista a)
        {
            List<Coordenada>[][] salida = create(a.getNumCanales());

            salida = multiplicarList(salida, a.getNumTransp(),a.getNumCanales());
            double anchoCanal = a.getAncho() / ((double)a.getNumCanales() - 1);
            double stepLength = a.getLongitud() / 64.0;
            //double stepLength = 1.0;
            //double anchoCanal = 1.0;
            foreach (List<Coordenada>[] i in salida)
            {
                foreach (List<Coordenada> j in i)
                {
                    for (int k = 0; k < j.Count; k++)
                    {
                        j[k] = new Coordenada((j[k].getX()-(a.getNumCanales()-1)/2) * anchoCanal, j[k].getY() * stepLength) + a.getInicio();
                        j[k].rotate(a.getAngulo());
                        //j[k] = new Coordenada(j[k].x, j[k].y) + a.inicio;
                        
                    }
                }
            }
            //int offsetIndex = 0;
            //foreach (List<Coordenada> i in salida[0])
            //{
            //    i[0].y += a.offsetInicio[offsetIndex];
            //    offsetIndex++;
            //}
            //offsetIndex = 0;
            //foreach (List<Coordenada> i in salida[1])
            //{
            //    i[i.Count - 1].y += a.offsetFinal[offsetIndex];
            //    offsetIndex++;
            //}

            return salida;
        }
    }
}

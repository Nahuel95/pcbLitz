using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litz
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
                int layer = 2 * i / n;
                int y = 0;
                for (int j = 0; j < 4 * n + 2; j++)
                {

                    salida[layer][i].Add(new Coordenada(via, y));
                    if (j % 2 != 0)
                    {
                        if (via == 4 && step == 1)
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
        public static List<Coordenada>[][] createList(Arista a)
        {
            List<Coordenada>[][] salida = create(a.numCanales);
            double stepLength = a.longitud / (double)a.numTrans;
            foreach (List<Coordenada>[] i in salida)
            {
                foreach (List<Coordenada> j in i)
                {
                    for (int k = 0; k < j.Count; k++)
                    {
                        j[k] = new Coordenada(0, j[k].y * stepLength) + a.inicio;
                    }
                }
            }

            return salida;
        }
    }
}

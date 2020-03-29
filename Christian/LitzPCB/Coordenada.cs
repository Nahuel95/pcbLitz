using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litz
{
    public class Coordenada
    {
        public double x;
        public double y;
        public Coordenada(double x, double y) {
            this.x = x;
            this.y = y;
        }
        public static Coordenada operator +(Coordenada a, Coordenada b)
        {
            return new Coordenada(a.x + b.x, a.y + b.y);
        }
        public static Coordenada operator -(Coordenada a, Coordenada b)
        {
            return new Coordenada(a.x - b.x, a.y - b.y);
        }

        public override string ToString()
        {
            return ("(" + this.x.ToString() + " ; " + this.y.ToString() + ")");
        }
        public static double distancia(Coordenada a, Coordenada b)
        {
            return Math.Sqrt(Math.Pow(a.x-b.x,2)+Math.Pow(a.y-b.y,2));
        }
        public void rotate(double angulo)
        {
            double angle = (angulo*45.0) * (Math.PI)/180.0;
            double newX = this.x * Math.Cos(angle) - this.y * Math.Sin(angle);
            double newY = this.x * Math.Sin(angle) + this.y * Math.Cos(angle);

            this.x = newX;
            this.y = newY;
        }
    }

    public class CoordCompare: IComparer<Coordenada>
    {
        public int Compare(Coordenada a, Coordenada b)
        {
            if(a.y > b.y)
            {
                return 1;
            }else if (a.y < b.y)
            {
                return -1;
            }else
            {
                return 0;
            }
        }
    }
}

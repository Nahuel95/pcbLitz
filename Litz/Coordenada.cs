using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litz
{
    class Coordenada
    {
        public double x;
        public double y;
        public Coordenada(double x, double y) {
            this.x = x;
            this.y = y;
        }
        public static Coordenada operator +(Point a, Point b)
        {
            return new Point(a.x + b.x, a.y + b.y);
        }
        public static Coordenada operator -(Point a, Point b)
        {
            return new Point(a.x - b.x, a.y - b.y);
        }

        public override string ToString()
        {
            return ("(" + this.x.ToString() + " ; " + this.y.ToString() + ")");
        }
        public static double distancia(Coordenada a, Coordenada b)
        {
            return Math.sqrt((a.x-b.x)^2+(a.y-b.y)^2);
        }
    }
}

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
            return Math.Sqrt(Math.Pow(a.x-b.x,2+Math.Pow(a.y-b.y,2)));
        }
        public void rotate(double angulo)
        {
            double angle = angulo * (2 * Math.PI)/360.0;
            this.x = this.x * Math.Cos(angle) - this.y * Math.Sin(angle);
            this.y = this.x * Math.Sin(angle) + this.y * Math.Cos(angle);
        }
    }
}

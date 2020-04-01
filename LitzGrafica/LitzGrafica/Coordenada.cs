using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitzGrafica
{
    public class Coordenada
    {
        private double x;
        private double y;
        private bool Obturador;

        public Coordenada(double x, double y, bool obturador) {
            this.x = x;
            this.y = y;
            this.Obturador = obturador;
        }

        public bool getObturador()
        {
            return Obturador;
        }

        public void setHerramientaAbajo(bool abierto)
        {
            Obturador = abierto;
        }

        public double getX() {
            return x;
        }

        public double getY() {
            return y;
        }

        public void setX(double x) {
            this.x = x;
        }

        public void setY(double y){ 
            this.y = y;
        }

        public static Coordenada operator +(Coordenada a, Coordenada b)
        {
            return new Coordenada(a.x + b.x, a.y + b.y, a.getObturador()||b.getObturador());
        }
        public static Coordenada operator -(Coordenada a, Coordenada b)
        {
            return new Coordenada(a.x - b.x, a.y - b.y, a.getObturador() || b.getObturador());
        }

        public void rotate(double angle)
        {
            
            double tempX = this.x * Math.Cos(angle) - this.y * Math.Sin(angle);
            double tempY = this.x * Math.Sin(angle) + this.y * Math.Cos(angle);

            this.x = tempX;
            this.y = tempY;
        }

        public override string ToString()
        {
            return ("(" + this.x.ToString() + " ; " + this.y.ToString() + ")");
        }
        public static double distancia(Coordenada a, Coordenada b)
        {
            return Math.Sqrt(Math.Pow((a.x-b.x),2) + Math.Pow((a.y-b.y),2));
        }

        public class CoordCompare : IComparer<Coordenada>
        {
            public int Compare(Coordenada a, Coordenada b)
            {
                if (a.y > b.y)
                {
                    return 1;
                }
                else if (a.y < b.y)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public void OrdenGerber(System.IO.StreamWriter archivo)
        {
            archivo.WriteLine("G01X{0}Y{1}D0{2}*", this.x, this.y, Obturador ? 2 : 1);
        }
    }
}

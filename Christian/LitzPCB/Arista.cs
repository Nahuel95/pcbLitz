using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litz
{
    public class Arista
    {
        public Coordenada inicio;
        public Coordenada final;
        public int numCanales;
        public double[] offsetInicio;
        public double[] offsetFinal;
        public double longitud;
        public double ancho;
        public int numTrans;
        public int angulo; //De 0 a 7, angulo * 45 = medida real.

        public Arista(Coordenada inicio, Coordenada final, int numCanales, double anchoPista, int numTransposiciones, double[] offsetinicio, double[] offsetfinal){
            this.inicio = inicio;
            this.final = final;
            this.numCanales = numCanales;
            this.longitud = Coordenada.distancia(inicio,final);
            this.angulo = (int)Math.Floor(Math.Atan2(final.y-inicio.y, final.x-inicio.x)/(Math.PI/4))-2;
            this.ancho = anchoPista;
            this.numTrans = numTransposiciones;
            this.offsetInicio = offsetinicio;
            this.offsetFinal = offsetfinal;
        }

        public double[] CalcularOffset() {
            return new double[4];
        }
    }
    
}

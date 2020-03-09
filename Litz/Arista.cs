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
        public int numTrans;
        public int angulo; //De 0 a 7, angulo * 45 = medida real.

        public Arista(Coordenada inicio, Coordenada final, int numCanales){
            this.inicio = inicio;
            this.final = final;
            this.numCanales = numCanales;
            this.longitud = Coordenada.distancia(inicio,final);
            this.angulo = Math.floor(Math.atan2(final.y-inicio.y, final.x-inicio.x)/45.0);


        }

<<<<<<< HEAD
        public Arista(Coordenada inicio, Coordenada final)
        {
            this.inicio = inicio;
            this.final = final;
        }

        private double[] CalcularOffset() {
            
=======
        public double[] CalcularOffset() {
            return new double[4];
>>>>>>> 73f9166a3a1ce23afebfb66c3353add2c6bdceb9
        }
    }
    
}

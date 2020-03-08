using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litz
{
    class Arista
    {
        private Coordenada inicio;
        private Coordenada final;
        private int numCanales;
        private double[] offsetInicio;
        private double[] offsetFinal;
        private double longitud;
        private int numTrans;
        private int angulo; //De 0 a 7, angulo * 45 = medida real.

        public Arista(Coordenada inicio, Coordenada final, int numCanales){
            this.inicio = inicio;
            this.final = final;
            this.numCanales = numCanales;
            this.longitud = Coordenada.distancia(inicio,final);
            this.angulo = Math.floor(Math.atan2(final.y-inicio.y, final.x-inicio.x)/45.0);


        }

        private double[] CalcularOffset() {
            
        }
    }
    
}

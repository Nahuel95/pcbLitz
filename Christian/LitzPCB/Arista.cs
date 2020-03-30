using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litz
{
    public class Arista
    {
        private Coordenada inicio;
        private Coordenada final;
        private int numCanales;
        private double[] offsetInicio = { 0,0,0,0,0};
        private double[] offsetFinal = { 0,0,0,0,0};
        private double longitud;
        private double ancho = 1;
        private int numTransposiciones;
        private int angulo; //De 0 a 7, angulo * 45 = medida real.

        public Arista(Coordenada inicio, Coordenada final, int numCanales) {
            this.inicio = inicio;
            this.final = final;
            this.numCanales = numCanales;
            int ang = ((int)radianesAGrados(Math.Atan2(final.getY() - inicio.getY(), final.getX() - inicio.getX())) / 45);
            if (ang < 0) {
                ang += 8;
            }
            this.angulo = ang;
            this.longitud = Coordenada.distancia(inicio, final);
        }

        public Arista(Coordenada inicio, Coordenada final, int numCanales, double espaciado, double anchoCanales){
            this.inicio = inicio;
            this.final = final;
            this.numCanales = numCanales;
            this.ancho = calcularAncho(numCanales, anchoCanales, espaciado);
            int ang = ((int)radianesAGrados(Math.Atan2(final.getY()-inicio.getY(), final.getX()-inicio.getX()))/45);
            if (ang < 0)
            {
                ang += 8;
            }
            this.angulo = ang;
            this.longitud = Coordenada.distancia(inicio, final);

        }

        public Coordenada getInicio() {
            return this.inicio;
        }

        public Coordenada getFinal() {
            return this.final;
        }

        public int getAngulo() {
            return this.angulo;
        }

        public int getNumCanales()
        {
            return this.numCanales;
        }

        public double getLongitud() {
            return this.longitud;
        }

        public int getNumTransp() {
            return this.numTransposiciones;
        }
        public double getAncho()
        {
            return this.ancho;
        }
        public void setAncho(double ancho)
        {
            this.ancho = ancho;
        }

        public void setOffsetInicio(double[] offset) {
            offsetInicio = offset;
        }
        public double[] getOffsetInicio()
        {
            return offsetInicio;
        }
        public void setOffsetFinal(double[] offset)
        {
            offsetFinal = offset;
        }
        public double[] getOffsetFinal()
        {
            return offsetFinal;
        }
        public static double gradosARadianes(double grados) {
            return grados * (Math.PI / 180);
        }

        public static double radianesAGrados(double radianes) {
            return (radianes * 180) / Math.PI;
        }

        private double calcularAncho(int numCanales, double anchoCanales, double espaciado){
            return (numCanales * anchoCanales) + ((numCanales - 1) * espaciado);
        }
        public static int anguloEntreAristas(Arista a, Arista b){
            int aux = 8 - a.angulo;
            int ang = b.angulo + aux;
            int ret = 0;
            ang = ang % 8;
            if (ang >= 4)
            {
                ret = ang - 4;
            }
            else {
                ret = ang + 4;
            }
            return ret;
        }

        /*private Coordenada moverPuntoConAngulo(Coordenada punto, int direcc, double distancia){
            double nuevaX;
            double nuevaY;
            nuevaX = punto.getX() + distancia * Math.Cos(gradosARadianes(direcc*45));
            nuevaY = punto.getY() + distancia * Math.Sin(gradosARadianes(direcc*45));
            return new Coordenada(nuevaX, nuevaY);
        }*/
            
        public static double[] CalcularOffsets(int angulo, int canales, double ancho){ //angulo <- {1, 2, 6, 7}
            double[] ret = new double[canales];
            double anchoCanal = ancho / canales;
            if (angulo == 6)
            {
                angulo = -2;
            }
            else if (angulo == 7) {
                angulo = -1;
            }

            double canalesAux = Convert.ToDouble(canales);
            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = Math.Tan(gradosARadianes(22.5 * angulo)) * anchoCanal * (((canalesAux - 1) / 2) - i) * Math.Sign(angulo);
            }
           
            return ret;
        }

        private string printOffset(double[] offset) {
            string ret= "";
            foreach(double o in offset) {
                ret = ret + (o + " .. ");
            }
            return ret;
        }
        public override string ToString() {
            return "Inicio: " + this.inicio.ToString() + "\n" +
                    "Final: " + this.final.ToString() + "\n" +
                    "Canales: " + this.numCanales + "\n" +
                    "Offsets iniciales: " + printOffset(this.offsetInicio) + "\n" +
                    "Offsets finales: " + printOffset(this.offsetFinal) + "\n" +
                    "Longitud:" + this.longitud + "\n" +
                    "Ancho: " + this.ancho + "\n" +
                    "Numero de transposiciones: " + this.numTransposiciones + "\n" +
                    "Angulo: " + this.angulo + " o " + this.angulo * 45 + " grados " + "\n";
        }
    }
    
}

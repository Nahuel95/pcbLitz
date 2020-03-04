using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litz
{
    class Traductor
    {
        private static String startCommand = "G54";

        private static List<Coordenada> GerberACoordenadas(String buffer)
        {
            List<Coordenada> ret = new List<Coordenada>();
            int cursor = buffer.IndexOf(startCommand);
            int eol;
            while (buffer[cursor] != 'M') {
                cursor = buffer.IndexOf(Environment.NewLine, cursor) + 1;
                eol = buffer.IndexOf(Environment.NewLine, cursor);
                Coordenada aux = RenglonACoordenada(buffer.Substring(cursor, eol));
                ret.Add(aux);
            }
            return ret;

        }

        private static Coordenada RenglonACoordenada(String renglon) {
            int startPosX = renglon.IndexOf("X") + 1;
            int finalPosX = renglon.IndexOf("Y") - 1;
            int lengthX = finalPosX - startPosX;
            int startPosY = renglon.IndexOf("Y") + 1;
            int finalPosY = renglon.IndexOf("D") - 1;
            int lengthY = finalPosY - startPosY;

            double x = Double.Parse(renglon.Substring(startPosX, lengthX));
            double y = Double.Parse(renglon.Substring(startPosY, lengthY));

            return new Coordenada(x, y);

        }
    }
}

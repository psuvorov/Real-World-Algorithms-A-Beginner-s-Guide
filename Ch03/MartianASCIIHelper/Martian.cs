using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MartianASCIIHelper
{
    public static class Martian
    {
        public static IEnumerable<double> GetCameraRotations(string message)
        {
            if (!IsASCIIMessage(message))
                throw new InvalidEnumArgumentException();

            var hexToRadiansTable = GetHexToRadiansTable();

            foreach (var c in message)
            {
                var charToBinary = CharToBinary(c);
                var p1Int = Convert.ToInt32(charToBinary.Substring(0, 4), 2);
                var p2Int = Convert.ToInt32(charToBinary.Substring(4), 2);

                var h1 = hexToRadiansTable[p1Int].Item2;
                var h2 = hexToRadiansTable[p2Int].Item2;

                yield return h1;
                yield return h2;
            }
        }

        private static bool IsASCIIMessage(string message)
        {
            return message.All(c => ((int) c) <= 127);
        }

        private static List<Tuple<string, double>> GetHexToRadiansTable()
        {
            var res = new List<Tuple<string, double>>();
            var h = 0x0;
            for (double i = 0; i < 2*Math.PI; i += Math.PI/8) // Let's divide 2*PI into 16 parts, so the minimum degree is PI/8
            {
                res.Add(new Tuple<string, double>(h.ToString("X"), i));
                h++;
            }

            return res;
        }
        
        private static string CharToBinary(char c)
        {
            return Convert.ToString(c, 2).PadLeft(8, '0');
        }
        
    }
}
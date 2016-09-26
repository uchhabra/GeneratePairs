using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCharPairsImpl
{
    public static class GenerateRandom
    {
        private static Random objStaticRandomGenerator;

        public static int GetRandomNumber(int iMin, int iMax)
        {
            if (objStaticRandomGenerator == null)
            {
                objStaticRandomGenerator = new Random();
            } 
            return objStaticRandomGenerator.Next(iMin, iMax);
        }

        public static char GetRandomCharRepresentedAsNumber(int iMin, int iMax)
        {
            if (objStaticRandomGenerator == null)
            {
                objStaticRandomGenerator = new Random();
            }

            //generate next number
            var charNum = objStaticRandomGenerator.Next(iMin, iMax);

            return (char)('a' + charNum);
        }
    }
}

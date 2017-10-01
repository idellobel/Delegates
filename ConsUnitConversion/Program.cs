using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsUnitConversion
{
    class Program
    {
        delegate double ConvertUnit(double value);

        public double MileToKm(double mile)
        {
            double km = mile * 1.609344;
            Console.WriteLine($"{mile} miles = {Math.Round(km, 3)} km");
            return km;
        }

        public double CelsiusToKelvin(double celsius)
        {
            double kelvin = celsius + 273.15;
            Console.WriteLine($"{celsius} °C = {Math.Round(kelvin, 3)} Kelvin");
            return kelvin;
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            double input = 20f;

            ConvertUnit cu = null;
            cu += p.MileToKm;
            cu += p.CelsiusToKelvin;
            cu += delegate (double pound)
            {
                double kg = pound * 0.45359237;
                Console.WriteLine($"{pound} lbs = {Math.Round(kg, 3)} kg");
                return kg;
            };

            cu += cal =>
            {
                double kj = cal * 4.184;
                Console.WriteLine($"{cal} cal = {Math.Round(kj, 3)} kJ");
                return kj;
            };

            cu?.Invoke(input);

            Console.ReadKey();
        }
    }
}

using LibCafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLightSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            int switchs = 5; // variabele om de lichten aan en uit te schakelen = 5
            LightSwitch lightSwitch = new LightSwitch(switchs); // LichtSwitch instantie
            lightSwitch.LightsOn += LightSwitch_LightsOn;
            lightSwitch.LightsOff += LightSwitch_LightsOff;
            Console.WriteLine($"\n");
            for (int i = 0; i < switchs; i++)
            {
                try
                {
                    lightSwitch.Switchlights();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            Console.ReadKey();
        }
        private static void LightSwitch_LightsOff(object sender, EventArgs e)
        {
            Console.WriteLine("Lights are off - all dark");
        }

        private static void LightSwitch_LightsOn(object sender, LightsOnEventArgs e)
        {
            Console.WriteLine($"{e.Color} lights are on");
        }
    }
}

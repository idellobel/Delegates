using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCafe
{
    public delegate void LightsOnHandler(object sender, LightsOnEventArgs e); //declaratie delegates
    public delegate void LightsOffHandler(object sender, EventArgs e);

    public class LightSwitch
    {


        public event LightsOnHandler LightsOn; //declaratie events
        public event LightsOffHandler LightsOff;

        private int switchCount;

        public int SwitchCount { get { return switchCount; } } // c#6.0 enkel get in property: set enkel in constructor
        public int MaxSwitch  { get; }

        public LightSwitch(int maxSwitch)
        {
            MaxSwitch = maxSwitch;
        }


        public void Switchlights() // methode waarbij de lichten aan- of uitgezet worden, alternerend
        {
            if (switchCount >= MaxSwitch ) throw new Exception("to turn the lights on and off is NOT 5 times");
            LightsOn?.Invoke(this, new LightsOnEventArgs()); //aanroep event "LightsOn" als niet null en geef kleur
           
            LightsOff?.Invoke(this, EventArgs.Empty ); // aabroep event "LightsOff.
            switchCount++;
        }
    }

    public class LightsOnEventArgs : EventArgs // Geef de kleur mee met de EventArgs dmv custom klasse LightsOnEventArgs
    {
        private static string[] Colors = { "Red", "Blue", "Green", "White" };
        public static Random random = new Random();

        public string Color { get; }
        

        public LightsOnEventArgs()
        {
            Color = Colors[random.Next(0, Colors.Length)]; //willekeurige kleur
           
        }
    }
}

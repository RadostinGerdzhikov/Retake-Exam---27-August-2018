namespace _01_Hogswatch
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Text;
    using System.Globalization;
    using System.Numerics;

    class Hogswatch
    {
        static void Main()
        {
            int homes = int.Parse(Console.ReadLine());
            int initialPresents = int.Parse(Console.ReadLine());
            int presents = initialPresents;

            int additionalPresents = 0;
            int homeCommings = 0; 

            for (int home = 1; home <= homes; home++)
            {
                int children = int.Parse(Console.ReadLine());

                if (presents >= children)
                {
                    presents -= children;
                    continue;
                }

                
                int presentsShort = children - presents;
                homeCommings++; 

                
                int presentToTake = (initialPresents / home) * (homes - home) + presentsShort;

                additionalPresents += presentToTake;
                presents += presentToTake - children;
            }

            if (homeCommings == 0)
            {
                Console.WriteLine(presents);
            }
            else
            {
                Console.WriteLine(homeCommings);
                Console.WriteLine(additionalPresents);
            }
        }
    }
}
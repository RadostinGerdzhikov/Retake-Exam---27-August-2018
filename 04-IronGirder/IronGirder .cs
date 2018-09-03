namespace _04_IronGirder
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Text;
    using System.Globalization;
    using System.Numerics;

    class IronGirder
    {
        static void Main()
        {
            var townTime = new Dictionary<string, int>();
            var townPassCount = new Dictionary<string, int>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "Slide rule")
                {
                    break;
                }

                var input = line.Split(new[] { ":", "->" }, StringSplitOptions.RemoveEmptyEntries);
               
                if (input[1] == "ambush")
                {
                    var name = input[0];
                    int passCount = int.Parse(input[2]);

                    if (townTime.ContainsKey(name))
                    {
                        townTime[name] = 0;
                        townPassCount[name] -= passCount;
                    }

                }
                else
                {
                    var name = input[0];
                    int time = int.Parse(input[1]);
                    int passCount = int.Parse(input[2]);


                    if (!townTime.ContainsKey(name))
                    {
                        townTime.Add(name, time);
                        townPassCount.Add(name, 0);
                    }

                    townPassCount[name] += passCount;
                    if (townTime[name] > time || townTime[name] == 0)
                    {
                        townTime[name] = time;
                    }

                }

            }

            foreach (var name in townTime.OrderBy(x => x.Value).ThenBy(x => x.Key).Where(x => x.Value > 0))
            {
                if (townPassCount[name.Key] > 0)
                {
                    Console.WriteLine($"{name.Key} -> Time: {name.Value} -> Passengers: {townPassCount[name.Key]}");
                }
            }
        }
    }
}
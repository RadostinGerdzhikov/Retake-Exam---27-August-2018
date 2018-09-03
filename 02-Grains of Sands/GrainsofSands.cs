namespace _02_GrainsofSandByMe
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Text;
    using System.Globalization;
    using System.Numerics;

    class GrainsofSandByMe
    {
        static void Main()
        {
            var realList = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int magicNum = 0;
            while (true)
            {
                var line = Console.ReadLine();
                if (line == "Mort")
                {
                    break;
                }

                var data = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var command = data[0];
                var index = int.Parse(data[1]);

                if (command == "Add")
                {
                    realList.Add(index);
                }

                else if (command == "Remove")
                {
                    if (!realList.Contains(index))
                    {
                        if (index > -1 && index < realList.Count)
                        {
                            realList.RemoveAt(index);

                        }
                    }
                    realList.Remove(index);
                }

                else if (command == "Replace")
                {
                    int firstNum = int.Parse(data[1]);
                    int secondNum = int.Parse(data[2]);

                    if (realList.Contains(firstNum))
                    {
                        var indexFN = realList.IndexOf(firstNum);
                        realList.Insert(indexFN, secondNum);
                        realList.Remove(firstNum);
                    }
                }

                else if (command == "Increase")
                {
                    
                    if (realList.Exists(n => n >= index))
                    {

                        magicNum = realList.FirstOrDefault(n => n >= index);
                       

                        for (var i = 0; i < realList.Count; i++)
                        {
                            realList[i] += magicNum;
                        }

                    }
                    else
                    {
                        
                        magicNum = realList.Last();
                        for (var i = 0; i < realList.Count; i++)
                        {
                            realList[i] += magicNum;
                        }
                    }

                }

                else if (command == "Collapse")
                {
                    for (var i = realList.Count - 1; i >= 0; i--)
                    {
                        if (realList[i] < index)
                        {
                            realList.Remove(realList[i]);
                        }
                    }
                }

            }

            var result = string.Join(" ", realList);
            Console.WriteLine(result);

        }
    }
}


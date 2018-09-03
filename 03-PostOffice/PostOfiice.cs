namespace _04_PostOfiiceRealByMe
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Text;
    using System.Globalization;
    using System.Numerics;

    class PostOfiice
    {
        static void Main()
        {
            var input = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

            var partOne = input[0];
            var regexPartOne = new Regex(@"(?<symbol>#|\$|%|\*|&)(?<word>[A-Z]+)\k<symbol>");
            var matchOne = regexPartOne.Match(partOne);
            var word = matchOne.Groups["word"].Value;

            for (int i = 0; i < word.Length; i++)
            {
                int currentAscii = word[i];
                char currentChar = word[i];

                var partTwo = input[1];
                var regexTwo = new Regex($@"{currentAscii}:(?<lenght>\d{{2}})");
                var matchTwo = regexTwo.Match(partTwo);
                var length = matchTwo.Groups["lenght"].Value;

                var partThree = input[2];
                var regexThree = new Regex($@"(^| )(?<word>{currentChar}[^ ]{{{length}}})( |$)");

                var matchTrhee = regexThree.Match(partThree);

                var result = matchTrhee.Groups["word"].Value;

                Console.WriteLine(result);


            }


        }
    }
}

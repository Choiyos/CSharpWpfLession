using LessonLibrary.Interface;
using LessonLibrary.Model;
using System;
using System.Text.RegularExpressions;
using System.Windows;


namespace LessonLibrary.Patterns
{
    class SeventhPattern : IPattern, IFoldable
    {
        public PatternResultModel Create(int inputNum)
        {
            int sum = 0;
            string star = string.Empty;
            int starCount = 1;
            int lines = 0;
            for (int i = 1; i <= inputNum; i++)
            {
                var blank = 5;
                var fullBlank = 6;
                for (int k = 1; k <= inputNum; k++)
                {
                    if (starCount <= k)
                    {
                        sum += starCount;
                        star = star.PadRight(sum, '*');
                        sum += blank;
                        star = star.PadRight(sum, ' ');
                        blank++;
                    }
                    else
                    {
                        sum += fullBlank;
                        star = star.PadRight(sum, ' ');
                        fullBlank++;
                    }
                    lines++;
                }
                starCount++;
                star += "\n";
                sum++;
            }
            return new PatternResultModel(star, TextAlignment.Left, lines, this);
        }

        public string CreateFoldedOutput(string message)
        {
            string result = String.Empty;
            string[] splitMessage = message.Split('\n');
            string[] prefixOutput = Create(3).Output.Split('\n');
            int num = splitMessage.Length - 1;
            int prefixBlank = 0;
            int suffixLength = 0;
            string skipMessage = ".  .  .     ";

            for (int i = 0; i < 3; i++)
            {
                prefixBlank += i + 6;
            }
            suffixLength += num + 5;

            for (int i = 0; i < num; i++)
            {
                if (3 <= i)
                {
                    result = result.PadRight(result.Length + skipMessage.Length + prefixBlank, ' ');

                }
                else if (3 == i + 1)
                {
                    result += prefixOutput[i] + skipMessage;
                }
                else
                {
                    result += prefixOutput[i];
                    result = result.PadRight(result.Length + skipMessage.Length, ' ');
                }
                var suffixMatch = Regex.Matches(splitMessage[i], "[*]");
                result += splitMessage[i]
                    .Substring(suffixMatch[suffixMatch.Count - (i + 1)].Index, suffixLength);
                result += "\n";
            }
            return result;
        }
    }
}

using LessonLibrary.Interface;
using System;
using System.Text.RegularExpressions;
using System.Windows;


namespace LessonLibrary.Patterns
{
    public class SeventhPattern : IPattern, IFoldable
    {
        public string Result { get; private set; }

        public TextAlignment Alignment { get; private set; }

        public string FoldedResult { get; private set; }

        public int Lines { get; private set; }

        public void Create(int inputNum)
        {
            if (inputNum < 0 || inputNum > 10000) throw new ArgumentOutOfRangeException();

            int sum = 0;
            string star = string.Empty;
            int starCount = 1;
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
                    Lines++;
                }
                starCount++;
                star += "\n";
                sum++;
            }

            Result = star;
            Alignment = TextAlignment.Left;
        }

        public void CreateFoldedOutput()
        {
            string result = String.Empty;
            string[] splitMessage = Result.Split('\n');
            IPattern prePattern = new SeventhPattern();
            prePattern.Create(3);
            string[] prefixOutput = prePattern.Result.Split('\n');
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

            FoldedResult = result;
        }
    }
}

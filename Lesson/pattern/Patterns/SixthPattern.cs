using System;
using System.Text.RegularExpressions;
using LessonLibrary.Interface;
using System.Windows;

namespace LessonLibrary.Patterns
{
    public class SixthPattern : IPattern, IFoldable
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

            for (int i = 1; i <= inputNum; i++)
            {
                for (int k = 1; k <= i; k++)
                {
                    sum += k;
                    star = star.PadRight(sum, '*') + "\n";
                    sum++;
                    Lines++;
                }
                star += "\n";
                sum++;
            }

            Result = star;
            Alignment = TextAlignment.Left;
        }

        public string CreateFoldedOutput()
        {
            var suffixMatch = Regex.Matches(Result, "\n\n");
            var prefixStartIndex = suffixMatch[3 - 1].Index;
            var suffixStartIndex = suffixMatch[suffixMatch.Count - 2].Index;
            var prefixOutput = Result.Substring(0, prefixStartIndex + 1);
            var suffixOutput = Result.Substring(suffixStartIndex, length: Result.Length - suffixStartIndex);
            FoldedResult = prefixOutput + "\n.\n.\n.\n" + suffixOutput;
            return FoldedResult;
        }
    }
}

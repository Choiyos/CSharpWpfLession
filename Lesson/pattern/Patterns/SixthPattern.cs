using System;
using System.Text.RegularExpressions;
using LessonLibrary.Interface;
using LessonLibrary.Model;
using System.Windows;

namespace LessonLibrary.Patterns
{
    public class SixthPattern : IPattern, IFoldable
    {
        public PatternResultModel Create(int inputNum)
        {
            if (inputNum > 1000) return new PatternResultModel(String.Empty, PatternResult.TooHighNum);
            if (inputNum < 0) return new PatternResultModel(String.Empty, PatternResult.NegativeNum);

            int sum = 0;

            string star = string.Empty;

            int lineCount = 0;

            for (int i = 1; i <= inputNum; i++)
            {
                for (int k = 1; k <= i; k++)
                {
                    sum += k;
                    star = star.PadRight(sum, '*') + "\n";
                    sum++;
                    lineCount++;
                }
                star += "\n";
                sum++;
                lineCount++;
            }
            return new PatternResultModel(star, TextAlignment.Left, lineCount, this);
        }

        public string CreateFoldedOutput(string message)
        {
            var suffixMatch = Regex.Matches(message, "\n\n");
            var prefixStartIndex = suffixMatch[3 - 1].Index;
            var suffixStartIndex = suffixMatch[suffixMatch.Count - 2].Index;
            var prefixOutput = message.Substring(0, prefixStartIndex + 1);
            var suffixOutput = message.Substring(suffixStartIndex, length: message.Length - suffixStartIndex);

            return prefixOutput + "\n.\n.\n.\n" + suffixOutput;
        }
    }
}

using System;
using System.Windows;
using LessonLibrary.Interface;
using LessonLibrary.Model;

namespace LessonLibrary.Patterns
{
    public class FifthPattern : IPattern
    {
        public PatternResultModel Create(int inputNum)
        {
            if (inputNum < 0 || inputNum > 10000) throw new ArgumentOutOfRangeException();

            int sum = 0;
            string star = string.Empty;

            for (int i = 1; i <= inputNum; i++)
            {
                sum += inputNum - i;
                star = star.PadRight(sum, ' ');
                sum += inputNum - i + 1;
                star = star.PadRight(sum, '*') + "\n";
                sum++;
            }
            return new PatternResultModel(star, TextAlignment.Left);
        }
    }
}

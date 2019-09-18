using System;
using System.Windows;
using LessonLibrary.Interface;
using LessonLibrary.Model;

namespace LessonLibrary.Patterns
{
    public class FirstPattern : IPattern
    {
        public PatternResultModel Create(int inputNum)
        {
            if (inputNum > 1000) return new PatternResultModel(String.Empty, PatternResult.TooHighNum);
            if (inputNum < 0) return new PatternResultModel(String.Empty, PatternResult.NegativeNum);

            int sum = 0;

            string star = string.Empty;

            for (int i = 1; i <= inputNum; i++)
            {
                sum += i;
                star = star.PadRight(sum, '*') + "\n";
                sum++;
            }

            return new PatternResultModel(star, TextAlignment.Left);
        }
    }
}

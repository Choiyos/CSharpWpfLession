using System.Windows;
using LessonLibrary.Interface;
using LessonLibrary.Model;

namespace LessonLibrary.Patterns
{
    public class SecondPattern : IPattern
    {
        public PatternResultModel Create(int inputNum)
        {
            int sum = 0;

            string star = string.Empty;

            for (int i = inputNum; i >= 1; i--)
            {
                sum += i;
                star = star.PadRight(sum, '*') + "\n";
                sum++;
            }

            return new PatternResultModel(star, TextAlignment.Right);
        }
    }
}

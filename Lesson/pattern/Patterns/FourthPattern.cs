using System.Windows;
using LessonLibrary.Interface;
using LessonLibrary.Model;

namespace LessonLibrary.Patterns
{
    public class FourthPattern : IPattern
    {
        public PatternResultModel Create(int inputNum)
        {
            int sum = 0;

            string star = string.Empty;

            for (int i = 1; i <= inputNum; i++)
            {
                sum += inputNum - i;
                star = star.PadRight(sum, ' ');
                sum += inputNum;
                star = star.PadRight(sum, '*') + "\n";
                sum++;
            }

            return new PatternResultModel(star, TextAlignment.Left);

        }
    }
}

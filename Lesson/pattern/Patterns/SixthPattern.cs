using LessonLibrary.Interface;
using LessonLibrary.Model;
using System.Windows;

namespace LessonLibrary.Patterns
{
    public class SixthPattern : IPattern
    {
        public PatternResultModel Create(int inputNum)
        {
            int sum = 0;

            string star = string.Empty;

            for (int i = 1; i <= inputNum; i++)
            {
                for (int k = 1; k <= i; k++)
                {
                    sum += k;
                    star = star.PadRight(sum, '*') + "\n";
                    sum++;
                }
                star += "\n";
                sum++;
            }
            return new PatternResultModel(star, TextAlignment.Left);
        }
    }
}

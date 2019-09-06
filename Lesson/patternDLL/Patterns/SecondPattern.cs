using System.Windows;
using lessonLibrary.Interface;
using lessonLibrary.Model;

namespace lessonLibrary.Patterns
{
    public class SecondPattern : IPattern
    {
        public PatternModel Create(int inputNum)
        {
            int sum = 0;

            string star = string.Empty;

            for (int i = inputNum; i >= 1; i--)
            {
                sum += i;
                star = star.PadRight(sum, '*') + "\n";
                sum++;
            }

            return new PatternModel(star, TextAlignment.Right);
        }
    }
}

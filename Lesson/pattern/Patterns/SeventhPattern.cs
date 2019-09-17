using System;
using LessonLibrary.Interface;
using LessonLibrary.Model;
using System.Windows;


namespace LessonLibrary.Patterns
{
    class SeventhPattern : IPattern
    {
        public PatternResultModel Create(int inputNum)
        {
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
                }
                starCount++;
                star += "\n";
                sum++;
            }
            return new PatternResultModel(star, TextAlignment.Left);
        }
    }
}

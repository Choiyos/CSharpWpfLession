using System;
using System.Windows;
using LessonLibrary.Interface;
using LessonLibrary.Model;

namespace LessonLibrary.Patterns
{
    public class ThirdPattern : IPattern
    {
        public PatternResultModel Create(int inputNum)
        {
            int sum = 0;

            string star = string.Empty;

            if (inputNum % 2 != 0)
            {
                // 다이아몬드모양 출력.
                for (int i = 1; i <= inputNum ; i++)
                {
                    if (i % 2 == 0) continue;
                    sum += i;
                    star = star.PadRight(sum, '*') + "\n";
                    sum++;
                }
                for (int i = inputNum-1 ; i >= 1; i--)
                {
                    if (i % 2 == 0) continue;
                    sum += i;
                    star = star.PadRight(sum, '*') + "\n";
                    sum++;
                }
            }
            else
            {
                // 입력값이 짝수이므로 취소.
                return new PatternResultModel(String.Empty, TextAlignment.Center);
            }

            return new PatternResultModel(star, TextAlignment.Center);
        }
    }
}

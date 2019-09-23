using System;
using System.Windows;
using LessonLibrary.Interface;

namespace LessonLibrary.Patterns
{
    public class ThirdPattern : IPattern
    {
        public string Result { get; private set; }
        public TextAlignment Alignment { get; private set; }

        public void Create(int inputNum)
        {
            if (inputNum < 0 || inputNum > 10000) throw new ArgumentOutOfRangeException();

            int sum = 0;

            string star = string.Empty;

            if (inputNum % 2 != 0)
            {
                // 다이아몬드모양 출력.
                for (int i = 1; i <= inputNum; i++)
                {
                    if (i % 2 == 0) continue;
                    sum += i;
                    star = star.PadRight(sum, '*') + "\n";
                    sum++;
                }
                for (int i = inputNum - 1; i >= 1; i--)
                {
                    if (i % 2 == 0) continue;
                    sum += i;
                    star = star.PadRight(sum, '*') + "\n";
                    sum++;
                }

                Result = star;
                Alignment = TextAlignment.Center;
            }
            else
            {
                // 입력값이 짝수이므로 취소.
                Result = String.Empty;
            }
        }
    }
}

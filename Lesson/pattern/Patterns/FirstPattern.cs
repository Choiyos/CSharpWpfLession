using System;
using System.Windows;
using LessonLibrary.Interface;

namespace LessonLibrary.Patterns
{
    public class FirstPattern : IPattern
    {
        public string Result { get; private set; }
        public TextAlignment Alignment { get; private set; }

        public void Create(int inputNum)
        {
            if (inputNum < 0 || inputNum > 10000) throw new ArgumentOutOfRangeException();

            int sum = 0;

            string star = string.Empty;

            for (int i = 1; i <= inputNum; i++)
            {
                sum += i;
                star = star.PadRight(sum, '*') + "\n";
                sum++;
            }

            Result = star;
            Alignment = TextAlignment.Left;
        }
    }
}

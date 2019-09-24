using System;
using System.Windows;
using LessonLibrary.Interface;

namespace LessonLibrary.Patterns
{
    public class SecondPattern : IPattern
    {
        public string Result { get; private set; }

        public TextAlignment Alignment { get; private set; }

        public void Create(int inputNum)
        {
            if (inputNum < 0 || inputNum > 10000) throw new ArgumentOutOfRangeException();
            int sum = 0;
            string star = string.Empty;

            for (int i = inputNum; i >= 1; i--)
            {
                sum += i;
                star = star.PadRight(sum, '*') + "\n";
                sum++;
            }

            Result = star;
            Alignment = TextAlignment.Right;
        }
    }
}

﻿using System.Windows;
using lessonLibrary.Interface;
using lessonLibrary.Model;

namespace lessonLibrary.Patterns
{
    public class FourthPattern : IPattern
    {
        public PatternModel Create(int inputNum)
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

            return new PatternModel(star, TextAlignment.Left);

        }
    }
}

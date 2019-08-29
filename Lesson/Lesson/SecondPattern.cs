using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Lesson
{
    public class SecondPattern : IPattern
    {
        public string PrintPattern(TextBlock txtDisplay, int inputNum)
        {
            int sum = 0;

            string star = string.Empty;

            txtDisplay.TextAlignment = TextAlignment.Right;
            for (int i = inputNum; i >= 1; i--)
            {
                sum += i;
                star = star.PadRight(sum, '*') + "\n";
                sum++;
            }

            return star;
        }
    }
}

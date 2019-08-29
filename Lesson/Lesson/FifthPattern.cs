using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Lesson
{
    public class FifthPattern : IPattern
    {
        public string PrintPattern(TextBlock txtDisplay, int inputNum)
        {
            int sum = 0;

            string star = string.Empty;

            txtDisplay.TextAlignment = TextAlignment.Left;

            for (int i = 1; i <= inputNum; i++)
            {
                sum += inputNum - i;
                star = star.PadRight(sum, ' ');
                sum += inputNum - i + 1;
                star = star.PadRight(sum, '*') + "\n";
                sum++;
            }

            return star;
        }
    }
}

using System.Windows;
using lessonLibrary.Interface;
using lessonLibrary.Model;

namespace lessonLibrary.Patterns
{
    public class ThirdPattern : IPattern
    {
        public PatternModel Create(int inputNum)
        {
            int sum = 0;

            string star = string.Empty;

            if (inputNum % 2 != 0)
            {
                // 다이아몬드모양 출력.
                for (int i = 1; i <= inputNum / 2; i++)
                {
                    sum += i;
                    star = star.PadRight(sum, '*') + "\n";
                    sum++;
                }
                for (int i = (inputNum / 2) + 1; i >= 1; i--)
                {
                    sum += i;
                    star = star.PadRight(sum, '*') + "\n";
                    sum++;
                }
            }
            else
            {
                // 입력값이 짝수이므로 취소.
                MessageBox.Show("패턴 3은 홀수 라인만 입력 가능합니다.");
                return new PatternModel(string.Empty, TextAlignment.Center);
            }

            return new PatternModel(star, TextAlignment.Center);
        }
    }
}

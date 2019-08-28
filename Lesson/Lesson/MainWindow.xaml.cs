using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lesson
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _pattern = 1;
        private PatternSelectWindow _patternSelectWindow = null;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {

            if (int.TryParse(txtbxInput.Text, out int inputNum)
                && (inputNum > 0 && inputNum < 101))
            {
                int sum = 0;
                string star = string.Empty;
                //lines가 홀수면 메시지 띄우기.

                switch (_pattern)
                {
                    case 1:
                        // 패턴1 출력.
                        txtDisplay.TextAlignment = TextAlignment.Left;
                        for (int i = 1; i <= inputNum; i++)
                        {
                            sum += i;
                            star = star.PadRight(sum, '*') + "\n";
                            sum++;
                        }
                        break;
                    case 2:
                        // 패턴2 출력.
                        txtDisplay.TextAlignment = TextAlignment.Right;
                        for (int i = inputNum; i >= 1; i--)
                        {
                            sum += i;
                            star = star.PadRight(sum, '*') + "\n";
                            sum++;
                        }
                        break;
                    case 3:
                        if (inputNum % 2 != 0)
                        {
                            // 다이아몬드모양 출력.
                            txtDisplay.TextAlignment = TextAlignment.Center;
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
                            return;
                        }
                        break;
                    default:
                        break;
                }

                txtDisplay.Text = star;
            }
            else
            {
                MessageBox.Show("정상적인 숫자 범위를 입력해주세요(1~100).");
                txtbxInput.Text = "Pattern 1";
            }
        }


        private void BtnPatternShow_Click(object sender, RoutedEventArgs e)
        {
            if (_patternSelectWindow == null)
            {
                _patternSelectWindow = new PatternSelectWindow();
                _patternSelectWindow.OnChildSelectPatternEvent += new EventHandler<string>(psw_OnChildSelectPatternEvent);
                _patternSelectWindow.Owner = this;
                _patternSelectWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                _patternSelectWindow.ShowDialog();
            }
        }

        private void psw_OnChildSelectPatternEvent(object sender, string patternName)
        {
            if (!string.IsNullOrEmpty(patternName) && int.TryParse(patternName.Substring(patternName.Length - 1, 1), out int parsedPattern))
            {
                _pattern = parsedPattern;
                txtPattern.Text = patternName;
                if (_patternSelectWindow != null)
                {
                    _patternSelectWindow.OnChildSelectPatternEvent -= new EventHandler<string>(psw_OnChildSelectPatternEvent);
                    _patternSelectWindow.Close();
                    _patternSelectWindow = null;
                }
            }
            else
            {
                _patternSelectWindow.OnChildSelectPatternEvent -= new EventHandler<string>(psw_OnChildSelectPatternEvent);
                _patternSelectWindow = null;
            }
        }
    }
}

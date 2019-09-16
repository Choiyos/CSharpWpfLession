using LessonLibrary;
using LessonLibrary.Model;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using static System.Int32;

namespace Lesson
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow
    {
        private readonly Pattern _pattern = Pattern.Instance;

        private PatternSelectWindow _patternSelectWindow;

        private string _totalOutput = String.Empty;

        private string _prefixOutput = String.Empty;

        private string _suffixOutput = String.Empty;

        private readonly string skipText = "\n.\n.\n.\n";

        // 현재 : 세 번째 별까지 출력
        private const int StartOutputLineNum = 8;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            Print();
        }

        private void TxtbxInput_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;
            Print();
            txtbxInput.SelectAll();
        }

        private void Print()
        {
            if (_pattern.Create(txtbxInput.Text))
            {
                ApllyPattern(_pattern.CurrentResult);

                if (_pattern.ResultStorageCount > 1)
                {
                    btnNextResult.IsEnabled = true;
                    btnPreviousResult.IsEnabled = false;
                }

                txtbxResult.Text = "1";
                txtMaxHistory.Text = "/ " + _pattern.ResultStorageCount.ToString();
            }
            else
            {
                txtbxInput.Text = "1";
            }
        }

        private void BtnPatternShow_Click(object sender, RoutedEventArgs e)
        {
            if (_patternSelectWindow != null) return;
            _patternSelectWindow = new PatternSelectWindow
            {
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            _patternSelectWindow.OnChildSelectPatternEvent += (o, s) =>
            {
                txtPattern.Text = s;
                _patternSelectWindow = null;
            };
            _patternSelectWindow.Closing += (o, args) =>
            {
                _patternSelectWindow = null;
            };
            _patternSelectWindow.ShowDialog();
        }

        private void BtnPreviousResult_Click(object sender, RoutedEventArgs e)
        {
            ApllyPattern(_pattern.GetPreviousResult());
            if (_pattern.ResultStorageOffset == 1)
            {
                btnPreviousResult.IsEnabled = false;
                btnNextResult.IsEnabled = true;
            }
            else
            {
                btnNextResult.IsEnabled = true;
                btnPreviousResult.IsEnabled = true;
            }
        }

        private void BtnNextResult_Click(object sender, RoutedEventArgs e)
        {
            ApllyPattern(_pattern.GetNextResult());
            if (_pattern.ResultStorageOffset == _pattern.ResultStorageCount)
            {
                btnNextResult.IsEnabled = false;
                btnPreviousResult.IsEnabled = true;
            }
            else
            {
                btnNextResult.IsEnabled = true;
                btnPreviousResult.IsEnabled = true;
            }
        }

        private void TxtbxResult_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;
            var textBox = (TextBox)sender;
            if (TryParse(textBox.Text, out var offset)
                && offset > 0 && offset <= _pattern.ResultStorageCount)
            {
                ApllyPattern(_pattern.GetResult(offset));
                textBox.SelectAll();
            }
            else
            {
                if (_pattern.ResultStorageCount == 0)
                    MessageBox.Show("아직 생성된 패턴이 없습니다.");
                else
                    MessageBox.Show("1부터 " + _pattern.ResultStorageCount + "까지의 숫자만 입력해주세요!");

                textBox.Text = _pattern.ResultStorageOffset.ToString();
                return;
            }

            if (_pattern.ResultStorageOffset == 1)
            {
                btnPreviousResult.IsEnabled = false;

                if (_pattern.ResultStorageCount > 1) btnNextResult.IsEnabled = true;
            }
            else if (_pattern.ResultStorageOffset == _pattern.ResultStorageCount)
            {
                btnNextResult.IsEnabled = false;
                btnPreviousResult.IsEnabled = true;
            }
            else
            {
                btnNextResult.IsEnabled = true;
                btnPreviousResult.IsEnabled = true;
            }
        }

        private void ApllyPattern(PatternResultModel result)
        {
            if (result.Lines > Pattern.MaxLineInputNum * 2)
            {
                SplitOutput(result.Output);
                txtDisplay.Text = _prefixOutput + skipText + _suffixOutput;
                txtDisplay.TextAlignment = result.TextAlignment;
            }
            else
            {
                btnShowOrHide.Visibility = Visibility.Hidden;
                btnShowOrHide.Content = "Show All";
                txtDisplay.Text = result.Output;
                txtDisplay.TextAlignment = result.TextAlignment;
            }

            txtbxResult.Text = _pattern.ResultStorageOffset.ToString();
        }

        private void SplitOutput(string output)
        {
            // 펼쳐놓은 상태에서 RecodeNum을 이용해 새로고침할 경우를 위한 텍스트 초기화
            btnShowOrHide.Content = "Show All";
            btnShowOrHide.Visibility = Visibility.Visible;
            _totalOutput = output;

            int prefixStartIndex = Regex.Matches(output, "\n")[StartOutputLineNum].Index;

            _prefixOutput = output.Substring(0, length: prefixStartIndex);

            MatchCollection suffixMatch = Regex.Matches(output, "\n\n");

            int suffixStartIndex = suffixMatch[suffixMatch.Count - 2].Index;

            _suffixOutput = output.Substring(suffixStartIndex, length: output.Length - suffixStartIndex);
        }

        private void BtnShowOrHide_OnClick(object sender, RoutedEventArgs e)
        {
            if (btnShowOrHide.Content.ToString() == "Show All")
            {
                btnShowOrHide.Content = "Hide";
                txtDisplay.Text = _totalOutput;
            }
            else
            {
                btnShowOrHide.Content = "Show All";
                txtDisplay.Text = _prefixOutput + skipText + _suffixOutput;
            }
        }
    }
}

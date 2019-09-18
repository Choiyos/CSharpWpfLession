using LessonLibrary;
using LessonLibrary.Model;
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
        /// <summary>
        /// 패턴 라이브러리의 인스턴스. 
        /// </summary>
        private readonly Pattern _pattern = Pattern.Instance;

        /// <summary>
        /// 패턴 변경 버튼을 누르면 띄워질 자식 윈도우
        /// </summary>
        private PatternSelectWindow _patternSelectWindow;

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

        /// <summary>
        /// 텍스트박스에 입력된 숫자만큼 별을 출력한다.
        /// </summary>
        private void Print()
        {
            if (_pattern.Create(txtbxInput.Text))
            {
                ApplyResult(_pattern.CurrentResult);

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
            ApplyResult(_pattern.GetPreviousResult());
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
            ApplyResult(_pattern.GetNextResult());
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
                ApplyResult(_pattern.GetResult(offset));
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

        /// <summary>
        /// Print나 Storage의 출력값을 적용한다.
        /// 출력 값이 너무 길 경우 해당 패턴에 요약함수가 있을 때 요약함수를 호출한다.
        /// </summary>
        /// <param name="result">TextBlock에 적용해야할 결괏값.</param>
        private void ApplyResult(PatternResultModel result)
        {
            // 임의적으로 표현되는 줄 수가 입력가능 줄 수의 2배를 넘으면 접힌 결괏값으로 표현하도록 설정했음.
            if (result.Lines > Pattern.MaxLineInputNum * 2)
            {
                _pattern.FoldOutput(result);

                // 펼쳐놓은 상태에서 RecodeNum을 이용해 새로고침할 경우를 위한 텍스트 초기화.
                btnShowOrHide.Content = "Show All";
                btnShowOrHide.Visibility = Visibility.Visible;

                txtDisplay.Text = _pattern.FoldedOutput;
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

        private void BtnShowOrHide_OnClick(object sender, RoutedEventArgs e)
        {
            if (btnShowOrHide.Content.ToString() == "Show All")
            {
                btnShowOrHide.Content = "Fold";
                txtDisplay.Text = _pattern.UnfoldedOutput;
            }
            else
            {
                btnShowOrHide.Content = "Show All";
                txtDisplay.Text = _pattern.FoldedOutput;
            }
        }
    }
}

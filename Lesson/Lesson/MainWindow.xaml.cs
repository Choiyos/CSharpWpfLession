using LessonLibrary;
using LessonLibrary.Interface;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static System.Int32;

namespace Lesson
{
    /// <summary>
    ///     MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow
    {
        private readonly NavigationHistory _history = new NavigationHistory(PatternService.MaxInputLine);

        private readonly PatternService _service = new PatternService();

        /// <summary>
        ///     패턴 변경 버튼을 누르면 띄워질 자식 윈도우
        /// </summary>
        private PatternSelectWindow _patternSelectWindow;

        public MainWindow()
        {
            InitializeComponent();
            _service.ChangePattern(txtPattern.Text);
        }

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            CreateNewPattern();
        }

        private void CreateNewPattern()
        {
            if (!_history.PushPattern(GeneratePattern())) return;
            ApplyResult(_history.GetCurrentPattern());
            CheckMovable();
            if (_history.Count == 1)
                btnEdit.Visibility = Visibility.Visible;
            txtbxResult.Text = "1";
            txtMaxHistory.Text = "/ " + _history.Count;
        }

        private void TxtbxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;
            CreateNewPattern();
            txtbxInput.SelectAll();
        }

        private IPattern GeneratePattern()
        {
            if (TryParse(txtbxInput.Text, out var num))
            {
                var pattern = _service.Create(num);
                if (string.IsNullOrEmpty(pattern.Result))
                {
                    MessageBox.Show("패턴 3은 홀수 라인만 입력 가능합니다.");
                    txtbxInput.Text = "1";
                    return null;
                }

                return pattern;
            }

            MessageBox.Show("1부터 " + PatternService.MaxInputLine + "까지의 숫자만 입력해주세요!");
            txtbxInput.Text = "1";
            return null;
        }

        private void BtnPatternShow_Click(object sender, RoutedEventArgs e)
        {
            if (_patternSelectWindow != null) return;
            _patternSelectWindow = new PatternSelectWindow
            {
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            _patternSelectWindow.OnChildSelectPatternEvent += (o, patternName) =>
            {
                _service.ChangePattern(patternName);
                txtPattern.Text = patternName;
                _patternSelectWindow = null;
            };
            _patternSelectWindow.Closing += (o, args) => { _patternSelectWindow = null; };
            _patternSelectWindow.ShowDialog();
        }

        private void BtnPreviousResult_Click(object sender, RoutedEventArgs e)
        {
            var patternResultModel = _history.GetPreviousPattern();
            ApplyResult(patternResultModel);
            CheckMovable();
        }

        private void BtnNextResult_Click(object sender, RoutedEventArgs e)
        {
            var patternResultModel = _history.GetNextPattern();
            ApplyResult(patternResultModel);
            CheckMovable();
        }

        private void TxtbxResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;
            var textBox = (TextBox) sender;
            if (TryParse(textBox.Text, out var index)
                && index > 0 && index <= _history.Count)
            {
                ApplyResult(_history.GetPattern(index - 1));
                textBox.SelectAll();
            }
            else
            {
                if (_history.Count == 0)
                    MessageBox.Show("아직 생성된 패턴이 없습니다.");
                else
                    MessageBox.Show("1부터 " + _history.Count + "까지의 숫자만 입력해주세요!");
                textBox.Text = (_history.CurrentIndex+1).ToString();
                return;
            }

            CheckMovable();
        }

        /// <summary>
        ///     Print나 Storage의 출력값을 적용한다.
        ///     출력 값이 너무 길 경우 해당 패턴에 요약함수가 있을 때 요약함수를 호출한다.
        /// </summary>
        /// <param name="pattern">TextBlock에 적용해야할 결괏값.</param>
        private void ApplyResult(IPattern pattern)
        {
            if (pattern == null) throw new ArgumentNullException(nameof(pattern));
            // 임의적으로 표현되는 줄 수가 입력가능 줄 수의 2배를 넘으면 접힌 결괏값으로 표현하도록 설정했음.
            if ((pattern is IFoldable foldable)&&foldable.Lines > PatternService.MaxInputLine * 2)
            {
                foldable.CreateFoldedOutput();

                // 펼쳐놓은 상태에서 RecodeNum을 이용해 새로고침할 경우를 위한 텍스트 초기화.
                btnShowOrHide.Content = "Show All";
                btnShowOrHide.Visibility = Visibility.Visible;

                txtDisplay.Text = foldable.FoldedResult;
                txtDisplay.TextAlignment = pattern.Alignment;
            }
            else
            {
                btnShowOrHide.Visibility = Visibility.Hidden;
                btnShowOrHide.Content = "Show All";
                txtDisplay.Text = pattern.Result;
                txtDisplay.TextAlignment = pattern.Alignment;
            }

            txtbxResult.Text = (_history.CurrentIndex+1).ToString();
        }

        private void BtnShowOrHide_OnClick(object sender, RoutedEventArgs e)
        {
            if (btnShowOrHide.Content.ToString() == "Show All")
            {
                btnShowOrHide.Content = "Fold";
                txtDisplay.Text = _history.GetCurrentPattern().Result;
            }
            else
            {
                btnShowOrHide.Content = "Show All";
                txtDisplay.Text = ((IFoldable) _history.GetCurrentPattern()).FoldedResult;
            }
        }

        private void CboIncrease_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TryParse(((ComboBoxItem) e.AddedItems[0]).Content.ToString(), out var value))
            {
                _history.MoveValue = value;
                CheckMovable();
            }
        }

        private void CheckMovable()
        {
            btnNextResult.IsEnabled = _history.IsHistoryMoveNext();

            btnPreviousResult.IsEnabled = _history.IsHistoryMovePrevious();
        }

        private void BtnEdit_OnClick(object sender, RoutedEventArgs e)
        {
            if (!_history.ReplacePattern(GeneratePattern(), _history.CurrentIndex)) return;
            ApplyResult(_history.GetCurrentPattern());
            CheckMovable();
        }
    }
}
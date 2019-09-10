using LessonLibrary;
using LessonLibrary.Model;
using System.Windows;
using System.Windows.Controls;

namespace Lesson
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow
    {
        private readonly Pattern _pattern = Pattern.Instance;

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

        private void Print()
        {
            if (_pattern.Create(txtbxInput.Text))
            {
                txtDisplay.Text = _pattern.PatternResult;
                txtDisplay.TextAlignment = _pattern.TextAlignment;
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
                MessageBox.Show("1부터 100까지의 숫자만 입력 가능합니다.");
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
            if (int.TryParse(textBox.Text, out var offset)
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

        private void ApllyPattern(PatternResultModel pattern)
        {
            txtDisplay.Text = pattern.Content;
            txtDisplay.TextAlignment = pattern.TextAlignment;
            txtbxResult.Text = _pattern.ResultStorageOffset.ToString();
        }
    }
}

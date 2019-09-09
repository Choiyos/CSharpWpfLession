using LessonLibrary;
using System.Windows;
using System.Windows.Controls;
using LessonLibrary.Model;

namespace Lesson
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow
    {
        private readonly Pattern _pattern = Pattern.Instance;

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

                if (_pattern.MaxHistory > 1)
                {
                    btnNextHistory.IsEnabled = true;
                    btnPreviousHistory.IsEnabled = false;
                }

                txtbxHistory.Text = "1";
                txtMaxHistory.Text = "/ " + _pattern.MaxHistory.ToString();
            }
            else
            {
                txtbxInput.Text = "1";
                MessageBox.Show("1부터 100까지의 숫자만 입력 가능합니다.");
            }
        }

        private void BtnPatternShow_Click(object sender, RoutedEventArgs e)
        {
            PatternSelectWindow patternSelectWindow = new PatternSelectWindow();

            patternSelectWindow.Closing += PatternSelectWindow_Closing;
            patternSelectWindow.Owner = this;
            patternSelectWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            patternSelectWindow.ShowDialog();
        }

        private void PatternSelectWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPattern.Text = _pattern.PatternName;
        }

        private void BtnPreviousHistory_Click(object sender, RoutedEventArgs e)
        {
            ApllyPattern(_pattern.GetPreviousHistory());

            if (_pattern.CurrentHistory == 1)
            {
                btnPreviousHistory.IsEnabled = false;
                btnNextHistory.IsEnabled = true;
            }
            else
            {
                btnNextHistory.IsEnabled = true;
                btnPreviousHistory.IsEnabled = true;
            }
        }

        private void BtnNextHistory_Click(object sender, RoutedEventArgs e)
        {
            ApllyPattern(_pattern.GetNextHistory());

            if (_pattern.CurrentHistory == _pattern.MaxHistory)
            {
                btnNextHistory.IsEnabled = false;
                btnPreviousHistory.IsEnabled = true;
            }
            else
            {
                btnNextHistory.IsEnabled = true;
                btnPreviousHistory.IsEnabled = true;
            }
        }

        private void TxtbxHistory_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;

            TextBox textBox = (TextBox)sender;

            if (int.TryParse(textBox.Text, out int historyNum)
                && historyNum > 0 && historyNum <= _pattern.MaxHistory)
            {
                ApllyPattern(_pattern.GetHistory(historyNum));
                textBox.SelectAll();
            }
            else
            {
                if (_pattern.MaxHistory == 0)
                    MessageBox.Show("아직 생성된 패턴이 없습니다.");
                else
                    MessageBox.Show("1부터 " + _pattern.MaxHistory + "까지의 숫자만 입력해주세요!");

                textBox.Text = _pattern.CurrentHistory.ToString();
                return;
            }

            if (_pattern.CurrentHistory == 1)
            {
                btnPreviousHistory.IsEnabled = false;

                if (_pattern.MaxHistory > 1) btnNextHistory.IsEnabled = true;
            }
            else if (_pattern.CurrentHistory == _pattern.MaxHistory)
            {
                btnNextHistory.IsEnabled = false;
                btnPreviousHistory.IsEnabled = true;
            }
            else
            {
                btnNextHistory.IsEnabled = true;
                btnPreviousHistory.IsEnabled = true;
            }
        }

        private void ApllyPattern(PatternModel pattern)
        {
            txtDisplay.Text = pattern.Content;
            txtDisplay.TextAlignment = pattern.TextAlignment;
            txtbxHistory.Text = _pattern.CurrentHistory.ToString();
        }
    }
}

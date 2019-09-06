using lessonLibrary;
using System.Windows;

namespace Lesson
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {

        private PatternSelectWindow _patternSelectWindow = null;

        private pattern _pattern = pattern.Instance;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            if (_pattern.Create(txtbxInput.Text))
            {
                txtDisplay.Text = _pattern.PatternResult;
                txtDisplay.TextAlignment = _pattern.TextAlignment;
            }
            else
            {
                txtbxInput.Text = "1";
                MessageBox.Show("1부터 100까지의 숫자만 입력 가능합니다.");
            }
        }

        private void BtnPatternShow_Click(object sender, RoutedEventArgs e)
        {
            _patternSelectWindow = new PatternSelectWindow();
            _patternSelectWindow.Closing += _patternSelectWindow_Closing;
            _patternSelectWindow.Owner = this;
            _patternSelectWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            _patternSelectWindow.ShowDialog();
        }

        private void _patternSelectWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPattern.Text = _pattern.PatternName;
        }
    }
}

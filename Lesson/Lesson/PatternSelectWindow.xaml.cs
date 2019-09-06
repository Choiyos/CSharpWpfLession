using patternDLL;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lesson
{
    /// <summary>
    /// PatternSelectWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PatternSelectWindow : Window
    {
        private RadioButton _rb = null;

        private List<RadioButton> _patternRadioButtonList = new List<RadioButton>();

        private List<TextBlock> _patternTextList = new List<TextBlock>();

        private Pattern _pattern = Pattern.Instance;

        public PatternSelectWindow()
        {
            InitializeComponent();

            // xaml에 새로운 패턴을 만들 때에 Name속성의 Format을 맞춰주어야 누락되지 않음.
            _patternRadioButtonList = myGrid.Children.OfType<RadioButton>().Where(x => x.Name.Contains("rbPattern")).ToList();
            _patternTextList = myGrid.Children.OfType<TextBlock>().Where(x => x.Name.Contains("txtPattern")).ToList();

        }

        private void BtnPatternSelect_Click(object sender, RoutedEventArgs e)
        {
            if (_pattern.ChangePattern(_rb?.Content.ToString()))
            {
                Close();
            }
            else
            {
                MessageBox.Show("선택된 패턴이 없습니다.");
            }
        }

        private void RadioButtonClicked(object sender, RoutedEventArgs e)
        {
            _rb = (RadioButton)sender;
        }

        private void TxtPattern_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string txtBlock = (sender as TextBlock).Name;

            int raduiButtonIndex = _patternTextList.IndexOf(_patternTextList.Where(x => x == (TextBlock)sender).FirstOrDefault());

            _patternRadioButtonList[raduiButtonIndex].IsChecked = true;
            _rb = _patternRadioButtonList[raduiButtonIndex];
        }
    }
}

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
using System.Windows.Shapes;

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

        public PatternSelectWindow()
        {
            InitializeComponent();

            // xaml에 새로운 패턴을 만들 때에 Name속성의 Format을 맞춰주어야 누락되지 않음.
            _patternRadioButtonList = myGrid.Children.OfType<RadioButton>().Where(x => x.Name.Contains("rbPattern")).ToList();
            _patternTextList = myGrid.Children.OfType<TextBlock>().Where(x => x.Name.Contains("txtPattern")).ToList();
        }

        public event EventHandler<string> OnChildSelectPatternEvent;

        private void BtnPatternSelect_Click(object sender, RoutedEventArgs e)
        {
            if (_rb is null)
            {
                MessageBox.Show("선택된 패턴이 없습니다.");
            }
            else
                OnChildSelectPatternEvent?.Invoke(sender, _rb?.Content.ToString());
        }

        private void RadioButtonClicked(object sender, RoutedEventArgs e)
        {
            _rb = (RadioButton)sender;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // 닫는 시점에 이벤트가 비어있지 않다면, Select 버튼을 클릭하지 않고 패턴 윈도우 닫기 버튼을 클릭한 것.
            OnChildSelectPatternEvent?.Invoke(sender, string.Empty);
        }

        private void TxtPattern_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string txtBlock = (sender as TextBlock).Name;

            // 라디오버튼List와 TextBlock의 순서가 동일하게 들어가야한다는 제한점이 있음. 
            // xaml에서 TextBlock 작성 순서가 꼬이면 리스트에 들어가는 순서도 꼬일듯.
            int raduiButtonIndex = _patternTextList.IndexOf(_patternTextList.Where( x => x == (TextBlock)sender).FirstOrDefault());

            _patternRadioButtonList[raduiButtonIndex].IsChecked = true;
            _rb = _patternRadioButtonList[raduiButtonIndex];
        }
    }
}

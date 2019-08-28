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
    /// Window1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PatternSelectWindow : Window
    {
        private RadioButton _rb = null;

        public PatternSelectWindow()
        {
            InitializeComponent();

        }
        public event EventHandler<string> OnChildSelectPatternEvent;

        private void BtnPatternSelect_Click(object sender, RoutedEventArgs e)
        {
            OnChildSelectPatternEvent?.Invoke(sender, _rb.Content.ToString());
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

        private void TxtPattern1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // 바인딩하거나 더 깔끔한 방법이 있을 것 같은데 더 고민해봐야 할 듯.            
            rbPattern1.IsChecked = true;
            rbPattern2.IsChecked = false;
            rbPattern3.IsChecked = false;

            _rb = rbPattern1;
        }

        private void TxtPattern2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            rbPattern1.IsChecked = false;
            rbPattern2.IsChecked = true;
            rbPattern3.IsChecked = false;

            _rb = rbPattern2;
        }

        private void TxtPattern3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            rbPattern1.IsChecked = false;
            rbPattern2.IsChecked = false;
            rbPattern3.IsChecked = true;

            _rb = rbPattern3;
        }
    }
}

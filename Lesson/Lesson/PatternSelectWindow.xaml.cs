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
        RadioButton rb = null;

        public PatternSelectWindow()
        {
            InitializeComponent();

        }
        public delegate void OnChildSelectPatternHander(string patternName);
        public event OnChildSelectPatternHander OnChildSelectPatternEvent;

        private void BtnPatternSelect_Click(object sender, RoutedEventArgs e)
        {
            if (OnChildSelectPatternEvent != null)
            {
                OnChildSelectPatternEvent(rb.Content.ToString());
            }
        }

        private void RadioButtonClicked(object sender, RoutedEventArgs e)
        {
            rb = (RadioButton)sender;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // 닫는 시점에 이벤트가 비어있지 않다면, Select 버튼을 클릭하지 않고 패턴 윈도우 닫기 버튼을 클릭한 것.
            if (OnChildSelectPatternEvent != null)
            {
                OnChildSelectPatternEvent(string.Empty);
            }
        }
    }
}

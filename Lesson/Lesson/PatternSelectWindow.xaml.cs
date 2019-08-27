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
        public PatternSelectWindow()
        {
            InitializeComponent();
        }
        public delegate void OnChildSelectPatternHander(string patternName);
        public event OnChildSelectPatternHander OnChildSelectPatternEvent;

        private void BtnPatternSelect_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(RadioButton.IsCheckedProperty.Name);
            if (OnChildSelectPatternEvent != null)
            {
                OnChildSelectPatternEvent(RadioButton.IsCheckedProperty.Name);
            }
        }
    }
}

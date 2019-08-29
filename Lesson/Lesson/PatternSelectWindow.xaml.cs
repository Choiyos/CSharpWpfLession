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

        private List<RadioButton> _radioButtonList = new List<RadioButton>();

        public PatternSelectWindow()
        {
            InitializeComponent();

            foreach (RadioButton radioButton in myGrid.Children.OfType<RadioButton>())
            {
                _radioButtonList.Add(radioButton);
            }
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

        private void TxtPattern_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string txtBlock = (sender as TextBlock).Name;

            // TxtBlock Name을 파싱해서 쓰는게 아니라 그룹을 지정하고, 클릭된 박스의 인덱스 순서에 따라 구분할 수 있게하면 Name에 의존하지 않아도 됨.
            if (int.TryParse(txtBlock.Substring(txtBlock.Length - 1, 1), out int radioButtonIndex))
            {
                radioButtonIndex--;
                _radioButtonList[radioButtonIndex].IsChecked = true;
                _rb = _radioButtonList[radioButtonIndex];
            }
            
            // 인덱스 순서로 구분하려는 시도.
            //MessageBox.Show(myGrid.Children.IndexOf(myGrid.Children.OfType<TextBlock>().Select().FirstOrDefault()).ToString());
            //MessageBox.Show(myGrid.Children.IndexOf(myGrid.Children.OfType<TextBlock>().Where(x => x.Name == (sender as TextBlock).Name) as UIElement).ToString());
            //int rbListIndex = myGrid.Children.OfType<TextBlock>().Where(x => x.Name == (sender as TextBlock).Name).FirstOrDefault().;

            _radioButtonList[radioButtonIndex].IsChecked = true;
            _rb = _radioButtonList[radioButtonIndex];

        }

        // 현재로써는 public static일 이유가 없기 때문에 private로 설정. commit amend Test용.
        private IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
}

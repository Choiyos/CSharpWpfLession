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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lesson
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            int inputNum = int.Parse(txtbxInput.Text);
            if (inputNum > 0 && inputNum < 101)
            {
                int sum = 0;
                string star = string.Empty;

                for (int i = 1; i <= inputNum; i++)
                {
                    sum += i;
                    star = star.PadRight(sum, '*') + "\n";
                    sum++;
                }

                txtDisplay.Text = star;
            }
            else
            {
                MessageBox.Show("정상적인 숫자 범위를 입력해주세요(1~100).");
                txtbxInput.Text = "1";
            }

        }
    }
}

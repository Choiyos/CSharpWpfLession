﻿using System;
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
        int pattern = 1;
        PatternSelectWindow patternSelectWindow = null;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {

            if (int.TryParse(txtbxInput.Text, out int inputNum)
                && (inputNum > 0 && inputNum < 101))
            {
                int sum = 0;
                string star = string.Empty;
                //lines가 홀수면 메시지 띄우기.

                switch (pattern)
                {
                    case 1:
                        // 패턴1 출력.
                        for (int i = 1; i <= inputNum; i++)
                        {
                            sum += i;
                            star = star.PadRight(sum, '*') + "\n";
                            sum++;
                        }
                        break;
                    case 2:
                        // 패턴2 출력.
                        for (int i = inputNum; i >= 1; i--)
                        {
                            sum += i;
                            star = star.PadRight(sum, '*') + "\n";
                            sum++;
                        }
                        break;
                    case 3:
                        if (inputNum % 2 != 0)
                        {
                            // 다이아몬드모양 출력.
                            for (int i = 1; i <= inputNum / 2; i++)
                            {
                                sum += i;
                                star = star.PadRight(sum, '*') + "\n";
                                sum++;
                            }
                            for (int i = (inputNum / 2)+1; i >= 1; i--)
                            {
                                sum += i;
                                star = star.PadRight(sum, '*') + "\n";
                                sum++;
                            }
                        }
                        else
                        {
                            // 입력값이 짝수이므로 취소.
                            MessageBox.Show("패턴 3은 홀수 라인만 입력 가능합니다.");
                            return;
                        }
                        break;
                    default:
                        break;
                }

                txtDisplay.Text = star;
            }
            else
            {
                MessageBox.Show("정상적인 숫자 범위를 입력해주세요(1~100).");
                txtbxInput.Text = "1";
            }
        }


        private void BtnPatternShow_Click(object sender, RoutedEventArgs e)
        {
            if (patternSelectWindow == null)
            {
                patternSelectWindow = new PatternSelectWindow();
                patternSelectWindow.OnChildSelectPatternEvent += new PatternSelectWindow.OnChildSelectPatternHander(psw_OnChildSelectPatternEvent);
                patternSelectWindow.ShowDialog();
            }
        }

        private void psw_OnChildSelectPatternEvent(string patternName)
        {
            if(int.TryParse(patternName.Substring(patternName.Length-1,1),out int parsedPattern))
            {
                pattern = parsedPattern;
                txtPattern.Text = pattern.ToString();
                if (patternSelectWindow != null)
                {
                    patternSelectWindow.Close();
                    patternSelectWindow.OnChildSelectPatternEvent -= new PatternSelectWindow.OnChildSelectPatternHander(psw_OnChildSelectPatternEvent);
                    patternSelectWindow = null;
                }
                MessageBox.Show(pattern.ToString());
            }
        }
    }
}

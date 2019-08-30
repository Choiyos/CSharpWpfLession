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
        private int _pattern = 1;

        private PatternSelectWindow _patternSelectWindow = null;

        private Dictionary<int, IPattern> _patternDic = new Dictionary<int, IPattern>
        {
            { 1, new FirstPattern() },
            { 2, new SecondPattern() },
            { 3, new ThirdPattern() },
            { 4, new FourthPattern() },
            { 5, new FifthPattern() }
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtbxInput.Text, out int inputNum)
                && (inputNum > 0 && inputNum < 101))
            {
                IPattern pattern = _patternDic[_pattern];

                PatternModel patternModel = pattern?.Create(inputNum);

                txtDisplay.Text = patternModel?.Content;
                txtDisplay.TextAlignment = patternModel.TextAlignment;
            }
            else
            {
                MessageBox.Show("정상적인 숫자 범위를 입력해주세요(1~100).");
                txtbxInput.Text = "1";
            }
        }

        private void BtnPatternShow_Click(object sender, RoutedEventArgs e)
        {
            if (_patternSelectWindow == null)
            {
                _patternSelectWindow = new PatternSelectWindow();
                _patternSelectWindow.OnChildSelectPatternEvent += new EventHandler<string>(psw_OnChildSelectPatternEvent);
                _patternSelectWindow.Owner = this;
                _patternSelectWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                _patternSelectWindow.ShowDialog();
            }
        }

        private void psw_OnChildSelectPatternEvent(object sender, string patternName)
        {
            if (!string.IsNullOrEmpty(patternName) && int.TryParse(patternName.Substring(patternName.Length - 1, 1), out int parsedPattern))
            {
                _pattern = parsedPattern;
                txtPattern.Text = patternName;
                if (_patternSelectWindow != null)
                {
                    _patternSelectWindow.OnChildSelectPatternEvent -= new EventHandler<string>(psw_OnChildSelectPatternEvent);
                    _patternSelectWindow.Close();
                    _patternSelectWindow = null;
                }
            }
            else
            {
                _patternSelectWindow.OnChildSelectPatternEvent -= new EventHandler<string>(psw_OnChildSelectPatternEvent);
                _patternSelectWindow = null;
            }
        }
    }
}

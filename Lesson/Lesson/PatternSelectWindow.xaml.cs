using LessonLibrary;
using System;
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
    public partial class PatternSelectWindow
    {
        /// <summary>
        /// 현재 선택되어있는 라디오 버튼 저장용. 
        /// </summary>
        private RadioButton _currentRadioButton;

        /// <summary>
        /// 패턴 선택 창에 있는 모든 라디오버튼을 저장하기 위한 리스트. 
        /// </summary>
        private List<RadioButton> _patternRadioButtons;

        /// <summary>
        /// 텍스트블록 클릭시 이름을 통해 라디오버튼의 순서를 반환하기 위한 맵. 
        /// </summary>
        private readonly Dictionary<string, int> _radioButtonIndexes = new Dictionary<string, int>();

        /// <summary>
        /// 패턴 라이브러리의 인스턴스. 
        /// </summary>
        private readonly Pattern _pattern = Pattern.Instance;

        public event EventHandler<string> OnChildSelectPatternEvent;

        public PatternSelectWindow()
        {
            InitializeComponent();

            InitButtonList();
        }

        private void InitButtonList()
        {
            // 패턴 선택 창에서 라디오버튼과 텍스트블록의 네이밍 규칙을 미리 정했다는 것을 전제로, 컨트롤 네임을 통해 리스트에 대입한다.
            _patternRadioButtons = myGrid.Children.OfType<RadioButton>().Where(x => x.Name.Contains("rbPattern")).ToList();
            var patternTextList = myGrid.Children.OfType<TextBlock>().Where(x => x.Name.Contains("txtPattern")).ToList();

            // 패턴 텍스트 네임을 딕셔너리에 넣고 네임을 Key로 주면 RadioButton의 인덱스로 사용할 수 있도록 입력.
            for (var i = 0; i < patternTextList.Count; i++)
                _radioButtonIndexes[patternTextList[i].Name] = i;
        }

        private void BtnPatternSelect_Click(object sender, RoutedEventArgs e)
        {
            // 패턴 선택 창에서 확인을 누르는 경우.
            if (_pattern.ChangePattern(_currentRadioButton?.Content.ToString()))
            {
                OnChildSelectPatternEvent?.Invoke(sender, _currentRadioButton?.Content.ToString());
                Close();
            }
            else
            {
                MessageBox.Show(this, "선택된 패턴이 없습니다.");
            }
        }

        private void RadioButtonClicked(object sender, RoutedEventArgs e)
        {
            _currentRadioButton = (RadioButton)sender;
        }

        private void TxtPattern_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // 라디오버튼 리스트의 인덱스로 텍스트 네임이 Key인 딕셔너리를 이용해 순서값 반환.
            var textBlockName = ((TextBlock)sender).Name;
            var radioButtonIndex = _radioButtonIndexes[textBlockName];
            var radioButton = _patternRadioButtons[radioButtonIndex];

            radioButton.IsChecked = true;
            _currentRadioButton = radioButton;
        }
    }
}

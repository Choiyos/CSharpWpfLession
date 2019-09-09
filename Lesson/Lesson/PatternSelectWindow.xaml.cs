using LessonLibrary;
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
        // 현재 선택되어있는 라디오 버튼 저장용.
        private RadioButton _rb;

        // 패턴 선택 창에 있는 모든 라디오버튼을 저장하기 위한 리스트.
        private readonly List<RadioButton> _patternRadioButtonList;

        // 패턴 선택 창에 있는 모든 텍스트블록을 저장하기 위한 리스트.

        private readonly Dictionary<string, int> _patternTextDic = new Dictionary<string, int>();

        // 패턴 라이브러리의 인스턴스.
        private readonly Pattern _pattern = Pattern.Instance;

        public PatternSelectWindow()
        {
            InitializeComponent();

            // 패턴 선택 창에서 라디오버튼과 텍스트블록의 네이밍 규칙을 미리 정했다는 것을 전제로, 컨트롤 네임을 통해 리스트에 대입한다.
            _patternRadioButtonList = myGrid.Children.OfType<RadioButton>().Where(x => x.Name.Contains("rbPattern")).ToList();
            var patternTextList = myGrid.Children.OfType<TextBlock>().Where(x => x.Name.Contains("txtPattern")).ToList();

            // 패턴 텍스트 네임을 딕셔너리에 넣고 네임을 Key로 주면 Rb의 인덱스로 사용할 수 있도록 입력.
            for (int i = 0; i < patternTextList.Count; i++)
            {
                _patternTextDic[patternTextList[i].Name] = i;
            }
        }

        private void BtnPatternSelect_Click(object sender, RoutedEventArgs e)
        {
            // 패턴 선택 창에서 확인을 누르는 경우.
            if (_pattern.ChangePattern(_rb?.Content.ToString()))
            {
                Close();
            }
            else
            {
                MessageBox.Show(this, "선택된 패턴이 없습니다.");
            }
        }

        private void RadioButtonClicked(object sender, RoutedEventArgs e)
        {
            _rb = (RadioButton)sender;
        }

        private void TxtPattern_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // 라디오버튼 리스트의 인덱스로 텍스트 네임이 Key인 딕셔너리를 이용해 순서값 반환.
            RadioButton radioButton = _patternRadioButtonList[_patternTextDic[((TextBlock)sender).Name]];

            radioButton.IsChecked = true;
            _rb = radioButton;
        }
    }
}

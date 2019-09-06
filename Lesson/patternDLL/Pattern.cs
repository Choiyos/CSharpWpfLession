using System.Collections.Generic;
using System.Windows;
using lessonLibrary.Interface;
using lessonLibrary.Patterns;
using lessonLibrary.Model;

namespace lessonLibrary
{
    public class pattern
    {
        private static pattern _instance = null;

        public static pattern Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new pattern();
                }
                return _instance;
            }
        }

        private int _pattern = 1;

        private string _patternName = string.Empty;

        private string _patternResult = string.Empty;

        private TextAlignment _textAlignment;

        private Dictionary<int, IPattern> _patternDic = new Dictionary<int, IPattern>
        {
            { 1, new FirstPattern() },
            { 2, new SecondPattern() },
            { 3, new ThirdPattern() },
            { 4, new FourthPattern() },
            { 5, new FifthPattern() }
        };

        public TextAlignment TextAlignment { get => _textAlignment; }

        public string PatternName { get => _patternName; }

        public string PatternResult { get => _patternResult; }

        public bool Create(string printNum)
        {
            if (int.TryParse(printNum, out int inputNum)
            && (inputNum > 0 && inputNum < 101))
            {
                IPattern pattern = _patternDic[_pattern];

                PatternModel patternModel = pattern?.Create(inputNum);

                _patternResult = patternModel.Content;
                _textAlignment = patternModel.TextAlignment;

                return true;
            }
            else return false;
        }

        public bool ChangePattern(string patternName)
        {
            if (!string.IsNullOrEmpty(patternName) && int.TryParse(patternName.Substring(patternName.Length - 1, 1), out int parsedPattern))
            {
                _pattern = parsedPattern;
                _patternName = patternName;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

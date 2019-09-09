using System.Collections.Generic;
using System.Windows;
using LessonLibrary.Interface;
using LessonLibrary.Model;
using LessonLibrary.Patterns;

namespace LessonLibrary
{
    public class Pattern
    {
        private static Pattern _instance;

        public static Pattern Instance => _instance ?? (_instance = new Pattern());

        private int _pattern = 1;

        private readonly Dictionary<int, IPattern> _patternDic = new Dictionary<int, IPattern>
        {
            { 1, new FirstPattern() },
            { 2, new SecondPattern() },
            { 3, new ThirdPattern() },
            { 4, new FourthPattern() },
            { 5, new FifthPattern() }
        };

        private readonly List<PatternModel> _patternHistoryList = new List<PatternModel>();

        private const int HistoryMax = 10;

        public int CurrentHistory { get; private set; }

        public int MaxHistory => _patternHistoryList.Count;

        public TextAlignment TextAlignment { get; private set; }

        public string PatternName { get; private set; } = "Pattern 1";

        public string PatternResult { get; private set; } = string.Empty;

        public bool Create(string printNum)
        {
            if (!int.TryParse(printNum, out int inputNum) || (inputNum <= 0 || inputNum >= 101)) return false;

            IPattern pattern = _patternDic[_pattern];

            PatternModel patternModel = pattern.Create(inputNum);

            PatternResult = patternModel.Content;
            TextAlignment = patternModel.TextAlignment;

            CurrentHistory = 1;

            if (_patternHistoryList.Count == HistoryMax)
            {
                _patternHistoryList.RemoveAt(0);
            }
                
            _patternHistoryList.Add(new PatternModel(PatternResult, TextAlignment));

            return true;

        }

        public bool ChangePattern(string patternName)
        {
            if (!string.IsNullOrEmpty(patternName) 
                && int.TryParse(patternName.Substring(patternName.Length - 1, 1), out int parsedPattern))
            {
                _pattern = parsedPattern;
                PatternName = patternName;
                return true;
            }

            return false;
        }

        public PatternModel GetHistory(int index)
        {
            CurrentHistory = index;
            return _patternHistoryList[_patternHistoryList.Count - CurrentHistory];
        }

        public PatternModel GetNextHistory()
        {
            CurrentHistory++;
            return _patternHistoryList[_patternHistoryList.Count - CurrentHistory];
        }

        public PatternModel GetPreviousHistory()
        {
            CurrentHistory--;
            return _patternHistoryList[_patternHistoryList.Count - CurrentHistory];
        }
    }
}

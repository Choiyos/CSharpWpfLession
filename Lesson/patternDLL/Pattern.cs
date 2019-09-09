using System.Collections.Generic;
using System.Windows;
using lessonLibrary.Interface;
using lessonLibrary.Patterns;
using lessonLibrary.Model;
using System;

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

        private Dictionary<int, IPattern> _patternDic = new Dictionary<int, IPattern>
        {
            { 1, new FirstPattern() },
            { 2, new SecondPattern() },
            { 3, new ThirdPattern() },
            { 4, new FourthPattern() },
            { 5, new FifthPattern() }
        };

        private List<PatternModel> _patternHistoryList = new List<PatternModel>();

        private const int _historyMax = 10;

        public int CurrentHistory { get; private set; } = 0;

        public int MaxHistory { get => _patternHistoryList.Count; }

        public TextAlignment TextAlignment { get; private set; }

        public string PatternName { get; private set; } = string.Empty;

        public string PatternResult { get; private set; } = string.Empty;

        public bool Create(string printNum)
        {
            if (int.TryParse(printNum, out int inputNum)
            && (inputNum > 0 && inputNum < 101))
            {
                IPattern pattern = _patternDic[_pattern];

                PatternModel patternModel = pattern.Create(inputNum);

                PatternResult = patternModel.Content;
                TextAlignment = patternModel.TextAlignment;

                CurrentHistory = 1;

                if (_patternHistoryList.Count == _historyMax)
                {
                    _patternHistoryList.RemoveAt(0);
                }

                _patternHistoryList.Add(new PatternModel(PatternResult, TextAlignment));

                return true;
            }
            else return false;
        }

        public bool ChangePattern(string patternName)
        {
            if (!string.IsNullOrEmpty(patternName) && int.TryParse(patternName.Substring(patternName.Length - 1, 1), out int parsedPattern))
            {
                _pattern = parsedPattern;
                PatternName = patternName;
                return true;
            }
            else
            {
                return false;
            }
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

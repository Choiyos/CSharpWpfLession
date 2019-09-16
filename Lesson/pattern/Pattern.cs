using System.Collections.Generic;
using System.Windows;
using LessonLibrary.Interface;
using LessonLibrary.Model;
using LessonLibrary.Patterns;
using static System.Int32;

namespace LessonLibrary
{
    public class Pattern
    {
        private static Pattern _instance;

        public static Pattern Instance => _instance ?? (_instance = new Pattern());

        private Pattern() { }

        private int _patternIndex = 1;

        private readonly Dictionary<int, IPattern> _patternStorage = new Dictionary<int, IPattern>
        {
            { 1, new FirstPattern() },
            { 2, new SecondPattern() },
            { 3, new ThirdPattern() },
            { 4, new FourthPattern() },
            { 5, new FifthPattern() },
            { 6, new SixthPattern() }
        };

        private readonly List<PatternResultModel> _resultStorage = new List<PatternResultModel>();

        private const int MaxStorageCapacity = 10;

        public int ResultStorageOffset { get; private set; }

        public int ResultStorageCount => _resultStorage.Count;

        public TextAlignment TextAlignment { get; private set; }

        public string PatternName { get; private set; }

        public string PatternResult { get; private set; } = string.Empty;

        public bool Create(string printNum)
        {
            if (!TryParse(printNum, out int inputNum) || (inputNum <= 0 || inputNum >= 101)) return false;

            var pattern = _patternStorage[_patternIndex];

            var resultModel = pattern?.Create(inputNum);

            if (resultModel != null)
            {
                PatternResult = resultModel.Content;
                TextAlignment = resultModel.TextAlignment;

                ResultStorageOffset = 1;

                if (_resultStorage.Count == MaxStorageCapacity)
                {
                    _resultStorage.RemoveAt(0);
                }

                _resultStorage.Add(new PatternResultModel(PatternResult, TextAlignment));
            }

            return true;
        }

        public bool ChangePattern(string patternName)
        {
            if (string.IsNullOrEmpty(patternName) || !TryParse(patternName.Substring(patternName.Length - 1, 1),
                    out var parsedPatternIndex)) return false;
            _patternIndex = parsedPatternIndex;
            PatternName = patternName;
            return true;
        }

        /// <summary>
        /// 넘겨받은 순서에 해당하는 패턴기록을 반환하는 함수.
        /// </summary>
        /// <param name="index"> 패턴기록 순서에 들어갈 인덱스 </param>
        /// <returns></returns>
        public PatternResultModel GetResult(int index)
        {
            ResultStorageOffset = index;
            return _resultStorage[_resultStorage.Count - ResultStorageOffset];
        }

        /// <summary>
        /// 다음 순서의 패턴기록을 반환해주는 함수.
        /// </summary>
        /// <returns></returns>
        public PatternResultModel GetNextResult()
        {
            ResultStorageOffset++;
            return _resultStorage[_resultStorage.Count - ResultStorageOffset];
        }

        /// <summary>
        /// 이전 순서의 패턴기록을 반환해주는 함수.
        /// </summary>
        /// <returns></returns>
        public PatternResultModel GetPreviousResult()
        {
            ResultStorageOffset--;
            return _resultStorage[_resultStorage.Count - ResultStorageOffset];
        }
    }
}

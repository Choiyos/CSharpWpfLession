using LessonLibrary.Interface;
using LessonLibrary.Model;
using LessonLibrary.Patterns;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using static System.Int32;

namespace LessonLibrary
{
    public enum PatternResult
    {
        Success,
        Pattern3Even,
        InvalidValue
    }

    public class Pattern
    {
        private static Pattern _instance;

        public static Pattern Instance => _instance ?? (_instance = new Pattern());

        private Pattern() { }

        /// <summary>
        /// IPattern의 서브클래스 할당을 위한 인덱스.
        /// </summary>
        private int _patternIndex = 1;

        /// <summary>
        /// 패턴번호로 서브클래스를 반환해주는 해시맵.
        /// </summary>
        private readonly Dictionary<int, IPattern> _patternStorage = new Dictionary<int, IPattern>
        {
            { 1, new FirstPattern() },
            { 2, new SecondPattern() },
            { 3, new ThirdPattern() },
            { 4, new FourthPattern() },
            { 5, new FifthPattern() },
            { 6, new SixthPattern() },
            { 7, new SeventhPattern()}
        };

        /// <summary>
        /// 출력 결과물 목록.
        /// </summary>
        private readonly List<PatternResultModel> _resultStorage = new List<PatternResultModel>();

        /// <summary>
        /// 결과 저장소 최대 크기 수.
        /// </summary>
        private const int MaxStorageCapacity = 10;

        /// <summary>
        /// 현재 가리키고 있는 결과 저장소의 위치.
        /// </summary>
        public int ResultStorageOffset { get; private set; }

        /// <summary>
        /// 현재 저장된 결과의 개수.
        /// </summary>
        public int ResultStorageCount => _resultStorage.Count;

        /// <summary>
        /// 출력시 적용되는 패턴 이름.
        /// </summary>
        public string PatternName { get; private set; }

        /// <summary>
        /// 가장 최근에 생성된 결괏값.
        /// </summary>
        public PatternResultModel CurrentResult { get; private set; }

        /// <summary>
        /// 최대 입력 가능한 별 개수.
        /// </summary>
        public const int MaxLineInputNum = 100;

        /// <summary>
        /// 요약된 결괏값.
        /// </summary>
        public string FoldedOutput { get; private set; }

        /// <summary>
        /// 요약되지 않은 결괏값.
        /// </summary>
        public string UnfoldedOutput { get; private set; }

        /// <summary>
        /// 입력된 매개변수만큼 적용된 패턴으로 별을 생성하고 결과를 반환한다.
        /// </summary>
        /// <param name="input">출력할 별의 개수.</param>
        /// <returns>생성 성공 여부.</returns>
        public PatternResult Create(string input)
        {
            if (!TryParse(input, out int inputNum) || (inputNum <= 0 || inputNum > MaxLineInputNum))
            {
                return PatternResult.InvalidValue;
            }

            if (_patternStorage.ContainsKey(_patternIndex))
            {
                var pattern = _patternStorage[_patternIndex];

                Debug.Assert(pattern != null, nameof(pattern) + " != null");
                CurrentResult = pattern.Create(inputNum);
            }

            if (String.IsNullOrEmpty(CurrentResult?.Output))
            {
                return PatternResult.Pattern3Even;
            }

            ResultStorageOffset = 1;

            if (_resultStorage.Count == MaxStorageCapacity)
            {
                _resultStorage.RemoveAt(0);
            }

            _resultStorage.Add(CurrentResult);
            return PatternResult.Success;
        }

        /// <summary>
        /// 전달받은 이름에 해당하는 패턴으로 변경한다.
        /// </summary>
        /// <param name="patternName">패턴 이름.</param>
        /// <returns>성공 여부.</returns>
        public bool ChangePattern(string patternName)
        {
            if (String.IsNullOrEmpty(patternName) || !TryParse(patternName.Split(' ')[1],
                    out var parsedPatternIndex)) return false;
            if (_patternStorage.ContainsKey(parsedPatternIndex))
            {
                _patternIndex = parsedPatternIndex;
                PatternName = patternName;
            }
            else return false;
            return true;
        }

        /// <summary>
        /// 넘겨받은 순서에 해당하는 패턴기록을 반환한다.
        /// </summary>
        /// <param name="index"> 패턴기록 순서에 들어갈 인덱스 </param>
        /// <returns></returns>
        public PatternResultModel GetResult(int index)
        {
            ResultStorageOffset = index;
            var resultStorageOffset = _resultStorage.Count - ResultStorageOffset;
            if (resultStorageOffset >= 0 && _resultStorage.Count > resultStorageOffset)
                return _resultStorage[resultStorageOffset];
            Debug.Assert(_resultStorage[resultStorageOffset]!=null,"Invalid index");
            return null;
        }

        /// <summary>
        /// 다음 순서의 패턴기록을 반환한다.
        /// </summary>
        /// <returns></returns>
        public PatternResultModel GetNextResult()
        {
            return _resultStorage[_resultStorage.Count - (++ResultStorageOffset)];
        }

        /// <summary>
        /// 이전 순서의 패턴기록을 반환한다.
        /// </summary>
        /// <returns></returns>
        public PatternResultModel GetPreviousResult()
        {
            return _resultStorage[_resultStorage.Count - (--ResultStorageOffset)];
        }

        /// <summary>
        /// 입력된 값의 결과물을 요약한다.
        /// </summary>
        /// <param name="model">출력 예정인 결과.</param>
        public void FoldOutput(PatternResultModel model)
        {
            FoldedOutput = model.Pattern.CreateFoldedOutput(model.Output);
            UnfoldedOutput = model.Output;
        }
    }
}

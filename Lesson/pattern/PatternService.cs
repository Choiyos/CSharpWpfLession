using Lesson;
using LessonLibrary.Interface;

namespace LessonLibrary
{
    public class PatternService
    {
        private IPattern _pattern;

        public const int MaxInputLine = 100;

        public string CurrentPattern;

        public IPattern Create(int num)
        {
            _pattern = PatternSelector.SelectPattern(CurrentPattern);
            _pattern.Create(num);
            return _pattern;
        }
        public IPattern CreateRandom(int num)
        {
            _pattern = PatternSelector.SelectPattern(CurrentPattern);
            ((IRandomable)_pattern).CreateRandom(num);
            return _pattern;
        }

        public void ChangePattern(string pattern)
        {
            CurrentPattern = pattern;
        }
    }
}
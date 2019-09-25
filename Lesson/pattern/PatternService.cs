using Lesson;
using LessonLibrary.Interface;

namespace LessonLibrary
{
    public class PatternService
    {
        private IPattern _pattern;

        public const int MaxInputLine = 100;

        public bool IsRandom { get; private set; }

        public PatternService()
        {
            _pattern = PatternSelector.SelectPattern(0);
        }

        public IPattern Create(int num)
        {
            return IsRandom ? CreateRandom(num) : CreateNonrandom(num);
        }

        private IPattern CreateNonrandom(int num)
        {
            _pattern.Create(num);
            return _pattern;
        }

        private IPattern CreateRandom(int num)
        {
            ((IRandomable)_pattern).CreateRandom(num);
            return _pattern;
        }

        public void ChangePattern(PatternOption pattern)
        {
            _pattern = PatternSelector.SelectPattern(pattern);
            IsRandom = false;
        }

        public void ChangeRandomFlag(bool flag)
        {
            if (_pattern is IRandomable)
                IsRandom = flag;
        }
    }
}
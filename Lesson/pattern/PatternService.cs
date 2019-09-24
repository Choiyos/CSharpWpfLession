using Lesson;
using LessonLibrary.Interface;

namespace LessonLibrary
{
    public class PatternService
    {
        private IPattern _pattern;

        public const int MaxInputLine = 100;

        public string CurrentPattern;

        public IPattern Create(int num, bool? chkRandomIsChecked)
        {
            _pattern = PatternSelector.SelectPattern(CurrentPattern);
            if (chkRandomIsChecked != null && !chkRandomIsChecked.Value)
            {
                CreateNonrandom(num);
            }
            else
            {
                if (_pattern.GetType() != typeof(IRandomable)) return null;
                CreateRandom(num);
            }
            return chkRandomIsChecked is false ? CreateNonrandom(num) : CreateRandom(num);
        }

        public IPattern CreateNonrandom(int num)
        {
            _pattern.Create(num);
            return _pattern;
        }

        public IPattern CreateRandom(int num)
        {
            ((IRandomable)_pattern).CreateRandom(num);
            return _pattern;
        }

        public void ChangePattern(string pattern)
        {
            CurrentPattern = pattern;
        }
    }
}
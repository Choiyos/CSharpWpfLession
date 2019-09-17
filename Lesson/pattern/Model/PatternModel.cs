using System.Windows;
using LessonLibrary.Interface;

namespace LessonLibrary.Model
{
    public class PatternResultModel
    {
        public TextAlignment TextAlignment { get; }
        public string Output { get; }
        public int Lines { get; }
        public IFoldable Pattern { get; }

        public PatternResultModel(string content, TextAlignment textAlignment)
        {
            Output = content;
            TextAlignment = textAlignment;
        }

        public PatternResultModel(string content, TextAlignment textAlignment, int lines, IFoldable pattern)
        {
            Output = content;
            TextAlignment = textAlignment;
            Lines = lines;
            Pattern = pattern;
        }
    }
}

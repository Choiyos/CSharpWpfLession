using System.Windows;

namespace LessonLibrary.Model
{
    public class PatternResultModel
    {
        public TextAlignment TextAlignment { get; }
        public string Content { get; }

        public PatternResultModel(string content, TextAlignment textAlignment)
        {
            Content = content;
            TextAlignment = textAlignment;
        }
    }
}

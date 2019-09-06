using System.Windows;

namespace patternDLL
{
    public class PatternModel
    {
        public TextAlignment TextAlignment { get; }
        public string Content { get; }

        public PatternModel(string content, TextAlignment textAlignment)
        {
            Content = content;
            TextAlignment = textAlignment;
        }
    }
}

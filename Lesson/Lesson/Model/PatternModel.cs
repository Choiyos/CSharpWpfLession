using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Lesson
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

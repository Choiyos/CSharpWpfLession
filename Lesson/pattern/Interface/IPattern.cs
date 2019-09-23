using System.Windows;

namespace LessonLibrary.Interface
{
    public interface IPattern
    {
        string Result { get; }

        TextAlignment Alignment { get;  }

        void Create(int inputNum);
    }
}

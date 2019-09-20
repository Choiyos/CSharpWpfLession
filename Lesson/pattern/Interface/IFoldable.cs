namespace LessonLibrary.Interface
{
    public interface IFoldable
    {
        string FoldedResult { get; }
        int Lines { get; }
        string CreateFoldedOutput();
    }
}

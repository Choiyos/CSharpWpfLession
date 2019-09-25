using LessonLibrary.Interface;
using LessonLibrary.Patterns;
using System;
using System.IO;

namespace Lesson
{
    public enum PatternOption
    {
        First,
        Second,
        Third,
        Fourth,
        Fifth,
        Sixth,
        Seventh
    }

    public static class PatternSelector
    {
        public static IPattern SelectPattern(PatternOption pattern)
        {
            switch (pattern)
            {
                case PatternOption.First:
                    return new FirstPattern();
                case PatternOption.Second:
                    return new SecondPattern();
                case PatternOption.Third:
                    return new ThirdPattern();
                case PatternOption.Fourth:
                    return new FourthPattern();
                case PatternOption.Fifth:
                    return new FifthPattern();
                case PatternOption.Sixth:
                    return new SixthPattern();
                case PatternOption.Seventh:
                    return new SeventhPattern();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
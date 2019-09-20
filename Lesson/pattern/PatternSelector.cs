using LessonLibrary.Interface;
using LessonLibrary.Patterns;
using System;
using System.IO;

namespace Lesson
{
    public static class PatternSelector
    {
        public static IPattern SelectPattern(string pattern)
        {

            if (Int32.TryParse(pattern.Split(' ')[1], out int num))
            {
                switch (num)
                {
                    case 1:
                        return new FirstPattern();
                    case 2:
                        return new SecondPattern();
                    case 3:
                        return new ThirdPattern();
                    case 4:
                        return new FourthPattern();
                    case 5:
                        return new FifthPattern();
                    case 6:
                        return new SixthPattern();
                    case 7:
                        return new SeventhPattern();
                    default:
                        throw new InvalidDataException();
                }
            }

            throw new ArgumentException();
        }
    }
}
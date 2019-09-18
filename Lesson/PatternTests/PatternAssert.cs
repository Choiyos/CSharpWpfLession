using LessonLibrary.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternTests
{
    public static class PatternAssert
    {
        public static void ArePatternResultEqual(PatternResultModel compareResult1, PatternResultModel compareResult2)
        {
            Assert.AreEqual(compareResult1.Output, compareResult2.Output);
            Assert.AreEqual(compareResult1.TextAlignment, compareResult2.TextAlignment);
            Assert.AreEqual(compareResult1.Pattern, compareResult2.Pattern);
            Assert.AreEqual(compareResult1.Lines, compareResult2.Lines);
        }
    }
}

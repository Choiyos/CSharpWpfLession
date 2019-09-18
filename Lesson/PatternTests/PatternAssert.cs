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
            if(compareResult1.Pattern != null && compareResult2.Pattern != null)
                Assert.AreEqual(compareResult1.Pattern.ToString(), compareResult2.Pattern.ToString());
            Assert.AreEqual(compareResult1.Lines, compareResult2.Lines);
        }
    }
}

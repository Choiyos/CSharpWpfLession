using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Lesson
{
    public interface IPattern
    {
        string PrintPattern(TextBlock txtbxInput, int inputNum);
    }
}

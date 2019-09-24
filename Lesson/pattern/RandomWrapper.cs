using System;
using System.Collections.Generic;
using System.Linq;

namespace LessonLibrary.Patterns
{
    public class RandomWrapper
    {
        private readonly Random _random = new Random();

        public virtual List<int> Create(int inputNum)
        {
            var linearList = Enumerable.Range(0, inputNum).ToList();
            var randomList = new List<int>(inputNum);

            for (int i = 0; i < inputNum; i++)
            {
                int randomIndex = _random.Next(0, linearList.Count);
                randomList.Add(linearList[randomIndex]);
                linearList.RemoveAt(randomIndex);
            }

            return randomList;
        }
    }
}
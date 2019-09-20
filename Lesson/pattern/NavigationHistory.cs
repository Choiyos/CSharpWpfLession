﻿using LessonLibrary.Interface;
using System.Collections.Generic;
using System.Linq;

namespace LessonLibrary
{
    public class NavigationHistory
    {
        public int Capacity => _patterns.Capacity;
        public int Count => _patterns.Count;
        public int CurrentIndex { get; private set; }
        public int MoveValue=1;
        private readonly List<IPattern> _patterns;

        public NavigationHistory(int capacity)
        {
            _patterns = new List<IPattern>(capacity);
        }

        public bool PushPattern(IPattern pattern)
        {
            if (pattern == null) return false;
            if (_patterns.Count==_patterns.Capacity)
                _patterns.RemoveAt(_patterns.Capacity-1);
            _patterns.Insert(0, pattern);
            CurrentIndex = 0;
            return true;
        }

        public List<IPattern> GetPatterns()
        {
            return _patterns.ToList();
        }

        public bool ReplacePattern(IPattern pattern, int index)
        {
            if (pattern == null) return false;
            _patterns[index] = pattern;
            return true;
        }

        public IPattern GetCurrentPattern()
        {
            return _patterns.ToList()[CurrentIndex];
        }

        public IPattern GetNextPattern()
        {
            CurrentIndex += MoveValue;
            return _patterns.ToList()[CurrentIndex];
        }

        public IPattern GetPreviousPattern()
        {
            CurrentIndex -= MoveValue;
            return _patterns.ToList()[CurrentIndex];
        }

        public IPattern GetPattern(int index)
        {
            CurrentIndex = index;
            return _patterns.ToList()[index];
        }

        public bool CanHistoryMoveNext()
        {
            return CurrentIndex + MoveValue < Count;
        }

        public bool CanHistoryMovePrevious()
        {
            return CurrentIndex - MoveValue >= 0;
        }

        public void ChangeMoveValue(int value)
        {
            MoveValue = value;
        }

        public int GetIndex()
        {
            return CurrentIndex;
        }
    }
}
using System.Collections.Generic;

namespace _2048.Common
{
    internal class ScoreComparer : IComparer<User>
    {
        public int Compare(User x, User y)
        {
            return x.Score.CompareTo(y.Score);
        }
    }
}
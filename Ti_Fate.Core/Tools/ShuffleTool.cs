﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ti_Fate.Core.Tools
{
    public static class ShuffleTool
    {
        private static Random rng = new Random();

        public static void ShuffleList<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}

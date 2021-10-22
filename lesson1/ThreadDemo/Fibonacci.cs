using System;

namespace ThreadDemo
{
    public static class FIbonacci
    {
        public static long GetRecurs(int n)
        {
            if (n == 0) return 0;
            if (n == 1 || n == 2) return 1;
            return GetRecurs(n - 1) + GetRecurs(n - 2);
        }
    }
}

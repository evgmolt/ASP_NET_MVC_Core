using System;

namespace ThreadDemoWpf
{
    public static class FIbonacci
    {
        public static long GetRecurs(int n)
        {
            if (n <= 1) return n;
            return GetRecurs(n - 1) + GetRecurs(n - 2);
        }
    }
}

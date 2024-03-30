using System.Diagnostics;

namespace Exsr4
{
    class Exsr4
    {
        static void Main()
        {
            Stopwatch stopWatch = new();
            stopWatch.Start();
            long before = GC.GetTotalMemory(true);

            string dir = "..\\..\\..\\..\\";
            string fileName = "Tests\\test6.txt";
            var f = File.ReadAllLines(dir+fileName);
            File.WriteAllLines(dir+"result.txt", GetResult(f));

            long after = GC.GetTotalMemory(true);
            stopWatch.Stop();
            long consumedInMegabytes = (after - before)/1024;
            Console.WriteLine($"Time: {stopWatch.Elapsed.Milliseconds}ms");
            Console.WriteLine($"Ram: {consumedInMegabytes}KB");
        }
        
        static string[] GetResult(string[] f){
            var input = f[0].Split();
            int N = int.Parse(input[0]);
            int M = int.Parse(input[1]);
            int MOD = int.Parse(input[2]);

            long[] coefficients = new long[N + 1];
            string[] result = new string[M];

            for (int i = 1; i <= 1+N; i++)
                coefficients[i-1] = long.Parse(f[i]);

            for (int i = 2+N; i < M+2+N; i++)
            {
                long x = long.Parse(f[i]);
                result[i-(2+N)] = ModHornersMethod(N, coefficients, x, MOD).ToString();
            }

            return result;
        }

        static long ModHornersMethod(int N, long[] coefficients, long x, int MOD)
        {
            if (N == -1) return 0;
            return (ModHornersMethod(N - 1, coefficients, x, MOD) * x + coefficients[N]) % MOD;
        }
    }
}
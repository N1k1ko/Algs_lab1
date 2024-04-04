using System.Diagnostics;

namespace Exsr8
{
    public class Exsr8
    {
        static void Main()
        {
            string dir = "..\\..\\..\\..\\";
            string fileName = "Tests\\test (11).txt";
            var f = File.ReadAllLines(dir + fileName)[0].Split().ToArray();
            int n = int.Parse(f[0]);
            int m = int.Parse(f[1]);
            Stopwatch stopwatch = new();

            stopwatch.Start();
            var result = GetResult(n, m, 0);
            stopwatch.Stop();

            File.WriteAllLines(dir + "result.txt", [result.ToString()]);
            Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds}ms");
        }

        public static int GetResult(int n, int m, int between)
        {
            if(m + between * (m - 1) > n)
                return 0;
            if (m == n || m==0)
                return 1;
            return n - (m + between * (m - 1)) + 1 + GetResult(n, m, between + 1);
        }
    }
}
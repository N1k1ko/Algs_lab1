using System.Diagnostics;

namespace Exsr7
{
    public class Exsr7
    {
        static bool[] ver;
        static bool[] diag1;
        static bool[] diag2;
        static int[] hor;

        static void Main()
        {
            string dir = "..\\..\\..\\..\\";
            string fileName = "Tests\\test (1).txt";
            var f = File.ReadAllLines(dir + fileName)[0].Split().ToArray();
            int N = int.Parse(f[0]);
            int K = int.Parse(f[1]);
            Stopwatch stopwatch = new();

            stopwatch.Start();
            var result = FindMagaradjaPlacements(N, K);
            stopwatch.Stop();

            File.WriteAllLines(dir + "result.txt", new string[] { result.ToString() });
            Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds}ms");
        }

        public static int FindMagaradjaPlacements(int N, int K)
        {
            ver = new bool[N];
            diag1 = new bool[N * 2];
            diag2 = new bool[N * 2];
            hor = new int[N];

            for (int i = 0; i < hor.Length; i++)
                hor[i] = -1;

            if (K == 0)
                return 1;
            if (K == 1)
                return N * N;
            if (N <= 0 || K < 0 || K > N - 2)
                return 0;

            return FindPlacementsInRow(N, 0, K);
        }

        static int FindPlacementsInRow(int N, int row, int remainingMagaradjas)
        {
            if (remainingMagaradjas == 0)
                return 1;
            if (row + remainingMagaradjas == N + 1)
                return 0;

            int totalPlacements = 0;

            for (int col = 0; col < N; col++)
            {
                if (totalPlacements == 0)
                    totalPlacements += FindPlacementsInRow(N, row + 1, remainingMagaradjas);
                if (TryPutPice(N, row, col))
                {
                    PutPice(N, row, col);
                    totalPlacements += FindPlacementsInRow(N, row + 1, remainingMagaradjas - 1);
                    UnputPice(N, row, col);
                }
            }

            return totalPlacements;
        }

        static bool TryPutPice(int N, int row, int col)
        {
            if (ver[col] || diag1[row + col] || diag2[row - col + N - 1])
                return false;
            for (int i = 0; i < row; i++)
                if (hor[i] >= 0 && Math.Abs(i - row) + Math.Abs(hor[i] - col) == 3)
                    return false;
            return true;
        }

        static void PutPice(int N, int row, int col)
        {
            ver[col] = diag1[row + col] = diag2[row - col + N - 1] = true;
            hor[row] = col;
        }

        static void UnputPice(int N, int row, int col)
        {
            ver[col] = diag1[row + col] = diag2[row - col + N - 1] = false;
            hor[row] = -1;
        }
    }
}
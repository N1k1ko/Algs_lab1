using System.Diagnostics;

namespace Exsr5
{
    class Exsr5
    {
        static void Main()
        {
            string[] input = new string[]{
                "program test;",
                "(*just for testing *)",
                "var",
                "(* variables",
                "note that",
                "// here is not comment",
                "and (* here is",
                "not a begin of",
                "another comment",
                "*)",
                "x: integer; (* *)",
                "begin",
                "write(\'(*is not comment//\');",
                "write(\' and (*here*) \'",
                ",x // y);",
                "End. // It is comment"
            };

            Stopwatch stopWatch = new();
            stopWatch.Start();
            long before = GC.GetTotalMemory(true);

            var r = F(input);

            long after = GC.GetTotalMemory(true);
            stopWatch.Stop();
            long consumedInMegabytes = (after - before) / 1024;
            Console.WriteLine($"{r[0]} {r[1]} {r[2]} {r[3]}");
            Console.WriteLine($"Time: {stopWatch.Elapsed.Milliseconds}ms");
            Console.WriteLine($"Ram: {consumedInMegabytes}KB");
        }

        static int[] F(string[] input)
        {
            int[] result = new int[4];

            string flag = "";
            foreach (var t in input)
            {
                for (int i = 0; i < t.Length; i++)
                {
                    switch (flag)
                    {
                        case "":
                            {
                                switch (t[i])
                                {
                                    case '{':
                                        {
                                            flag = "{";
                                            result[1] += 1;
                                            break;
                                        }
                                    case '\'':
                                        {
                                            flag = "\'";
                                            result[3] += 1;
                                            break;
                                        }
                                    case '/':
                                        {
                                            if (i + 1 < t.Length && t[i + 1] == '/')
                                            {
                                                result[2] += 1;
                                                i = t.Length;
                                            }
                                            break;
                                        }
                                    case '(':
                                        {
                                            if (i + 1 < t.Length && t[i + 1] == '*')
                                            {
                                                flag = "(*";
                                                result[0] += 1;
                                                i++;
                                            }
                                            break;
                                        }
                                    default: break;
                                }
                                break;
                            }
                        case "(*":
                            {
                                if (t[i] == '*' && i + 1 < t.Length && t[i + 1] == ')')
                                    flag = "";
                                break;
                            }
                        case "{":
                            {
                                if (t[i] == '}')
                                    flag = "";
                                break;
                            }
                        case "\'":
                            {
                                if (t[i] == '\'')
                                    flag = "";
                                break;

                            }
                        default: break;
                    }
                }
            }

            return result;
        }
    }
}
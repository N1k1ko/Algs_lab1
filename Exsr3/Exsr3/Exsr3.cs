using System.Diagnostics;

namespace Exsr3
{
    public class Exsr3
    {
        static void Main()
        {
            Console.WriteLine("Enter the first number:");
            string num1 = Console.ReadLine();
            Console.WriteLine("Enter the operation (+ or -):");
            string op = Console.ReadLine();
            Console.WriteLine("Enter the second number:");
            string num2 = Console.ReadLine();

            Stopwatch stopWatch = new();

            stopWatch.Start();
            string result = PerformOperation(num1, op, num2);
            stopWatch.Stop();

            Console.WriteLine($"Time: {stopWatch.Elapsed.Milliseconds}ms");
            Console.WriteLine("Result: " + result);
        }

        public static string PerformOperation(string num1, string op, string num2)
        {
            var ch1 = "";
            var ch2 = "";
            if (num1[0] == '-')
            {
                ch1 = "-";
                num1 = num1[1..];
            }
            if (num2[0] == '-')
            {
                ch2 = "-";
                num2 = num2[1..];
            }

            switch (ch1, op, ch2)
            {
                case ("", "+", ""):
                case ("-", "+", "-"):
                case ("", "-", "-"):
                case ("-", "-", ""):
                    return ch1 + Add(num1, num2, 0);
                case ("", "+", "-"):
                case ("", "-", ""):
                    if (IsAbsBigger(num1, num2))
                        return PostSubtract(Subtract(num1, num2));
                    else
                        return "-" + PostSubtract(Subtract(num2, num1));
                case ("-", "+", ""):
                case ("-", "-", "-"):
                    if (IsAbsBigger(num2, num1))
                        return PostSubtract(Subtract(num2, num1));
                    else
                        return "-" + PostSubtract(Subtract(num1, num2));
            }
            throw new Exception("Wrong operator");
        }

        public static string Add(string num1, string num2, int carry)
        {
            if (num1.Length == 0 && num2.Length == 0)
            {
                if (carry > 0)
                    return carry.ToString();
                else
                    return "";
            }

            int digit1 = num1.Length > 0 ? num1[^1] - '0' : 0;
            int digit2 = num2.Length > 0 ? num2[^1] - '0' : 0;

            int sum = digit1 + digit2 + carry;
            carry = sum / 10;

            return Add(num1.Length > 0 ? num1[..^1] : "",
                        num2.Length > 0 ? num2[..^1] : "",
                        carry) + (sum % 10).ToString();
        }

        public static bool IsAbsBigger(string num1, string num2)
        {
            if (num1.Length < num2.Length)
                return false;
            if ((num1.Length == 0 && num2.Length == 0) || num1.Length > num2.Length)
                return true;

            int digit1 = num1[0] - '0';
            int digit2 = num2[0] - '0';

            if (digit1 == digit2)
                return IsAbsBigger(num1[1..], num2[1..]);

            return digit1 > digit2;
        }

        public static string Subtract(string num1, string num2)
        {
            if (num1.Length == 0)
                return "";
            if(num2.Length <=0)
                return num1;

            int digit1 = num1[^1] - '0';
            int digit2 = num2[^1] - '0';

            int diff = digit1 - digit2;

            if (diff < 0)
            {
                int borrowFromIndex = num1.Length - 2;

                while (num1[borrowFromIndex] == '0')
                {
                    num1 = num1.Remove(borrowFromIndex, 1).Insert(borrowFromIndex, "9");
                    borrowFromIndex--;
                }
                num1 = num1.Remove(borrowFromIndex, 1)
                            .Insert(borrowFromIndex, (num1[borrowFromIndex] - '1')
                            .ToString());
                diff = 10 + digit1 - digit2;
            }

            return Subtract(num1.Length > 0 ? num1[..^1] : "",
                            num2.Length > 0 ? num2[..^1] : "") + diff.ToString();
        }

        public static string PostSubtract(string number) //удаляет 0 из начала при вычитании
        {
            var result = number.TrimStart('0');
            return result.Length == 0 ? "0" : result;
        }
    }
}
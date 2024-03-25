﻿namespace Exsr3
{
    public class Exsr3
    {
        private static string Add(string num1, string num2, int carry)
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

        private static string Subtract(string num1, string num2)
        {
            if (num1.Length == 0 && num2.Length == 0)
                return "";

            int digit1 = num1.Length > 0 ? num1[^1] - '0' : 0;
            int digit2 = num2.Length > 0 ? num2[^1] - '0' : 0;

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


        private static string PostSubtract(string num1, string num2) //удаляет 0 из начала при вычитании
        {
            var result = Subtract(num1, num2).TrimStart('0');
            return result.Length == 0 ? "0" : result;
        }

        private static bool IsAbsBigger(string num1, string num2)
        {
            if ((num1.Length >= num2.Length && num2.Length == 0) || num1.Length > num2.Length)
                return true;

            int digit1 = num1.Length > 0 ? num1[^1] - '0' : 0;
            int digit2 = num2.Length > 0 ? num2[^1] - '0' : 0;

            if (digit1 < digit2)
                return false;

            return IsAbsBigger(num1[1..], num2[1..]);
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
                    {
                        var result = PostSubtract(num1, num2);
                        return result == "0" ? "0" : result;
                    }
                    else
                        return "-" + PostSubtract(num2, num1);
                case ("-", "+", ""):
                case ("-", "-", "-"):
                    if (IsAbsBigger(num1, num2))
                    {
                        var result = PostSubtract(num1, num2);
                        return result == "0" ? "0" : "-" + result;
                    }
                    else
                        return PostSubtract(num2, num1);
            }
            throw new Exception("Wrong operator");
        }

        static void Main()
        {
            Console.WriteLine("Enter the first number:");
            string num1 = Console.ReadLine();

            Console.WriteLine("Enter the operation (+ or -):");
            string op = Console.ReadLine();

            Console.WriteLine("Enter the second number:");
            string num2 = Console.ReadLine();

            string result = PerformOperation(num1, op, num2);
            Console.WriteLine("Result: " + result);
        }
    }
}
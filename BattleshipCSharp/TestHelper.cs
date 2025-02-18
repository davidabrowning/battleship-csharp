using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal static class TestHelper
    {
        private static void PrintSuccess(string title)
        {
            Console.WriteLine($"[Success] {title}");
        }
        private static void PrintFailure(string title, object expected, object actual)
        {
            Console.WriteLine($"[Failure] {title} | Expected: {expected.ToString()} | Actual: {actual.ToString()}");
        }
        public static void AssertTrue(string title, bool actual)
        {
            if (actual)
            {
                PrintSuccess(title);
            }
            else
            {
                PrintFailure(title, true, actual);
            }
        }
        public static void AssertFalse(string title, bool actual)
        {
            if (actual)
            {
                PrintFailure(title, false, actual);
            }
            else
            {
                PrintSuccess(title);
            }
        }
        public static void AssertEquals(string title, object expected, object actual)
        {
            if (expected.Equals(actual))
            {
                PrintSuccess(title);
            }
            else
            {
                PrintFailure(title, expected, actual);
            }
        }
        public static void AssertNotEquals(string title, object expected, object actual)
        {
            if (expected.Equals(actual))
            {
                PrintFailure(title, expected, actual);
            }
            else
            {
                PrintSuccess(title);
            }
        }
    }
}

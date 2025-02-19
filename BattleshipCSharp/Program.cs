namespace BattleshipCSharp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //RunProgram();
            RunTests();
        }

        private static void RunProgram()
        {
            Console.WriteLine("Running program...");
        }

        private static void RunTests()
        {
            TestRunner testRunner = new TestRunner();
            testRunner.Go();
        }
    }
}

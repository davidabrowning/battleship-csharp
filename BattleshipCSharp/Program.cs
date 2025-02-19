namespace BattleshipCSharp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            RunProgram();
            //RunTests();
        }

        private static void RunProgram()
        {
            Game game = new Game();
            game.Go();
        }

        private static void RunTests()
        {
            TestRunner testRunner = new TestRunner();
            testRunner.Go();
        }
    }
}

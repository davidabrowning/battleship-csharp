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
            MainMenu mainMenu = new MainMenu();
            mainMenu.Go();
        }

        private static void RunTests()
        {
            TestRunner testRunner = new TestRunner();
            testRunner.Go();
        }
    }
}

namespace Empires.IO
{
    using System;
    using Empires.Interfaces;

    public class UserConsole : IUserInterface
    {
        public string ReadLine()
        {
            string input = Console.ReadLine();
            return input;
        }

        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}

using System;
using System.IO;

namespace TextAugmentation
{
    class Program
    {
        readonly static char[] charsForNouns = { 'a', 'b', 'c', 'd' };
        readonly static char[] charsForVerbs = { 'f', 'g', 'h', 'i' };
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("You're welcome!");
            Console.ResetColor();
            Console.Write("Please enter your text:");
            string text = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Then you can pick one of options: 0, 1, 2, 3 ");
            Console.ResetColor();
            int caseSwitch = int.Parse(Console.ReadLine());

            switch (caseSwitch)
            {
                case 0:
                    CreateHTML(text);
                    break;
                case 1:
                    Nouns nouns = new Nouns(text, charsForNouns);
                    nouns.GetRefers();
                    break;
                case 2:
                    Verbs verbs = new Verbs(text, charsForVerbs);
                    verbs.GetRefers();
                    break;
                case 3:
                    Translate translate = new Translate(text);
                    translate.LaunchConsole();                    
                    break;
                default:
                    Console.WriteLine("Try again!");
                    break;
            }
            void CreateHTML(string texts)
            {
                File.WriteAllText(@"C:\Users\Public\HTML\htmlFile.html", texts);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("C:\\Users\\Public\\HTML\\htmlFile.html") { UseShellExecute = true });

            }
            
            Console.ReadLine();
        }
    }
}

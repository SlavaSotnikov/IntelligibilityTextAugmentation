using System;
using System.IO;

namespace TextAugmentation
{
    abstract class PartsOfSpeech
    {
        readonly private string text;
        readonly private char[] currentChars;
        public PartsOfSpeech(string text, char[] chars)
        {
            this.text = text;
            currentChars = chars;
        }
        public PartsOfSpeech(string text)
        {
            this.text = text;
        }
        public void GetRefers()
        {
            string sentence = String.Empty;

            string[] words = text.Split(' ');
            foreach (string word in words)
            {
                char[] array = word.ToLower().ToCharArray();
                for (int i = 0; i < array.Length; i++)
                {
                    if ((array[0] == currentChars[0] || array[0] == currentChars[1] || array[0] == currentChars[2] || array[0] == currentChars[3]) && array.Length > 2)
                    {
                        sentence += "<a href= " + "https://www.wikipedia.org/wiki/" + word + ">" + word + "</a>" + " ";
                        break;
                    }
                    else
                    {
                        sentence += word + " ";
                        break;
                    }
                }

            }
            var path = "C:\\Users\\Public\\";
            var folder = Path.Combine(path, "HTML");
            Directory.CreateDirectory(folder);
            File.WriteAllText(@"C:\Users\Public\HTML\htmlFile.html", sentence);
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("C:\\Users\\Public\\HTML\\htmlFile.html") { UseShellExecute = true });

        }
    }
}

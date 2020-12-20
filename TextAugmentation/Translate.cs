using System;
using System.Net;
using System.Web;

namespace TextAugmentation
{
    class Translate : PartsOfSpeech
    {
        readonly string text;
        public Translate(string text) : base(text)
        {
            this.text = text;
        }
        public void LaunchConsole()
        {
            int countForSentence = 0;
            int countForCouples = 0;
            
            string twoSentence = String.Empty;
            string[] sentences = text.Split('.', '?', '!');
            foreach (string sentence in sentences)
            {
                countForSentence++;
                twoSentence += sentence;
                if (countForSentence % 2 == 0)
                {
                    countForCouples++;
                    Console.Write(countForCouples + ") " + twoSentence + "/" + " ");
                    Console.ForegroundColor = ConsoleColor.Cyan;

                    Console.WriteLine(Translation(twoSentence) + " ");
                    Console.ResetColor();

                    twoSentence = String.Empty;
                }
            }
        }
       
        public string Translation(string text)
        {
            var toLanguage = "ru";//Russian
            var fromLanguage = "en";//English
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={HttpUtility.UrlEncode(text)}";
            var webClient = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };
            var result = webClient.DownloadString(url);
            try
            {
                result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                return result;
            }
            catch
            {
                return "Error";
            }
        }
    }
}

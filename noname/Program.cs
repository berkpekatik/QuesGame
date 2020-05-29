using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace noname
{
    class Program
    {
        public static Animation ani = new Animation();
        static void Introducing()
        {
            int currentQ = Properties.Settings.Default.currentQuestionId;
            if (currentQ >= 1)
            {
                SendKeys.SendWait("{F11}");
                ani.Spell("oh dear welcome back! " + ani.GetMachineName() + ",", 50, ConsoleColor.White);
                ani.Answer(currentQ);
            }
            else
            {
                ani.Spell("hi " + ani.GetMachineName() + ",", 50, ConsoleColor.White);
                ani.Spell("we have a lot of question for you!", 50, ConsoleColor.White);
                ani.Spell("do you know the VAG members ? so if you know the members thats easy for you.", 50, ConsoleColor.White);
                ani.Spell("lets shall we begin.", 50, ConsoleColor.White);
                SendKeys.SendWait("{F11}");
                ani.Answer(1);
            }
        }
        static void Main(string[] args)
        {
            ani.SpellWithNoSpace("can you wait a sec, checkin my args...", 50, ConsoleColor.Green);
            ani.Think(2);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            ani.ClearCurrentConsoleLine();
            ani.SpellWithNoSpace("ok..", 50, ConsoleColor.Green);
            ani.Think(3);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            ani.ClearCurrentConsoleLine();

            Introducing();
            NextStep();
        }

        private static void NextStep()
        {
            ani.SpellWithNoSpace("i creatin new file on ur desktop", 50, ConsoleColor.Green);
            ani.Think(3);
            FileCreateAndWrite(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\B_A_S_E_6_4.txt", Encode("berkcan").ToString());            
            ani.Spell("you have 300 sec solve for this puzzle, hurry!", 50, ConsoleColor.Green);
            var newTime = DateTime.Now.AddMinutes(5).Ticks;
            int i = 0;
            while (true)
            {
                i++;
                ani.ClearCurrentConsoleLine();
                ani.SpellWithNoSpace(i.ToString(), 50);
                Thread.Sleep(1000);
                if (DateTime.Now.Ticks >= newTime)
                {
                    break;
                }
            }
        }
        private static string Decode(string text)
        {
            var data = Convert.FromBase64String(text);
            return Encoding.UTF8.GetString(data);
        }
        private static string Encode(string text)
        {
            var data = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(data);
        }
        private static void FileCreateAndWrite(string path, string text)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            File.WriteAllText(path, text);
        }
    }
}

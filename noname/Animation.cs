using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace noname
{
    public class Animation
    {
        int counter, timer;
        List<QuestionModel> questionList = new List<QuestionModel>();
        Questions question = new Questions();
        public Animation()
        {
            counter = 0;
            timer = 100;
            questionList = question.GetAll();
            while (question == null)
            {
                questionList = question.GetAll();
            }
        }
        public void Turn()
        {
            counter++;
            switch (counter % 4)
            {
                case 0: Console.Write("/"); Thread.Sleep(timer); break;
                case 1: Console.Write("-"); Thread.Sleep(timer); break;
                case 2: Console.Write("\\"); Thread.Sleep(timer); break;
                case 3: Console.Write("|"); Thread.Sleep(timer); break;
            }
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }
        public void Spell(string text, int timer, ConsoleColor color)
        {
            if (text == "" || text == null)
            {
                Console.WriteLine();
                return;
            }
            Console.ForegroundColor = color;
            foreach (var item in text.ToArray())
            {
                Console.Write(item);
                Thread.Sleep(timer);
            }
            Console.WriteLine();
        }
        public void SpellWithNoSpace(string text, int timer, ConsoleColor color)
        {
            if (text == "" || text == null)
            {
                Console.Write("");
                return;
            }
            Console.ForegroundColor = color;
            foreach (var item in text.ToArray())
            {
                Console.Write(item);
                Thread.Sleep(timer);
            }
            Console.Write("");
        }
        public void Think(int second)
        {
            var newTime = DateTime.Now.AddSeconds(+second).Ticks;
            while (true)
            {
                Turn();
                if (DateTime.Now.Ticks >= newTime)
                {
                    break;
                }
            }
            Console.WriteLine();
        }
        public void Answer(int id)
        {
            Properties.Settings.Default.currentQuestionId = id;
            Properties.Settings.Default.Save();
            Thread.Sleep(1500);
            Console.Clear();
            var q = questionList.Single(x => x.id == id);
            Spell(q.question, 50, ConsoleColor.Green);
            Console.ForegroundColor = ConsoleColor.White;
            var answer = Console.ReadLine();
            SpellWithNoSpace("im thinkin..", 34, ConsoleColor.Green);
            Think(1);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            ClearCurrentConsoleLine();
            if (q.answer.ToLower() == answer.ToLower())
            {
                Spell(q.success, 50, ConsoleColor.DarkCyan);
                Thread.Sleep(1500);
                Answer(id + 1);
            }
            else
            {
                Spell(q.failed, 34, ConsoleColor.Red);
                Thread.Sleep(1500);
                Answer(id);
            }
        }
        public string GetMachineName()
        {
            string machineName = "";
            try
            {
                machineName = Environment.MachineName;
                if (machineName == "") machineName = System.Net.Dns.GetHostName();
                if (machineName == "") machineName = System.Environment.GetEnvironmentVariable("COMPUTERNAME");
            }
            catch
            {
                return null;
            }
            return machineName;
        }

        public void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}

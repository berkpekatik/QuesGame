using System;
using System.Collections.Generic;
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
            ani.Spell("hi " + ani.GetMachineName() + ",", 50, ConsoleColor.White);
            ani.Spell("we have a lot of question for you!", 50, ConsoleColor.White);
            ani.Spell("do you know the VAG members ? so if you know the members thats easy for you.", 50, ConsoleColor.White);
            ani.Spell("lets shall we begin.", 50, ConsoleColor.White);
        }
        static void Main(string[] args)
        {
            ani.SpellWithNoSpace("can you wait a sec, i check my args...", 50, ConsoleColor.Green);
            ani.Think(2);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            ani.ClearCurrentConsoleLine();
            ani.SpellWithNoSpace("ok..", 50, ConsoleColor.Green);
            ani.Think(3);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            ani.ClearCurrentConsoleLine();

            Introducing();
            ani.Answer(1);
        }
    }
}

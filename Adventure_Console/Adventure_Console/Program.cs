using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Adventure_Console
{
    class Program
    {
        public DataParser dp = new DataParser();

        static void Main(string[] args)
        {
            DataParser dp = new DataParser();
            dp.InitalizeGame(Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Game.dat"));
            Console.WriteLine(dp.rooms[0].Description);
            Console.ReadLine();
            interaction();
        }

        private static void interaction() {
            Console.ReadLine();
            interaction();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monarch.ConsoleApplication.Games
{
    public class GameLog : ILog
    {
        public void Output()
        {
            Console.WriteLine("Dummy Log Output");
        }
    }
}

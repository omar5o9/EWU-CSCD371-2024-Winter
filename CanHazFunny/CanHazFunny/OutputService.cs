using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class OutputService : PrintJokeInterface
    {
        public void PrintJokeToScreen(string joke)
        {
            Console.WriteLine(joke);
        }
    }
}

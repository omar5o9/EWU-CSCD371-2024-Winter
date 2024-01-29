using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;

    public class Jester
    {
        public IJokeServiceInterface? JokeService { get; set; }
        public IPrintJokeInterface? Printer { get; set; }

        public Jester(IJokeServiceInterface? jokeService, IPrintJokeInterface? printer)
        {
            this.JokeService = jokeService;
            this.Printer = printer;
        }

        public void TellJoke()
        {
            if (JokeService == null || Printer == null)
            {
                Console.WriteLine("Error: JokeService or Printer is not set.");
                return;
            }

            string joke;

            do
            {
                joke = JokeService.GetJoke();
            } while (joke.Contains("Chuck Norris"));

            Printer.PrintJokeToScreen(joke);
        }
    }




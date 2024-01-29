using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;

    public class Jester
    {
        public JokeServiceInterface? JokeService { get; set; }
        public PrintJokeInterface? Printer { get; set; }

        public Jester(JokeServiceInterface? jokeService, PrintJokeInterface? printer)
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




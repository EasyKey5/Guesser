using System;


namespace Guesser
{
    class Game
    {
        private Random rnd = new Random();
        private int target;
        private int guesscount = 1;
        public int maxguesses = 5;
        public int minnum = 0;
        public int maxnum = 10;


        public Game() => target = rnd.Next(minnum, maxnum);
        public Game(int range) => target = rnd.Next(range);

        public void GetUserPrefs()
        {
            Console.Write("Please enter the minimum number: ");
            minnum = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter the maximum number: ");
            maxnum = Convert.ToInt32(Console.ReadLine());
            target = rnd.Next(minnum, maxnum);
            Console.Write("How many guesses would you like: ");
            maxguesses = Convert.ToInt32(Console.ReadLine());
        }
        
        public void Guess(int guess)
        {
            if (guess < target)
            {
                Console.WriteLine("Too Low!");
            } else if (guess > target)
            {
                Console.WriteLine("Too High!");
            } else
            {
                Console.WriteLine("CORRECT!");
                Console.WriteLine("You took {0} guesses", guesscount);
                return;
            
            } if (guesscount < maxguesses)
            {
                Console.WriteLine("You have {0} remaining guesses!", maxguesses - guesscount);
                guesscount++;
            } else if (guesscount >= maxguesses)
            {
                Console.WriteLine("YOU RAN OUT OF GUESSES :(");
                Console.WriteLine("The correct number was {}", target);
            }
           
        }

        public void Play()
        {
            guesscount = 1;
            target = rnd.Next(minnum, maxnum);
            for (var i = 0; i < maxguesses; i++)
            {
                Console.WriteLine("Enter your gues below:");
                int guess = Convert.ToInt32(Console.ReadLine());
                Guess(guess);
                if (guess == target) { break; };
            }
            
            Console.WriteLine("Would you like to play again? (y/n):");
            var res = Console.ReadLine();
            if (res == "y")
            {
                Play(); 
            }
        }
        
    }
    class Programw
    {

        static void Main(string[] args)
        {

            Game myGuesser = new Game();
            myGuesser.GetUserPrefs();
            myGuesser.Play();

        }
        
    }
}
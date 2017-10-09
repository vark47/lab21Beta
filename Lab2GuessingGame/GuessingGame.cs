using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2GuessingGame
{
    public class GuessingGame
    {
        int number;
        public int Number
        {
            get { return number; }
            set { number = value;  }
        }

        public GuessingGame()
        {
            Random random = new Random();
            number = random.Next(0, 101);
        }

        public GuessingGame(int n)
        {
            number = n;
        }

        public string Guess(int guess)
        {
            string result;
            if (guess == number)
                result = "Congratulations! You guessed it.";
            else if (guess > number)
                result = "Too high. Guess again.";
            else if (guess < number)
                result = "Too low. Guess again.";
            else
                result = "huh?";
            return result;
        }
    }
}

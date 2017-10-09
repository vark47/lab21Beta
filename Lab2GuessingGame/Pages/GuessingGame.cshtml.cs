using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab1GuessingGame.Pages
{
    public class GuessingGameModel : PageModel
    {
        Random random = new Random();
        public string Number { get; set; }
        public string Result { get; set; }
        public void OnGet()
        {
            Number = random.Next(0, 101).ToString();
        }

        public IActionResult OnPost()
        {
            string guess = Request.Form["Guess"];
            Number = Request.Form["number"];
            int n = int.Parse(Number);
            int.TryParse(Number, out n);
            int guessInt;
            if (int.TryParse(guess, out guessInt))
            {
                if (guessInt == n)
                    Result = "Congratulations! You guessed it";
                else if (guessInt > n)
                    Result = "Too high. Guess again.";
                else if (guessInt < n)
                    Result = "Too low. Guess again.";
            }
            else
            {
                Result = "Please enter a valid integer";
            }
            return Page();
        }
    }
}
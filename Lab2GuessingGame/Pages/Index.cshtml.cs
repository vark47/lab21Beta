using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Lab2GuessingGame.Pages
{
    public class GuessingGameModel : PageModel
    {
        GuessingGame game = null;
        public int Number { get { return game.Number; } }
        public string Result { get; set; }

        const string RAND_NUMBER = "RandNumber";

        public void OnGet()
        {
            game = new GuessingGame();
            HttpContext.Session.SetInt32(RAND_NUMBER, Number);
        }

        public IActionResult OnPost()
        {
            game = new GuessingGame(
                (int)HttpContext.Session.GetInt32(RAND_NUMBER)
                );

            //get user's guess from form
            string guess = Request.Form["UserGuess"];
            int guessInt;
            if (int.TryParse(guess, out guessInt))
            {
                Result = game.Guess(guessInt);
            }
            else
            {
                Result = "Please enter a valid integer";
            }
            return Page();
        }
    }
}

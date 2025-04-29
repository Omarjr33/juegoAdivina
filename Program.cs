using System;
using HiddenTagGame;

namespace TagGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            Console.Title = "Encuentra la Etiqueta Oculta";
            UI.DisplayWelcomeMessage();
            
            var productRepository = new ProductRepository();
            var gameEngine = new GameEngine(productRepository);
            
            bool playAgain = true;
            while (playAgain)
            {
                gameEngine.StartNewGame();
                UI.DisplayGameState(gameEngine);
                
                while (!gameEngine.IsGameOver)
                {
                    string guess = UI.GetUserGuess();
                    
                    if (string.IsNullOrWhiteSpace(guess))
                    {
                        UI.DisplayMessage("Por favor, ingresa una etiqueta válida.", ConsoleColor.Yellow);
                        continue;
                    }
                    
                    gameEngine.ProcessGuess(guess);
                    UI.DisplayGameState(gameEngine);
                }
                
                playAgain = UI.AskToPlayAgain();
                Console.Clear();
            }
            
            UI.DisplayGoodbyeMessage();
        }
    }
}
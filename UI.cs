using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace HiddenTagGame
{
    public static class UI
    {
        public static void DisplayWelcomeMessage()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\n");
            Console.WriteLine("╔═══════════════════════════════════════════════════╗");
            Console.WriteLine("║       ENCUENTRA LA ETIQUETA OCULTA                ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════╝");
            Console.ResetColor();
            
            Console.WriteLine("\nBienvenido al juego de adivinanza de etiquetas ocultas!\n");
            Console.WriteLine("Instrucciones:");
            Console.WriteLine(" • Tendrás una lista de productos con sus etiquetas");
            Console.WriteLine(" • El sistema elige aleatoriamente una etiqueta oculta");
            Console.WriteLine(" • Tu misión es adivinar cuál es esa etiqueta");
            Console.WriteLine(" • Tienes un número limitado de intentos");
            Console.WriteLine("\nPresiona cualquier tecla para comenzar...");
            
            Console.ReadKey(true);
            Console.Clear();
        }
        
        public static void DisplayGameState(GameEngine game)
        {
            Console.Clear();
            
            // Display header
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n╔═══════════════════════════════════════════════════╗");
            Console.WriteLine("║       ENCUENTRA LA ETIQUETA OCULTA                ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════╝");
            Console.ResetColor();
            
            // Display products and their tags
            Console.WriteLine("\nPRODUCTOS DISPONIBLES:");
            Console.ForegroundColor = ConsoleColor.White;
            
            foreach (var product in game.VisibleProducts)
            {
                Console.WriteLine($" • {product.Name}:");
                Console.WriteLine($"   Etiquetas: {string.Join(", ", product.Tags)}");
            }
            
            Console.ResetColor();
            
            // Display game progress
            Console.WriteLine("\n═════════════════════════════════════════════════════");
            Console.WriteLine($"Intentos restantes: {game.GetRemainingAttempts()} de {game.MaxAttempts}");
            
            // Display previous guesses if any
            if (game.PreviousGuesses.Any())
            {
                Console.WriteLine("\nETIQUETAS PROBADAS:");
                foreach (var guess in game.PreviousGuesses)
                {
                    Console.WriteLine($" • {guess}");
                }
            }
            
            // Display game result if game is over
            if (game.IsGameOver)
            {
                Console.WriteLine("\n═════════════════════════════════════════════════════");
                
                if (game.IsWinner)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n¡FELICIDADES! Has encontrado la etiqueta oculta.");
                    Console.WriteLine($"La etiqueta era: {game.GetHiddenTag()}");
                    Console.WriteLine($"Lo lograste en {game.CurrentAttempts} intento(s).");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n¡GAME OVER! Se te acabaron los intentos.");
                    Console.WriteLine($"La etiqueta oculta era: {game.GetHiddenTag()}");
                }
                
                Console.ResetColor();
            }
            
            Console.WriteLine("\n═════════════════════════════════════════════════════");
        }
        
        public static string GetUserGuess()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nIntroduce tu adivinanza: ");
            Console.ResetColor();
            return Console.ReadLine()?.Trim().ToLower() ?? string.Empty;
        }
        
        public static bool AskToPlayAgain()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n¿Quieres jugar otra vez? (s/n): ");
            Console.ResetColor();
            
            var key = Console.ReadKey(false).KeyChar.ToString().ToLower();
            return key == "s";
        }
        
        public static void DisplayMessage(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
            Thread.Sleep(1000); // Pause briefly so the message can be read
        }
        
        public static void DisplayGoodbyeMessage()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\n");
            Console.WriteLine("╔═══════════════════════════════════════════════════╗");
            Console.WriteLine("║       GRACIAS POR JUGAR                           ║");
            Console.WriteLine("║       ENCUENTRA LA ETIQUETA OCULTA                ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════╝");
            Console.ResetColor();
            
            Console.WriteLine("\n¡Hasta la próxima!");
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            
            Console.ReadKey(true);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace HiddenTagGame
{
    public class GameEngine
    {
        private readonly ProductRepository _productRepository;
        private readonly Random _random;
        
        private List<Product> _currentProducts;
        private string _hiddenTag;
        private List<string> _allTags;
        private HashSet<string> _guessedTags;
        
        public bool IsGameOver { get; private set; }
        public bool IsWinner { get; private set; }
        public int CurrentAttempts { get; private set; }
        public int MaxAttempts { get; private set; }
        public List<string> PreviousGuesses => _guessedTags.ToList();
        public List<Product> VisibleProducts => _currentProducts;
        
        public GameEngine(ProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _random = new Random();
            _guessedTags = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            
            // Initialize with default values
            _currentProducts = new List<Product>();
            _allTags = new List<string>();
            _hiddenTag = string.Empty;
            
            IsGameOver = true;
            IsWinner = false;
            CurrentAttempts = 0;
            MaxAttempts = 5;
        }
        
        public void StartNewGame(int productCount = 5, int maxAttempts = 5)
        {
            // Reset game state
            _guessedTags.Clear();
            IsGameOver = false;
            IsWinner = false;
            CurrentAttempts = 0;
            MaxAttempts = maxAttempts;
            
            // Get random products
            _currentProducts = _productRepository.GetRandomProducts(productCount);
            
            // Flatten all tags using SelectMany
            _allTags = _currentProducts
                .SelectMany(p => p.Tags)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
            
            // Choose a hidden tag randomly
            _hiddenTag = _allTags[_random.Next(_allTags.Count)];
        }
        
        public bool ProcessGuess(string guess)
        {
            if (IsGameOver)
                return false;
            
            // Add to guessed tags list (case insensitive)
            _guessedTags.Add(guess);
            
            // Check if guess is correct
            bool isCorrect = string.Equals(guess, _hiddenTag, StringComparison.OrdinalIgnoreCase);
            
            // Increment attempts
            CurrentAttempts++;
            
            // Update game state
            if (isCorrect)
            {
                IsGameOver = true;
                IsWinner = true;
            }
            else if (CurrentAttempts >= MaxAttempts)
            {
                IsGameOver = true;
                IsWinner = false;
            }
            
            return isCorrect;
        }
        
        public string GetHiddenTag()
        {
            return IsGameOver ? _hiddenTag : "???";
        }
        
        public List<string> GetRemainingTags()
        {
            return _allTags
                .Where(tag => !_guessedTags.Contains(tag))
                .ToList();
        }
        
        public int GetRemainingAttempts()
        {
            return MaxAttempts - CurrentAttempts;
        }
    }
}
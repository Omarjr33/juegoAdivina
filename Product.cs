using System;
using System.Collections.Generic;

namespace HiddenTagGame
{
    public class Product
    {
        public string Name { get; }
        public List<string> Tags { get; }

        public Product(string name, List<string> tags)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Tags = tags ?? throw new ArgumentNullException(nameof(tags));
        }

        public override string ToString()
        {
            return $"{Name} - [{string.Join(", ", Tags)}]";
        }
    }
}
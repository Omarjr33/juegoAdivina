using System;
using System.Collections.Generic;
using System.Linq;

namespace HiddenTagGame
{
    public class ProductRepository
    {
        private readonly List<Product> _products;
        private readonly Random _random;

        public ProductRepository()
        {
            _random = new Random();
            _products = InitializeProducts();
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public List<Product> GetRandomProducts(int count)
        {
            // Ensure we don't try to get more products than exist
            count = Math.Min(count, _products.Count);
            
            // Shuffle the products and take the requested number
            return _products
                .OrderBy(x => _random.Next())
                .Take(count)
                .ToList();
        }

        private List<Product> InitializeProducts()
        {
            return new List<Product>
            {
                new Product("Smartphone", new List<string> { "electrónica", "comunicación", "portátil", "táctil", "inteligente" }),
                new Product("Laptop", new List<string> { "electrónica", "computadora", "portátil", "trabajo", "pantalla" }),
                new Product("Tablet", new List<string> { "electrónica", "portátil", "táctil", "pantalla", "ligero" }),
                new Product("Auriculares", new List<string> { "electrónica", "audio", "música", "portátil", "inalámbrico" }),
                new Product("Zapatillas", new List<string> { "calzado", "deportivo", "confort", "casual", "ligero" }),
                new Product("Camiseta", new List<string> { "ropa", "algodón", "casual", "prenda", "verano" }),
                new Product("Libro", new List<string> { "lectura", "papel", "conocimiento", "entretenimiento", "cultura" }),
                new Product("Reloj", new List<string> { "accesorio", "tiempo", "pulsera", "digital", "analógico" }),
                new Product("Mochila", new List<string> { "bolso", "viaje", "escolar", "almacenamiento", "portátil" }),
                new Product("Sartén", new List<string> { "cocina", "utensilios", "antiadherente", "metal", "comida" }),
                new Product("Planta", new List<string> { "decoración", "naturaleza", "hogar", "verde", "vida" }),
                new Product("Cámara", new List<string> { "electrónica", "fotografía", "imagen", "memoria", "digital" }),
                new Product("Perfume", new List<string> { "fragancia", "aroma", "cosmético", "personal", "lujo" }),
                new Product("Juguete", new List<string> { "niños", "diversión", "plástico", "entretenimiento", "colorido" }),
                new Product("Chocolate", new List<string> { "comida", "dulce", "postre", "cacao", "azúcar" })
            };
        }
    }
}
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Online Ordering System\n");

        // Create addresses for customers
        Address usaAddress = new Address("123 Main Street", "Seattle", "WA", "USA");
        Address internationalAddress = new Address("456 Maple Avenue", "Toronto", "Ontario", "Canada");
        
        // Create customers
        Customer usaCustomer = new Customer("Sarah Johnson", usaAddress);
        Customer internationalCustomer = new Customer("David Martinez", internationalAddress);
        
        // Create products
        Product laptop = new Product("Premium Laptop", "TECH1001", 1299.99, 1);
        Product headphones = new Product("Wireless Headphones", "TECH1002", 199.99, 1);
        Product phoneCase = new Product("Phone Case", "ACC2001", 29.99, 2);
        Product keyboard = new Product("Mechanical Keyboard", "TECH1003", 149.99, 1);
        Product mouse = new Product("Wireless Mouse", "TECH1004", 49.99, 1);
        
        // Create first order (USA customer)
        Console.WriteLine("ORDER #1");
        Console.WriteLine("========\n");
        
        Order order1 = new Order(usaCustomer);
        order1.AddProduct(laptop);
        order1.AddProduct(headphones);
        order1.AddProduct(phoneCase);
        
        // Display order 1 information
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Price: ${order1.CalculateTotalCost():F2}");
        Console.WriteLine();
        
        // Create second order (International customer)
        Console.WriteLine("ORDER #2");
        Console.WriteLine("========\n");
        
        Order order2 = new Order(internationalCustomer);
        order2.AddProduct(keyboard);
        order2.AddProduct(mouse);
        order2.AddProduct(headphones);
        
        // Display order 2 information
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Price: ${order2.CalculateTotalCost():F2}");
    }
}
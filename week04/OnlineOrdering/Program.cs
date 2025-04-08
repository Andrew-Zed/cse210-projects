using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");

        // Create addresses
        Address usaAddress = new Address("123 Main St", "Seattle", "WA", "USA");
        Address internationalAddress = new Address("456 Maple Ave", "Toronto", "Ontario", "Canada");
        
        // Create customers
        Customer usaCustomer = new Customer("John Smith", usaAddress);
        Customer internationalCustomer = new Customer("Emma Johnson", internationalAddress);
        
        // Create products
        Product product1 = new Product("Laptop", "TECH001", 899.99, 1);
        Product product2 = new Product("Wireless Mouse", "TECH002", 24.99, 2);
        Product product3 = new Product("Headphones", "TECH003", 149.99, 1);
        Product product4 = new Product("USB Drive", "TECH004", 19.99, 3);
        Product product5 = new Product("Phone Charger", "TECH005", 15.99, 2);
        
        // Create first order (USA)
        Order order1 = new Order(usaCustomer);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);
        
        // Create second order (International)
        Order order2 = new Order(internationalCustomer);
        order2.AddProduct(product3);
        order2.AddProduct(product4);
        order2.AddProduct(product5);
        
        // Display order 1 details
        Console.WriteLine("ORDER 1");
        Console.WriteLine("-------");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost():F2}");
        Console.WriteLine();
        
        // Display order 2 details
        Console.WriteLine("ORDER 2");
        Console.WriteLine("-------");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost():F2}");
    }
}
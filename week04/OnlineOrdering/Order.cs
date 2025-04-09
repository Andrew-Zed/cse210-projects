using System;
using System.Collections.Generic;

public class Order
{
    // Private member variables
    private List<Product> _products;
    private Customer _customer;

    // Constructor
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    // Properties
    public Customer Customer
    {
        get { return _customer; }
        set { _customer = value; }
    }

    // Methods
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Calculate total cost including shipping
    public double CalculateTotalCost()
    {
        double productTotalCost = 0;
        
        foreach (Product product in _products)
        {
            productTotalCost += product.CalculateTotalCost();
        }
        
        // Add shipping cost
        double shippingCost = _customer.IsInUSA() ? 5 : 35;
        
        return productTotalCost + shippingCost;
    }

    // Generate packing label
    public string GetPackingLabel()
    {
        string packingLabel = "PACKING LABEL:\n";
        
        foreach (Product product in _products)
        {
            packingLabel += $"Product: {product.Name}, ID: {product.ProductId}\n";
        }
        
        return packingLabel;
    }

    // Generate shipping label
    public string GetShippingLabel()
    {
        string shippingLabel = "SHIPPING LABEL:\n";
        shippingLabel += $"Customer: {_customer.Name}\n";
        shippingLabel += $"Address:\n{_customer.Address.GetFullAddress()}\n";
        
        return shippingLabel;
    }
}
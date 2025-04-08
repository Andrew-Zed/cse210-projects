public class Customer
{
    // Private member variables
    private string _name;
    private Address _address;

    // Constructor
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Properties
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public Address Address
    {
        get { return _address; }
        set { _address = value; }
    }

    // Method to determine if the customer lives in the USA
    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }
}
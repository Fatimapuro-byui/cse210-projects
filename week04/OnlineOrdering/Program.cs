using System;

class Program
{
    static void Main()
    {
        
        Product product1 = new Product("Dark Chocolate Bar", 101, 3.5, 2);
        Product product2 = new Product("Chocolate Box", 102, 10.0, 1);
        Product product3 = new Product("Chocolate Chip Cookies", 103, 4.5, 3);
        Product product4 = new Product("Milk Chocolate", 104, 5.5, 4);
        Product product5 = new Product("White Chocolate", 105, 6.5, 5);



        
        Address address1 = new Address("549 Main St", "Salt Lake City", "UT", "USA");
        Address address2 = new Address("135 Altamira Ave", "Caracas", "CAR", "Venezuela");

        
        Customer customer1 = new Customer("Rafael Moran", address1);
        Customer customer2 = new Customer("Teresa De La Parra", address2);

        
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);
        order2.AddProduct(product5);



        
        Console.WriteLine("Order 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost()}\n");

        Console.WriteLine("Order 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost()}\n");
    }
}

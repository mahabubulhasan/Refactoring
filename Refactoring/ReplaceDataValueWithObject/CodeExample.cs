namespace Refactoring.ReplaceDataValueWithObject
{
    namespace Before
    {
        class Order
        {
            public string Customer { get; set; }
            public Order(string customer)
            {
                Customer = customer;
            }

            private static int NumberOfOrdersFor(IEnumerable<Order> orders, string customer)
            {
                return orders.Count(o => o.Customer == customer);
            }
        }
    }

    namespace After
    {
        class Order
        {
            public Customer Customer { get; set; }

            public Order(Customer customer)
            {
                Customer = customer;
            }

            private static int NumberOfOrdersFor(IEnumerable<Order> orders, Customer customer)
            {
                return orders.Count(o => o.Customer.Equals(customer));
            }

        }

        class Customer
        {
            public string Name { get; private set; }

            public Customer(string name)
            {
                Name = name;
            }

            public override bool Equals(object? obj)
            {
                return Name.Equals((obj as Customer)?.Name, StringComparison.Ordinal);
            }

            public override int GetHashCode()
            {
                return Name.GetHashCode();
            }
        }
    }
}

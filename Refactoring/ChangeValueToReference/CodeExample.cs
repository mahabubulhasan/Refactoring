namespace Refactoring.ChangeValueToReference
{
    namespace Before
    {
        class Order
        {
            private Customer _customer;

            public String customerName
            {
                get => _customer.Name;
                set => _customer = new Customer(value);
            }

            public Order(string customerName)
            {
                _customer = new Customer(customerName);
            }

            private static int NumberOfOrdersFor(IEnumerable<Order> orders, string customerName) 
            {
                return orders.Count(o => o.customerName == customerName);
            }
        }

        class Customer
        {
            public string Name { get; set; }

            public Customer(string name)
            {
                Name = name;
            }

            public override bool Equals(object? obj) => Name.Equals(obj);

            public override int GetHashCode() => Name.GetHashCode();
        }
    }

    namespace After
    {
        class Order
        {
            private Customer _customer;

            public string CustomerName
            {
                get => _customer.Name;
                set => Customer.GetExistingCustomer(value);
            }

            public Order(string customerName)
            {
                _customer = Customer.GetExistingCustomer(customerName);
            }

            private static int NumberOfOrdersFor(IEnumerable<Order> orders, string customer)
            {
                return orders.Count(o => o.CustomerName.Equals(customer, StringComparison.InvariantCultureIgnoreCase);
            }
        }

        class Customer
        {
            private static HashSet<Customer> ExistingCustomers = new();

            static Customer()
            {
                ExistingCustomers.Add(new("Microsoft Inc"));
                ExistingCustomers.Add(new("Apple Inc"));
                // etc.
            }

            public string Name { get; set; }

            private Customer(string name)
            {
                Name = name;
            }

            public static Customer GetExistingCustomer(string name)
            {
                return ExistingCustomers.Single(c => c.Name == name);
            }

            public override bool Equals(object? obj) => Name.Equals(obj);

            public override int GetHashCode() => Name.GetHashCode();
        }
    }
}

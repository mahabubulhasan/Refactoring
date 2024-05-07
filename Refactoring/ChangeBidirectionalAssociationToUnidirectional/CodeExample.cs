namespace Refactoring.ChangeBidirectionalAssociationToUnidirectional
{
    namespace Before
    {
        class Order
        {
            private Customer _customer;
            public Customer Customer
            {
                get { return _customer; }
                set
                {
                    _customer.FriendOrders.Remove(this);
                    _customer = value;
                    _customer.FriendOrders.Add(this);
                }
            }
        }

        class Customer
        {
            private HashSet<Order> _orders = new HashSet<Order>();

            public IEnumerable<Order> Orders
            {
                get { return _orders; }
            }

            internal HashSet<Order> FriendOrders
            {
                get { return _orders; }
            }
        }
    }

    namespace After
    {
        class Order
        {
            public Customer Customer
            {
                get
                {
                    var customers = Customer.FindCustomers(new CustomerSearchCriteria { Order = this });

                    if (customers.Count() < 1)
                    {
                        throw new Exception("not found");
                    }
                    if (customers.Count() > 1)
                    {
                        throw new Exception("Multiple customer found");
                    }

                    return customers.Single();
                }
            }
        }

        class Customer
        {
            private HashSet<Order> _orders = new HashSet<Order>();

            public HashSet<Order> Orders
            {
                get { return _orders; }
            }

            public static IEnumerable<Customer> GetAllCustomers()
            {
                return new List<Customer>();
            }

            public static IEnumerable<Customer> FindCustomers(CustomerSearchCriteria criteria)
            {
                return new List<Customer>();
            }
        }

        class CustomerSearchCriteria
        {
            public Order Order { get; set; }
        }
    }
}

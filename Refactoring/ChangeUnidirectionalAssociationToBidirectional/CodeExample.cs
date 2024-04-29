namespace Refactoring.ChangeUnidirectionalAssociationToBidirectional
{
    namespace Before
    {
        class Order
        {
            public Customer Customer { get; set; }
        }

        class Customer
        {
            private HashSet<Order> _orders = new();

            public IEnumerable<Order> Orders => _orders;
        }
    }

    namespace After 
    {
        class Order
        {
            private HashSet<Customer> _customers = new();

            public IEnumerable<Customer> Customers => _customers;

            public void AddCustomer(Customer customer)
            {
                customer.FriendOrders.Add(this);
                _customers.Add(customer);
            }

            public void RemoveCustomer(Customer customer)
            {
                customer.FriendOrders.Remove(this);
                _customers.Remove(customer);
            }
        }

        class Customer
        {
            private HashSet<Order> _orders = new();

            public IEnumerable<Order> Orders => _orders;

            internal HashSet<Order> FriendOrders => _orders;

            public void AddOrder(Order order)
            {
                order.AddCustomer(this);
            }

            public void RemoveOrder(Order order)
            {
                order.RemoveCustomer(this);
            }
        }
    }
}

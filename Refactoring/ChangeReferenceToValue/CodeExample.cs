namespace Refactoring.ChangeReferenceToValue
{
    namespace Before 
    {
        class Currency
        {
            public string Name { get; private set; }

            private Currency(string name)
            {
                Name = name;
            }

            public static Currency Create(string name) {
                return new Currency(name);
            }
        }
    }

    namespace After 
    {
        class Currency
        {
            public string Name { get; private set; }

            public Currency(string name)
            {
                Name= name;
            }

            public override bool Equals(object? obj) => Name.Equals((obj as Currency)?.Name);

            public override int GetHashCode() => Name.GetHashCode();
        }

        class Example
        {
            public bool Sample()
            {
                return new Currency("USD").Equals(new Currency("USD"));
            }
        }
    }
}

using System.Runtime.CompilerServices;

namespace Refactoring.ReplaceTypeCodeWithSubclasses
{
    namespace Before
    {
        class Employee
        {
            public const int ENGINEER = 0;
            public const int SALESMAN = 1;
            public const int MANAGER = 2;

            public int Type { get; private set; }

            public Employee(int type)
            {
                Type = type;
            }
        }
    }

    namespace After
    {
        abstract class Employee
        {
            public const int ENGINEER = 0;
            public const int SALESMAN = 1;
            public const int MANAGER = 2;

            public abstract int Type { get; }

            protected Employee() { }

            public static Employee Create(int type)
            {
                return type switch
                {
                    ENGINEER => new Engineer(),
                    SALESMAN => new Salesman(),
                    MANAGER => new Manager(),
                    _ => throw new Exception("Unknown type"),
                };
            }
        }

        class Engineer : Employee
        {
            public override int Type 
            { 
                get => Employee.ENGINEER;
            }
        }

        class Salesman : Employee
        {
            public override int Type
            {
                get => SALESMAN;
            }
        }

        class Manager : Employee
        {
            public override int Type
            {
                get => MANAGER;
            }
        }
    }
}

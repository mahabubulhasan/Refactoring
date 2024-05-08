using System.Runtime.InteropServices;

namespace Refactoring.ReplaceTypeCodeWithClass
{
    namespace Before
    {
        class Person
        {
            public static int O = 0;
            public static int A = 1;
            public static int B = 2;
            public static int AB = 3;

            public int BloodGroup { get; private set; }

            public Person(int bloodGroup)
            {
                BloodGroup = bloodGroup;
            }
        }
    }

    namespace After
    {
        class Person
        {
            public BloodGroup BloodGroup { get; private set; }

            public Person(BloodGroup bloodGroup)
            {
                BloodGroup = bloodGroup;
            }
        }

        class BloodGroup
        {
            public static BloodGroup O = new(0);
            public static BloodGroup A = new(1);
            public static BloodGroup B = new(2);
            public static BloodGroup AB = new(3);

            private int Code { get; set; }

            private BloodGroup(int code)
            {
                Code = code;
            }

            public override bool Equals(object? obj)
            {
                return Code == ((BloodGroup)obj).Code;
            }

            public override int GetHashCode()
            {
                return Code.GetHashCode();
            }
        }
    }
}

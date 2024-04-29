namespace Refactoring.ReplaceArrayWithObject
{
    namespace Before 
    {
        class Example
        {
            void Test()
            {
                var arr = new string[2];
                arr[0] = "Dhaka";
                arr[1] = "1216";
            }
        }   
    }

    namespace After 
    {
        class Example 
        {
            void Test()
            {
                var city = new City();
                city.Name = "Dhaka";
                city.Zip = 1216;
            }   
        }

        class City
        {
            public string Name { get; set; } = string.Empty;
            public int Zip { get; set; }
        }
    }
}

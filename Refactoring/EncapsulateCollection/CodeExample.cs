namespace Refactoring.EncapsulateCollection
{
    namespace Before
    {
        class Person
        {
            public List<Course> Courses { get; set; }
        }

        class Course
        {
            public string Name { get; set; }
            public bool IsAdvanced { get; set; }
        }

        class SimpleExample
        {
            public void ManipulatingCourse()
            {
                var kent = new Person { Courses = new List<Course>() };
                kent.Courses.Add(new Course { Name = "Java", IsAdvanced = false });
                kent.Courses.Add(new Course { Name = "Kotlin", IsAdvanced = true });

                var refactoringCourse = new Course { Name = "Refactoring", IsAdvanced = false };
                kent.Courses.Add(refactoringCourse);

                kent.Courses.Add(new Course { Name = "C#", IsAdvanced = true });
                kent.Courses.Remove(refactoringCourse);
            }

            public void GettingCourseInfo()
            {
                var kent = new Person();
                var advancedCourse = kent.Courses.Count(c => c.IsAdvanced);
            }
        }
    }

    namespace After
    {
        class Person
        {
            private List<Course> _courses;
            public IReadOnlyList<Course> Courses
            {
                get => _courses.AsReadOnly();
            }

            public Person()
            {
                _courses = new List<Course>();
            }

            public void AddCourse(Course course)
            {
                _courses.Add(course);
            }

            public void RemoveCourse(Course course)
            {
                _courses.Remove(course);
            }
        }

        class Course
        {
            public string Name { get; set; }
            public bool IsAdvanced { get; set; }
        }

        class SimpleExample
        {
            public void ManipulatingCourse()
            {
                var kent = new Person();
                kent.AddCourse(new Course { Name = "Java", IsAdvanced = false });
                kent.AddCourse(new Course { Name = "Kotlin", IsAdvanced = true });

                var refactoringCourse = new Course { Name = "Refactoring", IsAdvanced = false };
                kent.AddCourse(refactoringCourse);

                kent.AddCourse(new Course { Name = "C#", IsAdvanced = true });
                kent.RemoveCourse(refactoringCourse);
            }

            public void GettingCourseInfo()
            {
                var kent = new Person();
                var advancedCourse = kent.Courses.Count(c => c.IsAdvanced);
            }
        }
    }
}

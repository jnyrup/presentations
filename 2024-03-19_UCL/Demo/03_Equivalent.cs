using FluentAssertions;
using Xunit;

namespace Demo;

public class Equivalent
{
    public class Person
    {
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
    }

    [Fact]
    public void BeEquivalentTo()
    {
        var subject = new Person("John", "Smith", 42);
        var expected = new Person("John", "Smith", 42);

        subject.Should().BeEquivalentTo(expected);
    }
}

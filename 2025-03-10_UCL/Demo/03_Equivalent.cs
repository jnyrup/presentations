using FluentAssertions;
using Xunit;

namespace Demo;

public class Equivalent
{
    public class Person
    {
        public Person(string firstName, string lastName, int age, City address)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Address = address;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public City Address { get; set; }
    }

    public class City
    {
        public int ID { get; set; }

        public string Name { get; set; }
    }

    [Fact]
    public void BeEquivalentTo()
    {
        var subject = new Person("John", "Smith", 42, null);
        var expected = new Person("John", "Smith", 42, new City { Name = "Snave" });

        subject.Should().BeEquivalentTo(expected);
    }
}

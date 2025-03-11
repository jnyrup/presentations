using FluentAssertions;
using Xunit;

namespace Demo;

public class EquivalentSubMatch
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
    public void Test()
    {
        var subject = new Person("John", "SmIth", 42);
        var expected = new Person("John", "Smiht", 43);

        subject.Should().BeEquivalentTo(expected, options => options
            .Excluding(e => e.Age)
            .WithoutStrictOrderingFor(e => e.LastName)
            .IgnoringCase(),
            "det har vi aftat med kunden, at de hedder");
    }
}

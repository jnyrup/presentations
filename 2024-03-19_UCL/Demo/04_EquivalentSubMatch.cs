using System;
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
        var subject = new Person("John", "Smith", 42);
        var expected = new
        {
            FirstName = "John",
            LastName = "Smith"
        };

        subject.Should().BeEquivalentTo(expected);
    }
}

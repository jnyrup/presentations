using System;
using FluentAssertions;
using Xunit;

namespace Demo;

public class EqualWithEquals
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

        public override bool Equals(object obj)
        {
            return obj is Person person
                && FirstName == person.FirstName
                && LastName == person.LastName
                && Age == person.Age;
        }

        public override int GetHashCode() => HashCode.Combine(FirstName, LastName, Age);
    }

    [Fact]
    public void Be()
    {
        var subject = new Person("John", "Smith", 42);
        var expected = new Person("John", "Smith", 42);

        subject.Should().Be(expected);
    }
}

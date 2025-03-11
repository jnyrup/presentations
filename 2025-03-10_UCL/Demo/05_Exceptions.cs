using System;
using FluentAssertions;
using Xunit;

namespace Demo;

public class Exceptions
{
    private class Person
    {
        public int Age { get; set; }
    }

    private static bool IsAbove18(Person person)
    {
        if (person is null)
        {
            throw new ArgumentNullException(nameof(person));
        }

        return person.Age > 18;
    }

    [Fact]
    public void IsAbove18_Invalid_Throws()
    {
        // Arrange
        Person person = null;

        // Act
        var act = () => IsAbove18(person);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithParameterName("person1");


    }
}

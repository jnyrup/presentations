using FluentAssertions;
using Xunit;

namespace Demo;

public class BasicEqual
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
    public void Be()
    {
        var subject = new Person("John", "Smith", 42);
        var expected = new Person("John", "Smith", 42);

        subject.Should().Be(expected);
    }

    [Fact]
    public void Be_XunitStyle()
    {
        var subject = new Person("John", "Smith", 42);
        var expected = new Person("John", "Smith", 42);

        Assert.Equal(expected.FirstName, subject.FirstName);
        Assert.Equal(expected.LastName, subject.LastName);
        Assert.Equal(expected.Age, subject.Age);
    }
}

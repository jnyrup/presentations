using System;
using FluentAssertions;
using Xunit;

namespace Demo;

public class Tests
{
    [Fact]
    public void Test()
    {
        Assert.True(new NumberGenerator(0).GetNumber() < 42);
    }
}

public class NumberGeneratorTests
{
    [Fact]
    public void A_number_generator_with_seed_0_gives_a_number_less_than_42()
    {
        // Arrange
        var seed = 0;
        var generator = new NumberGenerator(seed);

        // Act
        int number = generator.GetNumber();

        // Assert
        number.Should().BeLessThan(42,
            "because 42 is a special number");
    }
}

public class LOL
{
    public object GetObjectA()
    {
        var objectGenerator = ObjectGenerator.Instance;
        return objectGenerator.GetObject();
    }

    public object GetObject()
    {
        var objectGenerator = ObjectGenerator.Instance;
        if (objectGenerator is null)
        {
            // for tests
            return null;
        }

        return objectGenerator.GetObject();
    }

    public object GetObject(ObjectGenerator objectGenerator)
    {
        if (objectGenerator is null)
            throw new ArgumentNullException(nameof(objectGenerator));

        return objectGenerator.GetObject();
    }
}

public class ObjectGenerator
{
    public static ObjectGenerator Instance { get; }

    public object GetObject() => null;
}

public class NumberGenerator
{
    private readonly Random generator;

    public NumberGenerator(int seed) => generator = new Random(seed);

    public static object Instance { get; internal set; }

    public int GetNumber() => generator.Next();
}

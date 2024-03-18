using FluentAssertions;
using Xunit;

namespace Demo;

public class Basics
{
    [Fact]
    public void Strings()
    {
        var subject = "foo";

        subject.Should().Be("bar");
    }

    [Fact]
    public void Numerics()
    {
        var subject = 42;

        subject.Should().Be(42);
        subject.Should().BeGreaterThan(41);
        subject.Should().BeCloseTo(42, 1);
    }

    [Fact]
    public void Collections()
    {
        int[] subject = { 42 };

        subject.Should().NotBeEmpty()
            .And.ContainSingle()
                .Which.Should().Be(42);
    }
}

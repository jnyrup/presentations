using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Demo;

public class Basics
{
    [Fact]
    public void Strings()
    {
        var subject = "foo";

        subject.Should().HaveLength(5);
    }

    [Fact]
    public void Numerics()
    {
        var subject = 42;

        using var _ = new AssertionScope();
        subject.Should().Be(43);
        subject.Should().BeGreaterThan(43);
        subject.Should().BeCloseTo(44, 1);

        //subject.Should().Be(42)
        //    .And.BeGreaterThan(41)
        //    .And.BeCloseTo(42, 1);
    }

    [Fact]
    public void Collections()
    {
        object[] subject = null;

        subject.Should()
            //.NotBeNull()
            //.NotBeEmpty()
            //.And.NotBeEmpty()
            //.And.NotBeEmpty()
            //.And
            .ContainSingle()
                .Which.Should().BeOfType<string>()
                    .Which.Should().HaveLength(42);
    }

    [Fact]
    public void GoodTest()
    {
        var result = DOO(42);
        result.Should().BeOfType<string>();
        result.As<string>().Should().Be("good");
    }

    public object DOO(int i)
    {
        try
        {
            if (i > 42)
                return "good";

            return null;
        }
        catch
        {
            return "fail";
        }
    }
}

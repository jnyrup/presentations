using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using static FluentAssertions.FluentActions;

namespace Demo;

public class Ex08_ExceptionTests
{
    [Fact]
    public void DoesThrow_WrappedInAction_ThrowInvalidOperationException()
    {
        // Arrange
        var subject = new Thrower();

        // Act
        Action act = () => subject.DoesThrow();

        // Assert
        act.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void DoesThrow_UsingInvoking_ThrowInvalidOperationException()
    {
        // Arrange
        var subject = new Thrower();

        // Act
        Action act = subject.Invoking(e => e.DoesThrow());

        // Assert
        act.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void DoesNotThrow_Return42()
    {
        // Arrange
        var subject = new Thrower();

        // Act
        Func<int> act = () => subject.DoesNotThrow();

        // Assert
        act.Should().NotThrow()
            .Which.Should().Be(42);
    }

    [Fact]
    public void DoesThrow_ThrowInvalidOperationAdvanced()
    {
        // *  Throw InvalidOperationException,
        //  * which exception message contains "foobar"
        // * the InvalidOperationException has an InnerException, 
        //  * which is exactly DivideByZeroException,
        //  * which exception message contains "Dark Side"

        // Arrange
        var subject = new Thrower();

        // Act
        Action act = () => subject.DoesThrow();

        // Assert
        act.Should().Throw<InvalidOperationException>()
                .WithMessage("*foobar*")
                .WithInnerExceptionExactly<DivideByZeroException>()
                .WithMessage("*Dark Side*");
    }

    [Fact]
    public void Exception_Throws_Inline() =>
        Invoking(() => new Thrower().DoesThrow()).Should().Throw<InvalidOperationException>();

    #region Helpers
    private class Thrower
    {
        public void DoesThrow() =>
            throw new InvalidOperationException("Yada Yada foobar Yada Yada",
                new DivideByZeroException("Something, Something, Something, Dark Side"));

        public int DoesNotThrow() => 42;

        public Task DoesThrowAsync()
        {
            DoesThrow();
            return Task.CompletedTask;
        }

        public Task<int> DoesNotThrowAsync() => Task.FromResult(DoesNotThrow());
    }
    #endregion
}

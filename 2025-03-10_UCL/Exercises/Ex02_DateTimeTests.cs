using FluentAssertions;
using FluentAssertions.Common;
using FluentAssertions.Extensions;
using System;
using Xunit;

namespace Exercises;

public class Ex02_DateTimeTests
{
    [Fact]
    public void In_2025_Easter_Sunday_Falls_On_April_20th()
    {
        // Arrange
        var expected = 20.April(2025);

        // Act
        DateTime date = EasterSunday();

        // Assert
        throw new NotImplementedException();
    }

    [Fact]
    public void The_start_of_this_presentation_is_close_to_the_scheduled_time_give_or_take_5_minutes()
    {
        // Arrange
        var expectedStartOfLecture = 11.March(2025).At(08.Hours(30.Minutes()));

        // Act
        DateTime date = StartOfThisPresentation();

        // Assert
        throw new NotImplementedException();
    }

    [Fact]
    public void In_2025_Danish_daylight_saving_time_ends_26th_of_October_at_0300_GMT_Plus2()
    {
        // Express expectedEndOfDst using the Fluent API from FluentAssertions.Extensions
        // See https://fluentassertions.com/datetimespans/ for examples

        // Arrange
        DateTimeOffset expectedEndOfDst = default;

        // Act
        DateTimeOffset date = DaylightSavingTimeEnd();

        // Assert
        date.Should().Be(expectedEndOfDst);
    }

    #region Helpers
    private static DateTime EasterSunday() => new(2025, 04, 20);

    private static DateTime StartOfThisPresentation() => new DateTime(2025, 03, 11, 08, 30, 00).AddMinutes(new Random().Next(-5, 5));

    private static DateTimeOffset DaylightSavingTimeEnd() => new(2025, 10, 26, 03, 00, 00, TimeSpan.FromHours(2));
    #endregion
}

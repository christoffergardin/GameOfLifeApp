using GameOfLifeApp.Models;

namespace GameOfLifeTests;

using FluentAssertions;
using Xunit;

public class RulesTests
{
    private readonly IGameRules _rules = new GameOfLifeRules();

    [Xunit.Theory]
    [InlineData(true, 0, false)]
    [InlineData(true, 1, false)]
    [InlineData(true, 2, true)]
    [InlineData(true, 3, true)]
    [InlineData(true, 4, false)]
    [InlineData(false, 3, true)]
    public void ShouldLive_ShouldReturnExpectedResult(bool isCurrentlyAlive, int liveNeighbors, bool expectedResult)
    {
        var result = _rules.ShouldLive(isCurrentlyAlive, liveNeighbors);
        result.Should().Be(expectedResult);
    }
}
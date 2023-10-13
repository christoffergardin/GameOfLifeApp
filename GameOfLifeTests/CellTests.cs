using FluentAssertions;
using GameOfLifeApp.Models;

namespace GameOfLifeTests;

public class CellTests
{
    [Fact]
    public void Cell_InitialState_ShouldBeSetCorrectly()
    {
        var cell = new Cell(true);
        cell.IsAlive.Should().BeTrue();
    }

    [Fact]
    public void Cell_SetAliveState_ShouldUpdateState()
    {
        var cell = new Cell(false);
        cell.SetAliveState(true);
        cell.IsAlive.Should().BeTrue();
    }
}
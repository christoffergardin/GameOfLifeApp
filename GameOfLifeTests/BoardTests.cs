namespace GameOfLifeTests;

using Xunit;
using FluentAssertions;
using GameOfLifeApp.Models;

public class BoardTests
{
    [Fact]
    public void BoardInitialization_ShouldCreateBoardWithAllDeadCells()
    {
        var board = new Board(5, 5, new GameOfLifeRules());

        board.ForEachCell((i, j) => { board.GetCell(i, j).IsAlive.Should().BeFalse(); });
    }

    [Theory]
    [InlineData(0, 1, 0)]
    [InlineData(0, 0, 1)]
    public void CountLiveNeighbors_ShouldReturnCorrectCount(int row, int col, int expectedCount)
    {
        var board = new Board(3, 3, new GameOfLifeRules());
        board.UpdateCellState(0, 1, true);

        int liveNeighbors = board.CountLiveNeighbors(row, col);
        liveNeighbors.Should().Be(expectedCount);
    }

    [Fact]
    public void AdvanceToNextGeneration_ShouldUpdateBoardState()
    {
        var board = new Board(3, 3, new GameOfLifeRules());
        board.UpdateCellState(1, 1, true);

        board.AdvanceToNextGeneration();
        board.GetCell(1, 1).IsAlive.Should().BeFalse();
    }

    [Fact]
    public void UpdateCellState_ShouldChangeCellState()
    {
        var board = new Board(3, 3, new GameOfLifeRules());

        board.UpdateCellState(1, 1, true);
        board.GetCell(1, 1).IsAlive.Should().BeTrue();
    }
}
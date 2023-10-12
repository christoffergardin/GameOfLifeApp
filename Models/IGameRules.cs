namespace GameOfLifeApp.Models;

public interface IGameRules
{
    bool ShouldLive(bool currentState, int liveNeighbors);
}
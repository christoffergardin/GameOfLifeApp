namespace GameOfLifeApp.Models;

public class GameOfLifeRules : IGameRules
{
    public bool ShouldLive(bool isCurrentlyAlive, int liveNeighbors)
    {
        if (isCurrentlyAlive)
        {
            return Survives(liveNeighbors);
        }
        else
        {
            return BecomesPopulated(liveNeighbors);
        }
    }
    
    private bool BecomesPopulated(int liveNeighbors)   
    {                                                  
        return liveNeighbors == 3;                     
    }
    
    private bool Survives(int liveNeighbors)
    {
        return !DiesBySolitude(liveNeighbors) && !DiesByOverpopulation(liveNeighbors);
    }
    
    private bool DiesByOverpopulation(int liveNeighbors)
    {
        return liveNeighbors >= 4;
    }

    private bool DiesBySolitude(int iveNeighbors)
    {
        return iveNeighbors <= 1;
    }
    
}
namespace GameOfLifeApp.Models;

public class Cell
{
    public bool IsAlive { get; private set; }
    
    public Cell(bool isAlive)
    {
        IsAlive = isAlive;
    }
    
    public void SetAliveState(bool state)
    {
        IsAlive = state;
    }
}
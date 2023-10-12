namespace GameOfLifeApp.Models;

public class Board
{
    private readonly int _rows;
    private readonly int _columns;
    private readonly Cell[,] _cellGrid;
    private readonly IGameRules _rules;

    public Board(int rows, int columns, IGameRules rules)
    {
        _rows = rows;
        _columns = columns;
        _rules = rules;
        _cellGrid = new Cell[rows, columns];
        InitializeCells();
    }

    private void InitializeCells()
    {
        ForEachCell((i, j) => _cellGrid[i, j] = new Cell(false));
    }
    
    public void AdvanceToNextGeneration()
    {
        bool[,] nextState = new bool[_rows, _columns];
        
        ForEachCell((i, j) => {
            //This is the action I pass in. 
            var liveNeighbors = CountLiveNeighbors(i, j);
            nextState[i, j] = _rules.ShouldLive(_cellGrid[i, j].IsAlive, liveNeighbors);
        });
        
        ForEachCell((i, j) => _cellGrid[i, j].SetAliveState(nextState[i, j]));
    }
    
    public void ForEachCell(Action<int, int> action)
    {
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _columns; j++)
            {
                action(i, j); //This makes the code the same for the ForEachCell, but the action can differ
                // In this way we do not need to create different methods.
            }
        }
    }
    
    public int CountLiveNeighbors(int row, int col)
    {
        int liveNeighbors = 0;
    
        for (int i = row - 1; i <= row + 1; i++)
        {
            for (int j = col - 1; j <= col + 1; j++)
            {
                if (ShouldCountAsLiveNeighbor(i, j, row, col))
                {
                    liveNeighbors++;
                } 
            }
        }

        return liveNeighbors;
    }

    private bool ShouldCountAsLiveNeighbor(int i, int j, int row, int col)
    {
        return IsWithinBounds(i, j) && !IsSameCell(i, j, row, col) && _cellGrid[i, j].IsAlive;
    }

    public Cell GetCell(int row, int column)
    {
        if (!IsWithinBounds(row, column))
        {
            throw new ArgumentOutOfRangeException($"Attempted to access cell at ({row}, {column}), which is outside the board's bounds.");
        }
        return _cellGrid[row, column];
    }
    
    private bool IsWithinBounds(int i, int j)
    {
        return i >= 0 && i < _rows && j >= 0 && j < _columns;
    }

    private bool IsSameCell(int i, int j, int row, int col)
    {
        return i == row && j == col;
    }

    public void UpdateCellState(int row, int col, bool state)
    {
        _cellGrid[row, col].SetAliveState(state);
    }
}

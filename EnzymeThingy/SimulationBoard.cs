namespace EnzymeThingy;

public class SimulationBoard
{
    public (float, float)[][] board { get; set; }
    
    public (float, float)[][] previousBoard { get; set; }
    public Bacteria specimen { get; set; }
    
    public float transferAmount { get; set; }
    
    public float transferChance { get; set; }

    public SimulationBoard((float, float)[][] board, Bacteria specimen, float transferAmount, float transferChance)
    {
        this.board = board;
        this.specimen = specimen;
        this.transferAmount = transferAmount;
        this.transferChance = transferChance;
    }


    public void InitBoard(float bacteriaConcentration, float placticConcentration)
    {
        Random r = new Random();
        previousBoard = new (float, float)[board.Length][];
        for( int i = 0; i < this.board.Length; i++)
        {
            previousBoard[i] = new (float, float)[board.Length];
            for (int j = 0; j < this.board[i].Length; j++)
            {
                board[i][j] = (placticConcentration* (1 + r.NextSingle()), 0);
                previousBoard[i][j] = (placticConcentration * (1 + r.NextSingle()), 0);
            }
        }

        int halfx = board.Length / 2;
        int halfy = board[halfx].Length / 2;
        board[halfy][halfx].Item2 = bacteriaConcentration;
    }

    public void Run(int iterations)
    {
        Random r = new Random();    
        for( int i = 0; i < this.board.Length; i++)
        {
            for (int j = 0; j < this.board[i].Length; j++)
            {
                (float, float) temp = board[i][j];
                board[i][j] = (temp.Item1 - specimen.plasticDigestionRate * temp.Item2, temp.Item2 * specimen.lifeRate);
                previousBoard[i][j] = temp;
                if(IsZeroAndAdjacentToBacteria(i,j) && r.NextSingle() < transferChance) board[i][j] = (temp.Item1, transferAmount);
            }
        }
    }

    public bool IsZeroAndAdjacentToBacteria(int x, int y)
    {
        if (board[x][y].Item2 > 0) return false;
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                int currentX = x + i;
                int currentY = y + j;
                if(currentX < 0 || currentX >= previousBoard.Length || currentY < 0 || currentY >= previousBoard[currentX].Length){continue;}
                if(previousBoard[currentX][currentY].Item2 == 0){continue;}

                return true;
            }   
        }
        return false;
    }

    public Double GetPlasticConcentration()
    {
        Double conc = 0.0;
        for( int i = 0; i < this.board.Length; i++)
        {
            for (int j = 0; j < this.board[i].Length; j++)
            {
                conc += board[i][j].Item1;
            }
        }
        return conc;
    }
}
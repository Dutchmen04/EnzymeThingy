namespace EnzymeThingy;

public class SimulationBoard
{
    public (float, float)[][] board { get; set; }
    
    public (float, float)[][] previousBoard { get; set; }
    public Bacteria specimen { get; set; }
    
    public float transferAmount { get; set; }
    
    public float transferChance { get; set; }

    private SimulationBoard((float, float)[][] board, Bacteria specimen)
    {
        this.board = board;
        this.specimen = specimen;
    }


    public void InitBoard(float concentration)
    {
        Random r = new Random();
        for( int i = 0; i < this.board.Length; i++)
        {
            for (int j = 0; j < this.board[i].Length; j++)
            {
                board[i][j] = (100*r.NextSingle(), 0);
                previousBoard[i][j] = (100*r.NextSingle(), 0);
            }
        }

        int halfx = board.Length / 2;
        int halfy = board[halfx].Length / 2;
        board[halfy][halfx].Item2 = concentration;
        board[halfy][halfx].Item2 = concentration;
    }

    public void Run(int iterations)
    {
        Random r = new Random();    
        for( int i = 0; i < this.board.Length; i++)
        {
            for (int j = 0; j < this.board[i].Length; j++)
            {
                (float, float) temp = board[i][j];
                board[i][j] = (previousBoard[i][j].Item1 - specimen.d_p * previousBoard[i][j].Item2, previousBoard[i][j].Item2 * specimen.d_r);
                previousBoard[i][j] = temp;
                if(IsZeroAndAdjacentToBacteria(i,j) && r.NextSingle() < transferChance) board[i][j].Item2 += transferAmount;
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
                if(currentX < board.Length || currentX > board.Length || currentY < board[currentX].Length || currentY > board[currentX].Length){continue;}
                if(board[currentX][currentY].Item2 == 0){continue;}

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
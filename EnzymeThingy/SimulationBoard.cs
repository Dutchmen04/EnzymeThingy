namespace EnzymeThingy;

public class SimulationBoard
{
    public (float, float)[][] board { get; set; }
    
    public (float, float)[][] previousBoard { get; set; }
    public Bacteria specimen { get; set; }

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
        for( int i = 0; i < this.board.Length; i++)
        {
            for (int j = 0; j < this.board[i].Length; j++)
            {
                (float, float) temp = board[i][j];
                board[i][j] = (previousBoard[i][j].Item1 - specimen.d_p * previousBoard[i][j].Item2, previousBoard[i][j].Item2 * specimen.d_r);
                previousBoard[i][j] = temp;
            }
        }
    }
    
}
using System.Runtime.InteropServices;

public class WordSearch
{
    public WordSearch(string grids)
    {
        char[,] MapGrid()
        {
            var grid = grids.Split('\n');

            var parallax = new char[grid.Length, grid.Max(w => w.Length)];

            for (int i = 0; i < parallax.GetLength(0); i++)
            {
                for (int j = 0; j < parallax.GetLength(1); j++)
                {
                    if (j == grid[i].Length) break;

                    parallax[i, j] = grid[i][j];
                }
            }

            return parallax;
        }

        _Grid = MapGrid();
    }
    public Dictionary<string, ((int, int), (int, int))?> Search(ReadOnlySpan<string> wordsToSearchFor)
    {
        var result = new Dictionary<string, ((int, int), (int, int))?>();

        




        return result;
    }
    readonly char[,] _Grid;
}

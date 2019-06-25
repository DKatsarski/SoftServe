namespace Crossword.Generators
{
    public interface IArrayOperator
    {
        string ExtractColFromMatrix(string[,] matrix, int row, int col);
        string GetSubStringOfTheColOfMatrix(string[,] matrix, int row, int col);
        string GetSubStringOfTheRowOfMatrix(string[,] matrix, int row, int col);
    }
}
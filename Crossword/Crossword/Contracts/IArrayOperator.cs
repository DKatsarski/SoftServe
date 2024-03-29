﻿namespace Crossword.Contracts
{
    public interface IArrayOperator
    {
        string ExtractColFromMatrix(string[,] matrix, int rowOrCol);
        string GetSubStringOfTheColOfMatrix(string[,] matrix, int row, int col);
        string GetSubStringOfTheRowOfMatrix(string[,] matrix, int row, int col);
    }
}
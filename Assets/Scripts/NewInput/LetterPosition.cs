using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterPosition
{
    private readonly int row;
    private readonly int col;

    public int Row
    {
        get
        {
            return row;
        }
    }
    public int Col
    {
        get
        {
            return col;
        }
    }

    public LetterPosition(int row, int column)
    {
        this.row = column;
        this.col = row;
    }
}

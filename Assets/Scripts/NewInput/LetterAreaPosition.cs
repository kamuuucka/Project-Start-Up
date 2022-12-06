using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterAreaPosition
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

    public LetterAreaPosition(int row, int column)
    {
        this.row = column;
        this.col = row;
    }
}


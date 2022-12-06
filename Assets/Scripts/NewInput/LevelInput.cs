using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum Direction { Sw = 0, W, Nw, N, Ne }

public class LevelInput : MonoBehaviour
{
    public GameObject letterPrefab;
    public LettersAreaData areaData;
    private string[] words = { "LOAF","BOAR", "POOR", "OR", "LOAD", "LOVE" };
    private char[,] grid;
    private readonly System.Random rnd = new System.Random();

    public char[,] Grid
    {
        get
        {
            return grid;
        }
    }

    //Count how many characters each word has
    private int CountWordsCharacters(string[] array)
    {
        int count = 0;
        foreach(string word in array)
        {
            foreach (char character in word)
            {
                count++;
            }
        }
        Debug.Log("All the characters in list: (18)" + count);
        return count;
    }

    //Search for the longest word (as it should be the first one to put into the puzzle)
    //Can't be longer than 7!!!
    private string LongestWord(string[] array)
    {
        string longestWord = "";
        foreach (string word in array)
        {
            if(word.Length > longestWord.Length)
            {
                longestWord = word;
            }
        }
        return longestWord;
    }

    private int SetGridSize(int charsInWords, int longestWord)
    {
        int sizeGrid = longestWord * longestWord;
        int totalElementsGrid = charsInWords * 3;
        int totalElementsGridSquare = (int)Mathf.Sqrt(totalElementsGrid);

        while (Mathf.Sqrt(sizeGrid) != totalElementsGridSquare + 1)
        {
            sizeGrid++;
        }

        int numRowCols = (int)Mathf.Sqrt(sizeGrid);
        return numRowCols;
    }
    private void Start()
    {
        int howManyCharsInWords = CountWordsCharacters(words);
        int longestWordLength = LongestWord(words).Length;
        int gridRowsAndCols = SetGridSize(howManyCharsInWords, longestWordLength);
        grid = new char[7, 7];

        PopulateGridWords(words, grid);
        PopulateEmptyElements(grid);

        PrintGameGrid(grid);
    }

    private void PrintGameGrid(char[,] matrixToPrint)
    {
        int numRows = matrixToPrint.GetLength(0);
        int numCols = matrixToPrint.GetLength(1);
        int letterXChange = areaData.GetStartX();
        int letterZChange = areaData.GetStartZ();

        for (int counterRows = 0; counterRows < numRows; counterRows++)
        {
            for (int counterCols = 0; counterCols < numCols; counterCols++)
            {
                // print Grid element
                Debug.Log(matrixToPrint[counterRows, counterCols]);
                Vector3 spawnPoint = new Vector3(letterXChange, 0.55f, letterZChange);
                letterPrefab.name = matrixToPrint[counterRows, counterCols].ToString();
                GameObject letter = Instantiate(letterPrefab, spawnPoint, Quaternion.identity);
                letter.name = letter.name.Replace("(Clone)", "").Trim();
                letter.transform.parent = areaData.transform;

                letterXChange += areaData.GetSpaceBetweenColumns();
            }
            letterZChange -= areaData.GetSpaceBetweenRows();
            letterXChange = areaData.GetStartX();
        }
    }

    private void PopulateEmptyElements(char[,] grid)
    {
        for (int counterRow = 0; counterRow < grid.GetLength(0); counterRow++)
        {
            for (int counterCol = 0; counterCol < grid.GetLength(1); counterCol++)
            {
                if (grid[counterRow, counterCol] == '\0')
                {
                    grid[counterRow, counterCol] = (char)rnd.Next(65, 91);
                }
            }
        }
    }

    private void PopulateGridWords(string[] words, char[,] grid)
    {
        bool wordPlaced = false;
        int numberWordsToPlace = CountElements(words);
        while (!wordPlaced)
        {
            for(int wordCurrent = 0; wordCurrent < numberWordsToPlace; wordCurrent++)
            {
                LetterAreaPosition areaPosition = new LetterAreaPosition(rnd.Next(0, grid.GetLength(0)), rnd.Next(0, grid.GetLength(1)));
                if (PlaceWordInGrid(areaPosition, words[wordCurrent], grid))
                {
                    wordPlaced = true;
                }
            }
            
        }
    }
    private int CountElements(string[] array)
    {
        int count = 0;
        foreach (string word in array)
        {
            count++;
        }
        return count;
    }

    private bool PlaceWordInGrid(LetterAreaPosition pos, string word, char[,] grid)
    {
        int x = pos.Row;
        int z = pos.Col;

        int[] directions = new int[5] { 9, 9, 9, 9, 9 };
        int direction = 9;
        bool haveOptions = false;

        for(int counter = 0; counter < word.Length; counter++)
        {
            if(grid[x,z] == '\0' || grid[x,z] == word[0])
            {
                if (SpaceSw(word, pos, grid))
                {
                    directions[0] = 1;
                    haveOptions = true;
                }
                if (SpaceW(word, pos, grid))
                {
                    directions[1] = 2;
                    haveOptions = true;
                }
                if (SpaceNw(word, pos, grid))
                {
                    directions[2] = 3;
                    haveOptions = true;
                }
                if (SpaceN(word, pos, grid))
                {
                    directions[3] = 4;
                    haveOptions = true;
                }
                if (SpaceNe(word, pos, grid)){
                    directions[4] = 5;
                    haveOptions = true;
                }

                if (haveOptions)
                {
                    while (direction == 9)
                    {
                        direction = directions[rnd.Next(0, directions.Length - 1)];
                    }

                    switch (direction)
                    {
                        case 1:
                            PlaceWordSw(word, pos, grid);
                            break;
                        case 2:
                            PlaceWordW(word, pos, grid);
                            break;
                        case 3:
                            PlaceWordNw(word, pos, grid);
                            break;
                        case 4:
                            PlaceWordN(word, pos, grid);
                            break;
                        case 5:
                            PlaceWordNe(word, pos, grid);
                            break;
                    }
                    return true;
                }
            }
        }
        return false;
    }

    private bool SpaceW(string word, LetterAreaPosition pos, char[,] grid)
    {
        if ((grid.GetLength(0)) - pos.Col >= word.Length)
        {
            // iterate right in row, checking each successive element empty or same as current char
            for (int counter = 0; counter < word.Length; counter++)
            {
                if (grid[pos.Row, pos.Col + counter] != '\0' && grid[pos.Row, pos.Col + counter] != word[counter])
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }

    private bool SpaceN(string word, LetterAreaPosition pos, char[,] grid)
    {
        if ((grid.GetLength(0)) - pos.Row >= word.Length)
        {
            // iterate right in row, checking each successive element empty or same as current char
            for (int counter = 0; counter < word.Length; counter++)
            {
                if (grid[pos.Row + counter, pos.Col] != '\0' && grid[pos.Row + counter, pos.Col] != word[counter])
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }

    private bool SpaceSw(string word, LetterAreaPosition pos, char[,] grid)
    {
        if ((grid.GetLength(0)) - pos.Col >= word.Length && // if space right
            (pos.Row >= word.Length - 1)) // if space up
        {
            // iterate right in row, checking each successive element empty or same as current char
            for (int counter = 0; counter < word.Length; counter++)
            {
                if (grid[pos.Row - counter, pos.Col + counter] != '\0' && grid[pos.Row - counter, pos.Col + counter] != word[counter])
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }

    private bool SpaceNw(string word, LetterAreaPosition pos, char[,] grid)
    {
        if ((grid.GetLength(0)) - pos.Col >= word.Length && // if space right
            (grid.GetLength(1)) - pos.Row >= word.Length) // if space down
        {
            // iterate right in row, checking each successive element empty or same as current char
            for (int counter = 0; counter < word.Length; counter++)
            {
                if (grid[pos.Row + counter, pos.Col + counter] != '\0' && grid[pos.Row + counter, pos.Col + counter] != word[counter])
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }

    private bool SpaceNe(string word, LetterAreaPosition pos, char[,] grid)
    {
        if ((grid.GetLength(0)) - pos.Row >= word.Length && // if space down
            pos.Col >= word.Length - 1) // if space left
        {
            // iterate right in row, checking each successive element empty or same as current char
            for (int counter = 0; counter < word.Length; counter++)
            {
                if (grid[pos.Row + counter, pos.Col - counter] != '\0' && grid[pos.Row + counter, pos.Col - counter] != word[counter])
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }

    private void PlaceWordW(string word, LetterAreaPosition pos, char[,] grid)
    {
        for (int counter = 0; counter < word.Length; counter++)
        {
            grid[pos.Row, pos.Col + counter] = word[counter];
        }
    } // place word left -> right
   
    private void PlaceWordN(string word, LetterAreaPosition pos, char[,] grid)
    {
        for (int counter = 0; counter < word.Length; counter++)
        {
            grid[pos.Row + counter, pos.Col] = word[counter];
        }
    } // place word up -> down
    
    private void PlaceWordSw(string word, LetterAreaPosition pos, char[,] grid)
    {
        for (int counter = 0; counter < word.Length; counter++)
        {
            grid[pos.Row - counter, pos.Col + counter] = word[counter];
        }
    } // place word diagonal left -> up right
    private void PlaceWordNw(string word, LetterAreaPosition pos, char[,] grid)
    {
        for (int counter = 0; counter < word.Length; counter++)
        {
            grid[pos.Row + counter, pos.Col + counter] = word[counter];
        }
    } // place word diagonal left -> down right
    private void PlaceWordNe(string word, LetterAreaPosition pos, char[,] grid)
    {
        for (int counter = 0; counter < word.Length; counter++)
        {
            grid[pos.Row + counter, pos.Col - counter] = word[counter];
        }
    } // place word diagonal left -> down left

}

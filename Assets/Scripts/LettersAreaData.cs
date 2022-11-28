using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LettersAreaData : MonoBehaviour
{
    private System.Random rnd = new System.Random();
    public char[,] letterArray = new char[7,7]
    {
         { '0', 'B', 'C', 'D', 'E', 'F', 'O' },
         { 'A', 'B', 'C', 'D', 'E', 'F', 'G' },
         { 'A', '0', 'C', 'D', 'E', 'F', 'G' },
         { 'A', 'B', 'C', 'D', 'E', 'F', 'G' },
         { 'A', 'B', 'C', 'D', '0', 'F', 'G' },
         { 'A', 'B', 'C', 'D', 'E', 'F', '0' },
         { 'A', 'B', 'C', 'D', 'E', 'F', 'X' }
    };

    private char randomLetter;
    private int childrenIndex = 0;
    private int rows = 7;
    private int columns = 7;
    private float x = -8.0f;
    private float z = 8.0f;
    private void Start()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (letterArray[i,j] == '0')
                {
                    Debug.Log("Found the random letter");
                    randomLetter = (char)rnd.Next(65, 91);
                    letterArray[i, j] = randomLetter;
                }
                allChildren[childrenIndex].name = letterArray[i, j].ToString();
                Debug.Log(letterArray[i, j]);
            }
        }
    }
    private void Update()
    {

    }
}

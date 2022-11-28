using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LettersAreaData : MonoBehaviour
{
    public GameObject letterPrefab;
    private System.Random rnd = new System.Random();
    public char[,] letterArray = new char[3,7]
    {
         { '0', 'B', 'C', 'D', 'E', 'F', 'O' },
         { 'A', 'B', 'C', 'D', 'E', 'F', 'G' },
         { 'A', '0', 'C', 'D', 'E', 'F', 'G' }
         //{ 'A', 'B', 'C', 'D', 'E', 'F', 'G' },
         //{ 'A', 'B', 'C', 'D', '0', 'F', 'G' },
         //{ 'A', 'B', 'C', 'D', 'E', 'F', '0' },
         //{ 'A', 'B', 'C', 'D', 'E', 'F', 'X' }
    };

    private char randomLetter;
    private int childrenIndex = 0;
    private int rows = 3;
    private int columns = 7;
    private float x = -7.8f;
    private float z = -7.8f;
    private void Start()
    {
        //Transform[] allChildren = GetComponentsInChildren<Transform>();
        for (int i = 0; i < rows; i++)
        {
            if (i == 3)
            {
                x = 0.0f;
            }
            
            for (int j = 0; j < columns; j++)
            {
                if (letterArray[i,j] == '0')
                {
                    Debug.Log("Found the random letter");
                    randomLetter = (char)rnd.Next(65, 91);
                    letterArray[i, j] = randomLetter;
                }
                if (j == 3)
                {
                    x = 0.0f;
                }
                //allChildren[childrenIndex].name = letterArray[i, j].ToString();
                Debug.Log("Coords: " + x + " : " + z);
                Vector3 spawnPoint = new Vector3(x, 0.55f, z);
                letterPrefab.name = letterArray[i, j].ToString();
                GameObject letter = Instantiate(letterPrefab, spawnPoint, Quaternion.identity);
                letter.name = letter.name.Replace("(Clone)", "").Trim();
                Debug.Log(letterArray[i, j]);

                x += 2.6f;
            }

            z += 2.6f;
            x = -7.8f;
        }
    }
    private void Update()
    {

    }
}

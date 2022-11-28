using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LettersAreaData : MonoBehaviour
{
    public GameObject letterPrefab;
    private System.Random rnd = new System.Random();
    public char[,] letterArray = new char[3, 7]
    {
         { '0', 'B', 'C', 'D', 'E', 'F', 'O' },
         { 'A', 'B', 'C', 'D', 'E', 'F', 'G' },
         { 'A', '0', 'C', 'D', 'E', 'F', 'G' }
         //{ 'A', 'B', 'C', 'D', 'E', 'F', 'G' },
         //{ 'A', 'B', 'C', 'D', '0', 'F', 'G' },
         //{ 'A', 'B', 'C', 'D', 'E', 'F', '0' },
         //{ 'A', 'B', 'C', 'D', 'E', 'F', 'X' }
    };
    public char[,] letterArray2 = new char[3, 7]
    {
         { '0', 'B', 'Y', '0', 'E', 'F', 'O' },
         { 'A', 'B', '0', 'D', 'E', '0', 'G' },
         { 'A', '0', 'C', 'D', 'W', 'F', 'G' }
         //{ 'A', 'B', 'C', 'D', 'E', 'F', 'G' },
         //{ 'A', 'B', 'C', 'D', '0', 'F', 'G' },
         //{ 'A', 'B', 'C', 'D', 'E', 'F', '0' },
         //{ 'A', 'B', 'C', 'D', 'E', 'F', 'X' }
    };
    public char[,] letterArray3 = new char[3, 7]
    {
         { '0', 'B', 'C', '0', 'E', 'F', 'O' },
         { 'K', 'A', 'M', 'A', 'E', '0', 'G' },
         { '0', '0', '0', '0', '0', '0', '0' }
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
    private int levelNumber = 1;
    private void Start()
    {
        loadLetters(levelSwitch(levelNumber));
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            KillTheYounglings();
            Debug.Log(levelNumber);
            levelNumber++;
            loadLetters(levelSwitch(levelNumber));
        }
    }

    private void loadLetters(char[,] tempArray)
    {
        x = -7.8f;
        z = -7.8f;
        for (int i = 0; i < rows; i++)
        {
            if (i == 3)
            {
                x = 0.0f;
            }

            for (int j = 0; j < columns; j++)
            {
                if (tempArray[i, j] == '0')
                {
                    Debug.Log("Found the random letter");
                    randomLetter = (char)rnd.Next(65, 91);
                    tempArray[i, j] = randomLetter;
                }
                if (j == 3)
                {
                    x = 0.0f;
                }
                //Debug.Log("Coords: " + x + " : " + z);
                Vector3 spawnPoint = new Vector3(x, 0.55f, z);
                letterPrefab.name = tempArray[i, j].ToString();
                GameObject letter = Instantiate(letterPrefab, spawnPoint, Quaternion.identity);
                letter.name = letter.name.Replace("(Clone)", "").Trim();
                letter.transform.parent = this.transform;
                //Debug.Log(letterArray[i, j]);
                x += 2.6f;
            }
            z += 2.6f;
            x = -7.8f;
        }
    }

    private char[,] levelSwitch(int number)
    {
        switch (number)
        {
            case 1:
                Debug.Log("Level 1");
                return letterArray;
            case 2:
                Debug.Log("Level 2");
                return letterArray2;
            case 3:
                Debug.Log("Level 3");
                return letterArray3;
            default:
                Debug.Log("Level 1");
                return letterArray;
        }
    }

    private void KillTheYounglings()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}

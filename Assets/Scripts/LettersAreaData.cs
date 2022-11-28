using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Array2DEditor;

public class LettersAreaData : MonoBehaviour
{
    public GameObject letterPrefab;
    private System.Random rnd = new System.Random();


    //Arays creating the letter pattern for the level
    public Array2DString testArray;
    public Array2DString letterArray;
    public Array2DString letterArray2;
    public Array2DString letterArray3;

    //The rows and columns have to be the same as the arrayLevel arrays [rows, columns]
    private int rows = 7;
    private int columns = 7;

    //Starting position for the letters
    public float letterX = -7.8f;
    public float letterZ = -7.8f;
    //How big the space between letters has to be
    public float spaceLetters = 2.6f;

    private char randomLetter;
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

    private void loadLetters(Array2DString testArray)
    {
        letterX = -7.8f;
        letterZ = -7.8f;

        for (int i = 0; i < rows; i++)
        {
            //Because we are using float, the 0 is hard to reach so we are helping the loops :)
            if (i == 3)
            {
                letterZ = 0.0f;
            }

            for (int j = 0; j < columns; j++)
            {
                //Because we are using float, the 0 is hard to reach so we are helping the loops :)
                if (j == 3)
                {
                    letterX = 0.0f;
                }

                if (testArray.GetCell(i,j).Equals("0") || testArray.GetCell(i,j).Equals(""))
                {
                    //Debug.Log("Found the random letter");
                    randomLetter = (char)rnd.Next(65, 91);
                    testArray.SetCell(i, j, randomLetter.ToString());
                }
                
                //Debug.Log("Coords: " + x + " : " + z);
                Vector3 spawnPoint = new Vector3(letterX, 0.55f, letterZ);
                letterPrefab.name = testArray.GetCell(i, j);//.ToString();
                GameObject letter = Instantiate(letterPrefab, spawnPoint, Quaternion.identity);
                letter.name = letter.name.Replace("(Clone)", "").Trim();
                letter.transform.parent = this.transform;
                //Debug.Log(letterArray[i, j]);
                letterX += 2.6f;
            }
            letterZ += 2.6f;
            letterX = -7.8f;
        }
    }

    private Array2DString levelSwitch(int number)
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

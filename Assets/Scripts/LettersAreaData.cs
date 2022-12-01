using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Array2DEditor;

public class LettersAreaData : MonoBehaviour
{
    public GameObject letterPrefab;
    

    

    //Arays of letters (visible in the inspector)
    public Array2DString testArray;
    public Array2DString letterArray;
    public Array2DString letterArray2;
    public Array2DString letterArray3;
    public Array2DString letterArray4;
    public Array2DString letterArray5;

    //Starting position for the letters
    public float letterX = -7.8f;
    public float letterZ = -7.8f;
    
    //How big the space between letters has to be
    public float spaceLettersRows = 2.6f;
    public float spaceLettersColumns = 2.6f;

    private List<Array2DString> listOfLevels = new();
    private float letterXChange;
    private float letterZChange;
    private char randomLetter;
    private int levelNumber = 0;
    private bool changeLevel = false;
    private bool reloadLevel = false;

    //The rows and columns have to be the same as the arrayLevel arrays [rows, columns]
    private readonly int rows = 7;
    private readonly int columns = 7;
    private readonly System.Random rnd = new System.Random();

    private void Start()
    {
        letterXChange = letterX;
        letterZChange = letterZ;
        AddToList(letterArray, letterArray2, letterArray3, letterArray4, letterArray5);
        LoadLetters(listOfLevels[levelNumber]);
    }
    private void Update()
    {
        //Debug.Log(changeLevel);
        //By pressing Enter, you reset the board - to be changed later
        if (changeLevel || Input.GetKeyUp(KeyCode.R))
        {
            KillTheYounglings();
            //Debug.Log(levelNumber);
            levelNumber++;
            if (levelNumber > 4)
            {
                levelNumber = 4;
            }
            LoadLetters(listOfLevels[levelNumber]);
            SetLevelChange(false);
            Debug.Log(changeLevel);
        } else if (reloadLevel)
        {
            KillTheYounglings();
            LoadLetters(listOfLevels[levelNumber]);
            SetLevelReload(false);
        }
    }

    /// <summary>
    /// Code responsible for loading letter objects with desired names (as written in the inspector)
    /// </summary>
    /// <param name="array"></param>
    private void LoadLetters(Array2DString array)
    {
        letterXChange = letterX;
        letterZChange = letterZ;

        for (int i = 0; i < rows; i++)
        {
            //Because we are using float, the 0 is hard to reach so we are helping the loops :)
            if (i == 3) letterZChange = 0.0f;
            
            for (int j = 0; j < columns; j++)
            {
                //Because we are using float, the 0 is hard to reach so we are helping the loops :)
                if (j == 3) letterXChange = 0.0f;
                
                //Load random letters if see those values
                if (array.GetCell(j,i).Equals("0") || array.GetCell(j,i).Equals(""))
                {
                    //Debug.Log("Found the random letter");
                    //Load random letter using ASCII code, it needs to be string later, because we have an array of strings
                    randomLetter = (char)rnd.Next(65, 91);
                    array.SetCell(j, i, randomLetter.ToString());
                }

                //Set the spawnpoint for the objects, set its name, create it and set the parent (usefull for deleting children later)
                Vector3 spawnPoint = new Vector3(letterXChange, 0.55f, letterZChange);
                letterPrefab.name = array.GetCell(j, i);
                GameObject letter = Instantiate(letterPrefab, spawnPoint, Quaternion.identity);
                letter.name = letter.name.Replace("(Clone)", "").Trim();
                letter.transform.parent = this.transform;
                
                letterXChange += spaceLettersColumns;
            }
            letterZChange -= spaceLettersRows;
            letterXChange = letterX;
        }
    }

    private void KillTheYounglings()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    void AddToList(params Array2DString[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            listOfLevels.Add(list[i]);
        }
    }

    public int GetLevelNumber()
    {
        return levelNumber;
    }

    public void SetLevelChange(bool levelStatus)
    {
        changeLevel = levelStatus;
    }

    public bool GetLevelChange()
    {
        return changeLevel;
    }

    public void SetLevelReload(bool levelStatus)
    {
        reloadLevel = levelStatus;
    }
}

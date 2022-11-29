using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Array2DEditor;

public class LettersAreaData : MonoBehaviour
{
    public GameObject letterPrefab;
    private System.Random rnd = new System.Random();

    private List<Array2DString> listOfLevels = new List<Array2DString>();

    //Arays of letters (visible in the inspector)
    public Array2DString testArray;
    public Array2DString letterArray;
    public Array2DString letterArray2;
    public Array2DString letterArray3;
    public Array2DString letterArray4;
    public Array2DString letterArray5;

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
        AddToList(letterArray, letterArray2, letterArray3, letterArray4, letterArray5);
        loadLetters(listOfLevels[levelNumber]);
    }
    private void Update()
    {
        //By pressing Enter, you reset the board - to be changed later
        if (Input.GetKeyUp(KeyCode.Return))
        {
            KillTheYounglings();
            Debug.Log(levelNumber);
            levelNumber++;
            if (levelNumber > 4)
            {
                levelNumber = 4;
            }
            loadLetters(listOfLevels[levelNumber]);
        }
    }

    /// <summary>
    /// Code responsible for loading letter objects with desired names (as written in the inspector)
    /// </summary>
    /// <param name="array"></param>
    private void loadLetters(Array2DString array)
    {
        letterX = -7.8f;
        letterZ = -7.8f;

        for (int i = 0; i < rows; i++)
        {
            //Because we are using float, the 0 is hard to reach so we are helping the loops :)
            if (i == 3) letterZ = 0.0f;
            
            for (int j = 0; j < columns; j++)
            {
                //Because we are using float, the 0 is hard to reach so we are helping the loops :)
                if (j == 3) letterX = 0.0f;
                
                //Load random letters if see those values
                if (array.GetCell(i,j).Equals("0") || array.GetCell(i,j).Equals(""))
                {
                    //Debug.Log("Found the random letter");
                    //Load random letter using ASCII code, it needs to be string later, because we have an array of strings
                    randomLetter = (char)rnd.Next(65, 91);
                    array.SetCell(i, j, randomLetter.ToString());
                }
                
                //Debug.Log("Coords: " + x + " : " + z);

                //Set the spawnpoint for the objects, set its name, create it and set the parent (usefull for deleting children later)
                Vector3 spawnPoint = new Vector3(letterX, 0.55f, letterZ);
                letterPrefab.name = array.GetCell(i, j);
                GameObject letter = Instantiate(letterPrefab, spawnPoint, Quaternion.identity);
                letter.name = letter.name.Replace("(Clone)", "").Trim();
                letter.transform.parent = this.transform;
                
                letterX += 2.6f;
            }
            letterZ += 2.6f;
            letterX = -7.8f;
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
}
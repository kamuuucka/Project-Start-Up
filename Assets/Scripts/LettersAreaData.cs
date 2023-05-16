using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Array2DEditor;

public class LettersAreaData : MonoBehaviour
{
    public List<LetterFieldSO> questions = new List<LetterFieldSO>();

    //Starting position for the letters
    public int letterX = -7;
    public int letterZ = -7;
    
    //How big the space between letters has to be
    public int spaceLettersRows = 2;
    public int spaceLettersColumns = 2;

    private int levelNumber = 0;
    private bool changeLevel = false;
    private bool reloadLevel = false;
    private bool lastLevel = false;

    private void Start()
    {
        questions[levelNumber].GenerateLevel(this);
    }
    private void Update()
    {
        //By pressing Enter, you reset the board - to be changed later
        if (changeLevel || Input.GetKeyUp(KeyCode.R))
        {
            KillTheYounglings();
            levelNumber++;
            Debug.Log(levelNumber + "  LIST SIZE: " + questions.Count);
            if (levelNumber == questions.Count)
            {
                Debug.Log("No more level for you");
                lastLevel = true;
                SetLevelChange(false);
            }
            else
            {
                questions[levelNumber].GenerateLevel(this);
                SetLevelChange(false);
            }
        } else if (reloadLevel)
        {
            KillTheYounglings();
            questions[levelNumber].GenerateLevel(this);
            SetLevelReload(false);
        }
    }

    public bool CorrectWord(string word)
    {
        if (word.Equals(questions[levelNumber].correctAnswer))
        {
            return true;
        }
        else return false;
    }

    public bool GetLastLevel()
    {
        return lastLevel;
    }

    private void KillTheYounglings()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
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

    public int GetStartX()
    {
        return letterX;
    }

    public int GetStartZ()
    {
        return letterZ;
    }

    public int GetSpaceBetweenColumns()
    {
        return spaceLettersColumns;
    }

    public int GetSpaceBetweenRows()
    {
        return spaceLettersRows;
    }

    public string GetCorrectAnswer()
    {
        return questions[levelNumber].correctAnswer;
    }
}

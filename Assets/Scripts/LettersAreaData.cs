using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manager of whole letters area, responsible for loading the levels and positioning
/// </summary>
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
        //You can go to another level by pressing R (DEBUG)
        if (changeLevel)// || Input.GetKeyUp(KeyCode.R))
        {
            KillTheYounglings();
            levelNumber++;

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

    /// <summary>
    /// Check if this word is a correct word compared to the answer
    /// </summary>
    /// <param name="word"></param>
    /// <returns> bool </returns>
    public bool CorrectWord(string word)
    {
        if (word.Equals(questions[levelNumber].correctAnswer)) return true;
        else return false;
    }

    /// <summary>
    /// Check if this level is the last one
    /// </summary>
    /// <returns> bool </returns>
    public bool GetLastLevel()
    {
        return lastLevel;
    }

    /// <summary>
    /// Destroy all children to reload the level
    /// </summary>
    private void KillTheYounglings()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    /// <summary>
    /// Get the number of level used to load right image in the background
    /// </summary>
    /// <returns></returns>
    public int GetLevelNumber()
    {
        return levelNumber;
    }

    /// <summary>
    /// Set the status of changeLevel
    /// </summary>
    /// <param name="levelStatus"></param>
    public void SetLevelChange(bool levelStatus)
    {
        changeLevel = levelStatus;
    }

    /// <summary>
    /// Set level reload
    /// </summary>
    /// <param name="levelStatus"></param>
    public void SetLevelReload(bool levelStatus)
    {
        reloadLevel = levelStatus;
    }

    /// <summary>
    /// Get the start position X
    /// </summary>
    /// <returns></returns>
    public int GetStartX()
    {
        return letterX;
    }

    /// <summary>
    /// Get the start position Y
    /// </summary>
    /// <returns></returns>
    public int GetStartZ()
    {
        return letterZ;
    }

    /// <summary>
    /// Get space between columns
    /// </summary>
    /// <returns></returns>
    public int GetSpaceBetweenColumns()
    {
        return spaceLettersColumns;
    }

    /// <summary>
    /// Get space between columns
    /// </summary>
    /// <returns></returns>
    public int GetSpaceBetweenRows()
    {
        return spaceLettersRows;
    }
}

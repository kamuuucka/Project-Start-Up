using System.Collections.Generic;
using UnityEngine;

public class LetterManager : MonoBehaviour
{
    public GameObject[] letterPlacement = new GameObject[9];
    public List<string> correctAnswers = new List<string>();
    
    private List<GameObject> word = new List<GameObject>();
    private LettersAreaData levelData;

    private int amount = 0;
    private int answerNumber = 0;
    private string wordToCheck = "";

    void Awake()
    {
        levelData = GetComponent<LettersAreaData>();   
    }

    private void Update()
    {

        // Debug.Log(levelData.GetLevelNumber());
        //Debug.Log(wordToCheck);
        Debug.Log("IIIIIII: " + answerNumber);
            Debug.Log("LEVEL NUMBER: " + levelData.GetLevelNumber());
            Debug.Log("ANSWER IS: " + correctAnswers[answerNumber]);
            if (wordToCheck.Equals(correctAnswers[answerNumber]))
            {
                Debug.Log("DONE");
                if (Input.GetKeyUp(KeyCode.Return))
                {
                    wordToCheck = "";
                    Debug.Log("WORD COLLECTED: " +wordToCheck);
                    levelData.SetLevelChange(true);
                    Debug.Log(levelData.GetLevelChange());
                    amount = 0;
                answerNumber++;
                }
            }
            else
            {
                Debug.Log("NOPE");
                if (Input.GetKeyUp(KeyCode.Return))
                {
                    LevelReload();
                }
            }
        
    }

    public void AddToList(GameObject obj)
    {
        word.Add(obj);
        wordToCheck += obj.name;
    }

    public int GetAmount()
    {
        return amount;
    }

    public void SetAmount()
    {
        amount++;
    }

    public void LevelReload()
    {
        levelData.SetLevelReload(true);
        amount = 0;
        wordToCheck = "";
    }
}

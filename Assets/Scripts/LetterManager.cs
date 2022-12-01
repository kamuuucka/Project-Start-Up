using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LetterManager : MonoBehaviour
{
    public GameObject[] letterPlacement = new GameObject[9];
    public List<string> correctAnswers = new List<string>();

    private List<GameObject> word = new List<GameObject>();
    private LettersAreaData levelData;

    private int amount = 0;
    private int answerNumber = 0;
    private string wordToCheck = "";

    //new
    public GameObject Correct;
    public GameObject Wrong;

    void Awake()
    {
        levelData = GetComponent<LettersAreaData>();         
    }

    private void Update()
    {
        if (wordToCheck.Equals(correctAnswers[answerNumber]))
        {
            

            if (Input.GetKeyUp(KeyCode.Return))
            {
                if(answerNumber == 4)
                {
                    SceneManager.LoadScene(0);
                }
                wordToCheck = "";
                levelData.SetLevelChange(true);
                amount = 0;
                answerNumber++;
                //new
                Correct.SetActive(true);
                Correct.SetActive(false);
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                Wrong.SetActive(true);
                Wrong.SetActive(false);
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
        Correct.SetActive(false);
        levelData.SetLevelReload(true);
        amount = 0;
        wordToCheck = "";
    }
}

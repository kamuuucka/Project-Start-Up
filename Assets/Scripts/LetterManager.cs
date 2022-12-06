using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LetterManager : MonoBehaviour
{ 
    [SerializeField] private Timer timer;

    public GameObject[] letterPlacement = new GameObject[9];

    private List<GameObject> word = new List<GameObject>();
    private LettersAreaData levelData;

    private int amount = 0;
    private int answerNumber = 0;
    private string wordToCheck = "";
    private bool levelDone = false;
    private bool animationPlaying = false;

    //new
    public GameObject Correct;
    public GameObject Wrong;

    void Awake()
    {
        timer.SetBool(false);
        levelData = GetComponent<LettersAreaData>();
    }

    private void Update()
    {
        //Debug.Log("LAST LEVEL: " + levelData.GetLastLevel());
        if (levelData.GetLastLevel())
        {
            timer.SetBool(true);
            //Debug.Log(timer.GetTime());
            SceneManager.LoadScene(3);
        }
        else if (levelData.CorrectWord(wordToCheck))
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                answerNumber++;
                levelDone = true;
                animationPlaying = true;
                //Debug.Log(animationPlaying);
                Invoke("LoadNextLevel", 2f);
                //New
                Correct.SetActive(true);
                Correct.SetActive(false);
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                LevelReload();
                //levelDone = false;
                //New
                Wrong.SetActive(true);
                Wrong.SetActive(false);
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

    public int GetAnswerNumber()
    {
        return answerNumber;
    }

    public bool GetLevelDone()
    {
        return levelDone;
    }

    public void SetLevelDone(bool value)
    {
        levelDone = value;
    }

    public void SetAnimationPlaying(bool value)
    {
        animationPlaying = value;
        Debug.Log(animationPlaying);
    }

    private void LoadNextLevel()
    {
        Debug.Log(animationPlaying);
        wordToCheck = "";
        levelData.SetLevelChange(true);
        amount = 0;
        animationPlaying = false;
    }
}

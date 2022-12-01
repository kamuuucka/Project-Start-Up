using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LetterManager : MonoBehaviour
{

    [SerializeField] private Timer timer;

    public GameObject[] letterPlacement = new GameObject[9];
    public List<string> correctAnswers = new List<string>();

    private List<GameObject> word = new List<GameObject>();
    private LettersAreaData levelData;

    private int amount = 0;
    private int answerNumber = 0;
    private string wordToCheck = "";

    void Awake()
    {
        timer.SetBool(false);
        levelData = GetComponent<LettersAreaData>();
    }

    private void Update()
    {
        Debug.Log("LAST LEVEL: " + levelData.GetLastLevel());
        if (levelData.GetLastLevel())
        {
            timer.SetBool(true);
            Debug.Log(timer.GetTime());
            SceneManager.LoadScene(3);
        }
        else if (levelData.CorrectWord(wordToCheck))
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                
                wordToCheck = "";
                levelData.SetLevelChange(true);
                amount = 0;
            }
        }
        else
        {
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

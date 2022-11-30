using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using Array2DEditor;

public class LetterManager : MonoBehaviour
{
    public GameObject[] letterPlacement = new GameObject[9];
    public List<string> correctAnswers = new List<string>();
    private List<Array2DString> levels;
    
    private List<GameObject> word = new List<GameObject>();
    private LettersAreaData levelData;

    public int placeSelector = 0;
    private int amount = 0;
    private string wordToCheck = "";

    void Awake()
    {
        levelData = GetComponent<LettersAreaData>();
        
    }

    private void Update()
    {
        for (int i = 0; i <= levelData.getLevelNumber(); i++)
        {
            if (wordToCheck.Equals(correctAnswers[i]))
            {
                Debug.Log("DONE");
                wordToCheck = "";
            }
            else
            {
                Debug.Log("NOPE");
            }
        }
    }

    public void AddToList(GameObject obj)
    {
        word.Add(obj);
        wordToCheck += obj.name;
    }

    public int getAmount()
    {
        return amount;
    }

    public void SetAmount()
    {
        amount++;
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manager for the whole letters. Checking the correct word, reloading the level and checking the timer
/// </summary>
public class LetterManager : MonoBehaviour
{
    public GameObject[] letterPlacement = new GameObject[9];
    [SerializeField]
    private Timer timer;

    public GameObject correctSound;
    public GameObject wrongSound;

    private LettersAreaData levelData;

    private int amountOfLetterInWord = 0;
    private int answerNumber = 0;
    private string wordToCheck = "";
    private bool levelDone = false;

    void Awake()
    {
        timer.SetBool(false);
        levelData = GetComponent<LettersAreaData>();
    }

    private void Update()
    {
        //If it's the last level, go to the end scene
        if (levelData.GetLastLevel())
        {
            timer.SetBool(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        else if (Input.GetKeyUp(KeyCode.Return))
        {
            //If the word is correct, go to the next level
            if (levelData.CorrectWord(wordToCheck))
            {
                answerNumber++;
                levelDone = true;
                //Wait until the animation is done, then load the next level
                Invoke(nameof(LoadNextLevel), 1.5f);

                //Play the correct sounds
                correctSound.SetActive(true);
                correctSound.SetActive(false);

            }
            //if the word is not correct, reload the scene
            else
            {
                LevelReload();

                //Play the correct sounds
                wrongSound.SetActive(true);
                wrongSound.SetActive(false);

            }
        }
    }

    /// <summary>
    /// Adding letters to the word
    /// </summary>
    /// <param name="name"></param>
    public void AddToList(string name)
    {
        wordToCheck += name;
        amountOfLetterInWord++;
    }

    /// <summary>
    /// Get the amount of letters int the word, that player is collecting
    /// </summary>
    /// <returns> int </returns>
    public int GetAmountOfLettersInWord()
    {
        return amountOfLetterInWord;
    }

    /// <summary>
    /// Reload the level, reset the amount of letters in word and clear the word to check
    /// </summary>
    public void LevelReload()
    {
        levelData.SetLevelReload(true);
        amountOfLetterInWord = 0;
        wordToCheck = "";
    }

    /// <summary>
    /// Get the number of an answer used in the house animation
    /// </summary>
    /// <returns></returns>
    public int GetAnswerNumber()
    {
        return answerNumber;
    }

    /// <summary>
    /// Checks if the level is completed, used in the house animation
    /// </summary>
    /// <returns></returns>
    public bool GetLevelDone()
    {
        return levelDone;
    }

    /// <summary>
    /// Sets the state of the done level, used to reset the value after the animation is done
    /// </summary>
    /// <param name="value"></param>
    public void SetLevelDone(bool value)
    {
        levelDone = value;
    }

    /// <summary>
    /// Load the next level and reset the data
    /// </summary>
    private void LoadNextLevel()
    {
        wordToCheck = "";
        amountOfLetterInWord = 0;
        levelData.SetLevelChange(true);
    }
}

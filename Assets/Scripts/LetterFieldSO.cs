using UnityEngine;
using Array2DEditor;

/// <summary>
/// Scriptable object for creating the levels (easier for designers)
/// </summary>
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LetterField", order = 1)]
public class LetterFieldSO : ScriptableObject
{
    public Array2DString letters;

    public string correctAnswer;
    public GameObject letterPrefab;
    private int letterXChange = 0;
    private int letterZChange = 0;
    private char randomLetter;

    private readonly System.Random rnd = new();

    /// <summary>
    /// Generating level with already set and randomised letter
    /// </summary>
    /// <param name="areaData"></param>
    public void GenerateLevel(LettersAreaData areaData)
    {
        letterZChange = areaData.GetStartZ();

        for (int i = 0; i < letters.GridSize.y; i++)
        {
            letterXChange = areaData.GetStartX();
            for (int j = 0; j < letters.GridSize.x; j++)
            {
                if (letters.GetCell(j, i).Equals("0") || letters.GetCell(j, i).Equals(""))
                {
                    //Load random letter using ASCII code (char)
                    randomLetter = (char)rnd.Next(65, 91);
                    //Make the letter a string, because the name of an object is a string
                    letters.SetCell(j, i, randomLetter.ToString());
                }

                Vector3 spawnPoint = new Vector3(letterXChange, 0.55f, letterZChange);
                letterPrefab.name = letters.GetCell(j, i);
                GameObject letter = Instantiate(letterPrefab, spawnPoint, Quaternion.identity);
                letter.name = letter.name.Replace("(Clone)", "").Trim();
                letter.transform.parent = areaData.transform;

                letterXChange += areaData.GetSpaceBetweenColumns();
            }
            letterZChange -= areaData.GetSpaceBetweenRows();
            
        }
    }
}

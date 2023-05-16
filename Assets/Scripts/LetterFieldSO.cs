using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Array2DEditor;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LetterField", order = 1)]
public class LetterFieldSO : ScriptableObject
{
    public Array2DString letters; // MAYBE: you can even create a SO creator: just type in the right answer, and it creates a letter field containing it???

    public string correctAnswer;
    public GameObject letterPrefab;
    private int letterXChange = 0;
    private int letterZChange = 0;
    private char randomLetter;

    private readonly System.Random rnd = new System.Random();

    public void GenerateLevel(LettersAreaData areaData)
    {
        letterXChange = areaData.GetStartX();
        letterZChange = areaData.GetStartZ();

        for (int i = 0; i < letters.GridSize.y; i++)
        {
            for (int j = 0; j < letters.GridSize.x; j++)
            {
                if (letters.GetCell(j, i).Equals("0") || letters.GetCell(j, i).Equals(""))
                {
                    //Debug.Log("Found the random letter");
                    //Load random letter using ASCII code, it needs to be string later, because we have an array of strings
                    randomLetter = (char)rnd.Next(65, 91);
                    letters.SetCell(j, i, randomLetter.ToString());
                }

                //Set the spawnpoint for the objects, set its name, create it and set the parent (usefull for deleting children later)
                Vector3 spawnPoint = new Vector3(letterXChange, 0.55f, letterZChange);
                letterPrefab.name = letters.GetCell(j, i);
                GameObject letter = Instantiate(letterPrefab, spawnPoint, Quaternion.identity);
                letter.name = letter.name.Replace("(Clone)", "").Trim();
                letter.transform.parent = areaData.transform;

                letterXChange += areaData.GetSpaceBetweenColumns();
            }
            letterZChange -= areaData.GetSpaceBetweenRows();
            letterXChange = areaData.GetStartX();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Array2DEditor;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LetterField", order = 1)]
public class LetterFieldSO : ScriptableObject
{
    public Array2DString letters; // MAYBE: you can even create a SO creator: just type in the right answer, and it creates a letter field containing it???

    public string correctAnswer;
}

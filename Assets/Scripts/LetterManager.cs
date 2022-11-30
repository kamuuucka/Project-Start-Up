using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class LetterManager : MonoBehaviour
{
    public GameObject[] letterPlacement = new GameObject[9];
    public int placeSelector = 0;

    void Awake()
    {
        Debug.Log("stuff");

        for (int i = 0; i < letterPlacement.Length; i++)
        {
            Debug.Log(letterPlacement[i].transform.position);

        }
    }
}

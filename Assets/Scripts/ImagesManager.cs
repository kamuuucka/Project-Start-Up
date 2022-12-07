using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script responsible for loading images in the background of the scene
/// </summary>
public class ImagesManager : MonoBehaviour
{
    public Material[] materials;
    public LettersAreaData lettersAreaData;

    private Renderer imageRenderer;
    
    void Start()
    {
        imageRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        imageRenderer.material = materials[lettersAreaData.GetLevelNumber()];
    }
}

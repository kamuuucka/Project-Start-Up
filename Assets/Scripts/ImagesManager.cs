using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagesManager : MonoBehaviour
{
    public Renderer renderer;
    public Material[] materials;
    public LettersAreaData lettersAreaData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        renderer.material = materials[lettersAreaData.GetLevelNumber()];
    }
}

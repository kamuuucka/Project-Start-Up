using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public List<AnimationController> animations = new List<AnimationController>();

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
            {
                animations[0].LoadAnimations(animations[0].AnimationName);
            }
        if (Input.GetKeyUp(KeyCode.Space))
            {
                animations[1].LoadAnimations(animations[1].AnimationName);
            }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animations[2].LoadAnimations(animations[2].AnimationName);
        }    
    }
}

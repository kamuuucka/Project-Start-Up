using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public List<AnimationController> animations = new List<AnimationController>();
    public LetterManager manager;

    void Update()
    {
        if (manager.GetLevelDone())
        {
            Debug.Log("ANIMATION PLAY");
            animations[manager.GetAnswerNumber() - 1].LoadAnimations(animations[manager.GetAnswerNumber() - 1].AnimationName);
            if (animations[0].animation.IsPlaying(animations[0].AnimationName))
            {
                Debug.Log("PLAYING");
                manager.SetAnimationPlaying(true);
            }
            else
            {
                Debug.Log("stop");
                manager.SetLevelDone(false);
            }
            
        } 
    }
}

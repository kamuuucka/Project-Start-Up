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
            //Invoke("SetLevelState", 2f);
            manager.SetLevelDone(false);
            
        } 
    }

    private void SetLevelState()
    {
        Debug.Log("Doing things");
        manager.SetAnimationPlaying(false);
    }
}

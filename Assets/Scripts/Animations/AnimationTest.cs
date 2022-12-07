using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    public string AnimationName;
    public string clip;

    
    List<string> animations = new List<string>();

    private Animation anim;
    private string childeren;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();

         

        int n = anim.GetClipCount();

        




        //anim = gameObject.GetComponent<Animation>();
        anim.GetClipCount();

        
        Debug.Log("clip" + clip);
        

        AnimationName = anim.name;
        Debug.Log(anim);

        Debug.Log("Clipcount " + anim.GetClipCount());
       // anim.Play(AnimationName);
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }
}

using UnityEngine;

public class AnimationMasterController : MonoBehaviour
{
    // make sure everything is in here, and that the order of both arrays match! -> ugly, but thats how it is...
    public Animator[] anims;
    string[] boolNames = { "Roof", "FrontWall", "BackWall", "LeftWall", "RightWall", "Chimney", "Door", "WindowCircle","WindowSquare" };

    void Update()
    {// test code / demo:
        for (int i = 0; i < 9; i++)
        {
            // TODO: instead of GetKeyDown, control this by game code...
            if (Input.GetKeyDown(KeyCode.Alpha1+i)) anims[i].SetBool(boolNames[i], true);   
        }
    }
}

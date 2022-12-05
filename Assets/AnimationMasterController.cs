using UnityEngine;

public class AnimationMasterController : MonoBehaviour
{
    // make sure everything is in here, and that the order of both arrays match! -> ugly, but thats how it is...
    public Animator[] anims;
    string[] boolNames = { "Roof", "FrontWall", "BackWall", "LeftWall", "RightWall", "Chimney", "Door", "WindowCircle","WindowSquare" };
    public LetterManager manager;
    void Update()
    {// test code / demo:
        for (int i = 0; i < 8; i++)
        {
            // TODO: instead of GetKeyDown, control this by game code...
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                Debug.Log(anims[i]);
                Debug.Log(boolNames[i]);
                anims[i].SetBool(boolNames[i], true);
            }
        }

        if (manager.GetLevelDone())
        {
            //Debug.Log("ANIMATION PLAY");
            anims[manager.GetAnswerNumber() - 1].SetBool(boolNames[manager.GetAnswerNumber() - 1], true);
            //Invoke("SetLevelState", 2f);
            manager.SetLevelDone(false);

        }
    }
}

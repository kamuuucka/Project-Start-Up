using UnityEngine;

/// <summary>
/// Script responsible for playing the right animation of the House
/// </summary>
public class AnimationMasterController : MonoBehaviour
{
    //This array needs to match the boolNames order, otherwise the animations will play wrongly
    public Animator[] anims;
    string[] boolNames = { "RightWall", "BackWall", "LeftWall", "FrontWall", "Roof", "Door", "WindowCircle", "WindowSquare", "Chimney" };
    public LetterManager manager;
    void Update()
    {
        if (manager.GetLevelDone())
        {
            switch (manager.GetAnswerNumber() - 1)
            {
                case 0://walls
                    for (int j = 0; j < 4; j++)
                    {
                        anims[j].SetBool(boolNames[j], true);
                    }
                    break;

                case 1://roof
                    anims[4].SetBool(boolNames[4], true);
                    break;

                case 2://door windows
                    for (int j = 5; j < 8; j++)
                    {
                        anims[j].SetBool(boolNames[j], true);
                    }
                    break;

                case 3://chimney
                    anims[8].SetBool(boolNames[8], true);
                    break;

                case 4://smoke
                    //TODO: Smoke particles going out of the chimney!!!
                    Debug.Log("SMOK");
                    break;

                default:
                    break;
            }
            manager.SetLevelDone(false);
        }
    }
}
